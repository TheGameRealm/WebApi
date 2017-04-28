using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTOs.Alexa
{
    public partial class AlexaRequestDTO
    {
        public string SlotsToString
        {
            get
            {
                var stringBuilder = new StringBuilder();
                this.Slots.ForEach(o =>
                {
                    stringBuilder.Append($"{o.Key} = {o.Value}");
                });

                return stringBuilder.ToString();
            }
        }

        public static AlexaRequestDTO ToAlexaRequestDTO(AlexaRequestModel alexaRequestModel)
        {
            var alexaRequestDTO = new AlexaRequestDTO()
            {
                Timestamp = alexaRequestModel.Request.Timestamp,
                Intent = (alexaRequestModel.Request.Intent == null) ? "" : alexaRequestModel.Request.Intent.Name,
                RequestId = alexaRequestModel.Request.RequestId,
                SessionId = alexaRequestModel.Session.SessionId,
                UserId = alexaRequestModel.Session.User.UserId,
                IsNew = alexaRequestModel.Session.New,
                Version = alexaRequestModel.Version,
                Type = alexaRequestModel.Request.Type,
                Slots = alexaRequestModel.Request.Intent.Slots,
                DateCreated = DateTime.UtcNow
            };

            return alexaRequestDTO;
        }

    }
}
