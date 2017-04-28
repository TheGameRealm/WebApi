using Common.DTOs;
using Common.DTOs.Alexa;

namespace Core.Providers
{
    public interface ISecurityProvider
    {
        AlexaAccountDTO CreateSession(AlexaRequestDTO alexaRequestDTO);
        void LogRequest(AlexaRequestDTO alexaRequestDTO, AlexaAccountDTO alexaAccountDTO);
        PlayerDTO GetPlayer(AlexaAccountDTO alexaAccountDTO);
    }
}