namespace Data.Repositories
{
    using AutoMapper;
    using Common.DTOs;
    using Common.DTOs.Alexa;
    using Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;

    public class PlayerRepository : RepositoryBase, IPlayerRepository
    {        
        public AlexaAccountDTO AddOrUpdateAccount(AlexaRequestDTO alexaRequestDto)
        {
            using (var context = new RealmContext())
            {
                var alexaAccount = context.AlexaAccounts.AsNoTracking()
                    .SingleOrDefault(o => o.AlexaUserId == alexaRequestDto.UserId);

                if (alexaAccount != null)
                {
                    alexaAccount.RequestCount++;
                    alexaAccount.LastRequest = DateTime.UtcNow;
                    context.Entry(alexaAccount).State = EntityState.Modified;
                }
                else
                {
                    alexaAccount = new AlexaAccount()
                    {
                        AccountId = Guid.NewGuid(),
                        AlexaUserId = alexaRequestDto.UserId,
                        DateCreated = DateTime.UtcNow,
                        LastRequest = DateTime.UtcNow,
                        RequestCount = 1
                    };

                    context.Entry(alexaAccount).State = EntityState.Added;
                }
                context.SaveChanges();

                return Mapper.Map<AlexaAccountDTO>(alexaAccount);
            }
        }

        public void LogRequest(AlexaRequestDTO alexaRequestDto)
        {
            using (var context = new RealmContext())
            {
                var alexaRequest = Mapper.Map<AlexaRequest>(alexaRequestDto);
                alexaRequest.DateCreated = DateTime.UtcNow;
                context.Entry(alexaRequest).State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public PlayerDTO GetPlayerByAccountId(Guid accountId)
        {
            using (var context = new RealmContext())
            {
                var player = context.Players.Include("Inventories").AsNoTracking()
                .SingleOrDefault(o => o.AccountRefId == accountId);

                if (player == null)
                {
                    return null;
                }

                var playerDto = Mapper.Map<PlayerDTO>(player);
                playerDto.Inventories = Mapper.Map<List<InventoryDTO>>(player.Inventories);

                return playerDto;
            }
        }

        public PlayerDTO GetPlayer(Guid playerId)
        {
            using (var context = new RealmContext())
            {
                var player = context.Players.Include("Inventories").AsNoTracking()
                .Single(o => o.PlayerId == playerId);

                if (player == null)
                {
                    return null;
                }

                var playerDto = Mapper.Map<PlayerDTO>(player);
                playerDto.Inventories = Mapper.Map<List<InventoryDTO>>(player.Inventories);

                return playerDto;
            }

        }

        public PlayerDTO CreatePlayer(AlexaAccountDTO alexaAccountDto)
        {
            using (var context = new RealmContext())
            {
                var defaultPlayer = context.Players.AsNoTracking().Single(o => o.PlayerId == Guid.Empty);

                var player = new Player
                {
                    PlayerId = Guid.NewGuid(),
                    Name = defaultPlayer.Name,
                    MapRefId = defaultPlayer.MapRefId,
                    LocationX = defaultPlayer.LocationX,
                    LocationY = defaultPlayer.LocationY,
                    Level = defaultPlayer.Level,
                    Verbosity = defaultPlayer.Verbosity,
                    Gold = defaultPlayer.Gold,
                    Energy = defaultPlayer.Energy,
                    Toughness = defaultPlayer.Toughness,
                    AccountRefId = alexaAccountDto.AccountId
                };

                context.Entry(player).State = EntityState.Added;
                context.SaveChanges();

                var playerDto = Mapper.Map<PlayerDTO>(player);
                playerDto.Inventories = new List<InventoryDTO>();

                return playerDto;
            }
        }

        public PlayerDTO UpdatePlayer(PlayerDTO playerDto)
        {
            using (var context = new RealmContext())
            {
                var player = context.Players.AsNoTracking()
                    .Single(o => o.PlayerId == playerDto.PlayerId);

                Mapper.Map(playerDto, player);
                
                context.Entry(player).State = EntityState.Modified;
                context.SaveChanges();

                return Mapper.Map<PlayerDTO>(player);
            }
        }

        public InventoryDTO AddOrUpdateInventory(InventoryDTO inventoryDto)
        {
            using (var context = new RealmContext())
            {
                var result = context.Inventories.AsNoTracking()
                    .SingleOrDefault(o => o.InventoryId == inventoryDto.InventoryId);

                if (result != null)
                {
                    result = Mapper.Map(inventoryDto, result);
                    context.Entry(result).State = EntityState.Modified;
                }
                else
                {
                    inventoryDto.InventoryId = Guid.NewGuid();
                    result = Mapper.Map<Inventory>(inventoryDto);
                    context.Entry(result).State = EntityState.Added;
                }
                context.SaveChanges();

                return Mapper.Map<InventoryDTO>(result);
            }
        }

        public void DeleteInventoryItem(Guid inventoryId)
        {
            using (var context = new RealmContext())
            {
                var result = context.Inventories.AsNoTracking()
                    .SingleOrDefault(o => o.InventoryId == inventoryId);

                context.Entry(result).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
