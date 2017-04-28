using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Common.DTOs.Alexa;
using Common.Models;
using Common.Security;
using Core.Providers;
using Microsoft.Practices.Unity;
using NLog;
using Web.App_Start;
using Web.Utilities;

namespace Web.Filters
{
    /// <summary>
    ///     This is a action filter used for validation for an Alexa Application.
    /// </summary>
    public class AlexaAuthFilter : ActionFilterAttribute
    {
        /// <summary>
        ///     Name of Alexa Request Model
        /// </summary>
        private const string AlexaRequestModel = "AlexaRequestModel";

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public AlexaAuthFilter()
        {
            var container = UnityConfig.GetConfiguredContainer();
            securityProvider = container.Resolve<ISecurityProvider>();
        }

        private ISecurityProvider securityProvider { get; }

        /// <summary>
        ///     Process Validation for Alexa Application
        /// </summary>
        /// <param name="actionContext">Http Action Context</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task OnActionExecutingAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken)
        {
            var parameters = actionContext.ActionDescriptor.GetParameters();
            var parameter = parameters?.FirstOrDefault();

            if (parameter != null)
            {
                var parameterValue = actionContext.ActionArguments != null && actionContext.ActionArguments.Any()
                    ? actionContext.ActionArguments.First().Value
                    : null;

                logger.Trace($"Parameter {parameter.ParameterName} (Type: {parameter.ParameterType.FullName}) with value of '{parameterValue}'");

                try
                {
                    var model = parameterValue as AlexaRequestModel;
                    if (parameter.ParameterType.Name == AlexaRequestModel && model != null)
                    {
                        var test2 = AppSettings.ReadSetting("applicationId");

                        if (model.Session.Application.ApplicationId != AppSettings.ReadSetting("applicationId"))
                            if (actionContext.Request.RequestUri.Host.ToLower().Equals("localhost"))
                            {
#if !DEBUG
                                //await Task.Factory.StartNew(() =>
                                //{
                                //    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Invalid Alexa application Id in request");
                                //});

                                //return;
#endif
                            }

                        var alexaRequestDTO = AlexaRequestDTO.ToAlexaRequestDTO(model);

                        var alexaAccountDTO = securityProvider.CreateSession(alexaRequestDTO);

                        securityProvider.LogRequest(alexaRequestDTO, alexaAccountDTO);

                        var playerDTO = securityProvider.GetPlayer(alexaAccountDTO);

                        var customPrincipal = new CustomPrincipal(playerDTO.Name)
                        {
                            AccountId = alexaAccountDTO.AccountId,
                            PlayerId = playerDTO.PlayerId
                        };

                        customPrincipal.Roles.Add("Player");

                        Thread.CurrentPrincipal = customPrincipal;
                        actionContext.RequestContext.Principal = customPrincipal;
                    }
                }
                catch (SqlException ex)
                {
                    logger.Fatal(ex, "AlexaAuthFilter");
                }
            }

            await base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}