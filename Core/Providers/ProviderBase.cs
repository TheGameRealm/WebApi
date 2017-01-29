using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Providers
{
    public abstract class ProviderBase
    {
        public virtual string GetSlotValue(AlexaRequestModel alexaRequestModel, string key)
        {
            var value = alexaRequestModel.Request.Intent.GetSlots().SingleOrDefault(o => o.Key == key).Value;

            return value;
        }

        public virtual bool IsSlotValueValid(List<string> validChoices, string value)
        {
            var validChoice = validChoices.Any(o => o == value);

            return validChoice;
        }

    }
}
