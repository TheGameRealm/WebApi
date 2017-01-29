using Common.Models;

namespace Core.Providers
{
    public interface IIntentProvider
    {
        AlexaResponseModel LaunchRequest(AlexaRequestModel alexaRequestModel);
        AlexaResponseModel IntentRequest(AlexaRequestModel alexaRequestModel);
        AlexaResponseModel SessionEndedRequest(AlexaRequestModel alexaRequestModel);
    }
}