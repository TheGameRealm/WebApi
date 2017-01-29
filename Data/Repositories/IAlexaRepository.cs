using Common.DTOs.Alexa;

namespace Data.Repositories
{
    public interface IAlexaRepository
    {
        AlexaRequestDTO Create(AlexaRequestDTO alexaRequestDTO);
    }
}