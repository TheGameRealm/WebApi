using Common.DTOs;
using Common.DTOs.Alexa;
using Common.Models;
using Core.Providers;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.Models;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Web.Filters;
using Common.Security;

namespace Web.Controllers
{
    [RoutePrefix("api/Alexa")]
    [AllowAnonymous]
    [AlexaAuthFilter]
    public class AlexaController : ApiControllerBase
    {
        private IIntentProvider intentProvider { get; set; }

        public AlexaController(IIntentProvider intentProvider)
        {
            this.intentProvider = intentProvider;
        }
       
        [Route("Session")]
        [HttpPost]
        public AlexaResponseModel Post(AlexaRequestModel alexaRequestModel)
        {
            Thread.CurrentPrincipal = RequestContext.Principal;

            logger.Info($"Request.Type = {alexaRequestModel.Request.Type}");

            AlexaResponseModel alexaResponseModel = null;
            switch (alexaRequestModel.Request.Type)
            {
                case "LaunchRequest":
                    alexaResponseModel = this.intentProvider.LaunchRequest(alexaRequestModel);
                    break;
                case "IntentRequest":
                    alexaResponseModel = this.intentProvider.IntentRequest(alexaRequestModel);
                    break;
                case "SessionEndedRequest":
                    alexaResponseModel = this.intentProvider.SessionEndedRequest(alexaRequestModel);
                    break;
                case "LeaveIntent":
                    alexaResponseModel = this.intentProvider.SessionEndedRequest(alexaRequestModel);
                    break;
                case "AMAZON.HelpIntent":
                    alexaResponseModel = this.intentProvider.HelpRequest(alexaRequestModel);
                    break;
            }

            return alexaResponseModel;
        }
       
    }
}
