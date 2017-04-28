namespace Core.Providers
{
    using Common.Models;

    public interface IIntentProvider
    {
        AlexaResponseModel LaunchRequest(AlexaRequestModel alexaRequestModel);
        AlexaResponseModel IntentRequest(AlexaRequestModel alexaRequestModel);
        AlexaResponseModel SessionEndedRequest(AlexaRequestModel alexaRequestModel);
        AlexaResponseModel HelpRequest(AlexaRequestModel alexaRequestModel);
    }
}