namespace Core.Providers
{
    using Common.DTOs;
    using Common.DTOs.Alexa;
    using Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Threading.Tasks;
    public class SecurityProvider : ISecurityProvider
    {
        private readonly IPlayerRepository alexaRepository;

        public SecurityProvider(IPlayerRepository alexaRepository)
        {
            this.alexaRepository = alexaRepository;
        }

        public AlexaAccountDTO CreateSession(AlexaRequestDTO alexaRequestDTO)
        {
            return this.alexaRepository.AddOrUpdateAccount(alexaRequestDTO);
        }

        public void LogRequest(AlexaRequestDTO alexaRequestDTO, AlexaAccountDTO alexaAccountDTO)
        {
            alexaRequestDTO.AccountRefId = alexaAccountDTO.AccountId;

            this.alexaRepository.LogRequest(alexaRequestDTO);
        }

        public PlayerDTO GetPlayer(AlexaAccountDTO alexaAccountDto)
        {
            PlayerDTO playerDto = null;
            if (alexaAccountDto.AccountId != Guid.Empty)
            {
                playerDto = this.alexaRepository.GetPlayerByAccountId(alexaAccountDto.AccountId);
            }
            
            return playerDto ?? this.alexaRepository.CreatePlayer(alexaAccountDto);
        }

    }
}