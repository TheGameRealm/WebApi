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

namespace Web.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Alexa")]
    [AllowAnonymous]
    [AlexaAuthFilter]
    public class AlexaController : ApiController
    {
        private IIntentProvider intentProvider { get; set; }

        public AlexaController(IIntentProvider intentProvider)
        {
            this.intentProvider = intentProvider;
        }

        [HttpGet]
        [Route("Session")]
        public AlexaResponseModel Get()
        {
            var alexaRequestModel = new AlexaRequestModel();
            alexaRequestModel.Request.Type = "IntentRequest";
            alexaRequestModel.Request.Intent.Name = "GoIntent";
            //alexaRequestModel.Request.Intent.Slots = new { name = "direction", value = "north" };
            alexaRequestModel.Request.Intent.GetSlots().Add(new KeyValuePair<string, string>("direction", "north"));

            return this.Get(alexaRequestModel);
        }
        
        [Route("Session")]
        [HttpPost]
        public AlexaResponseModel Get(AlexaRequestModel alexaRequestModel)
        {
            AlexaResponseModel alexaResponseModel = null;

            BuildRequestModel(alexaRequestModel);
            
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
            }

            return alexaResponseModel;
        }

        private static void BuildRequestModel(AlexaRequestModel alexaRequestModel)
        {
            var alexaRequestDTO = new AlexaRequestDTO()
            {
                //MemberId = (alexaRequestModel.Session.Attributes == null) ? 0 : alexaRequestModel.Session.Attributes.MemberId,
                Timestamp = alexaRequestModel.Request.Timestamp,
                Intent = (alexaRequestModel.Request.Intent == null) ? "" : alexaRequestModel.Request.Intent.Name,
                AppId = alexaRequestModel.Session.Application.ApplicationId,
                RequestId = alexaRequestModel.Request.RequestId,
                SessionId = alexaRequestModel.Session.SessionId,
                UserId = alexaRequestModel.Session.User.UserId,
                IsNew = alexaRequestModel.Session.New,
                Version = alexaRequestModel.Version,
                Type = alexaRequestModel.Request.Type,
                Reason = alexaRequestModel.Request.Reason,
                SlotsList = alexaRequestModel.Request.Intent.GetSlots(),
                DateCreated = DateTime.UtcNow
            };
        }
    }
}
