using Common.DTOs;
using Common.DTOs.Alexa;
using System;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IPlayerRepository
    {
        AlexaAccountDTO AddOrUpdateAccount(AlexaRequestDTO alexaRequestDTO);
        void LogRequest(AlexaRequestDTO alexaRequestDTO);

        PlayerDTO GetPlayerByAccountId(Guid accountId);
        PlayerDTO GetPlayer(Guid playerId);
        PlayerDTO CreatePlayer(AlexaAccountDTO alexaAccountDTO);
        PlayerDTO UpdatePlayer(PlayerDTO playerDTO);
        InventoryDTO AddOrUpdateInventory(InventoryDTO inventoryDTO);
        void DeleteInventoryItem(Guid inventoryId);
    }
}