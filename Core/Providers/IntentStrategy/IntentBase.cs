using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common.DTOs;
using Common.Enums;
using Common.Extensions;
using Common.Models;
using Common.Security;
using Common.Static;
using Data.Repositories;

namespace Core.Providers.IntentStrategy
{
    public abstract class IntentBase
    {
        protected readonly IPlayerRepository PlayerRepository;
        protected readonly IMapRepository MapRepository;

        protected IntentBase(IPlayerRepository playerRepository,
            IMapRepository mapRepository)
        {
            this.PlayerRepository = playerRepository;
            this.MapRepository = mapRepository;
        }

        protected virtual string GetSlotValue(AlexaRequestModel alexaRequestModel, string key)
        {
            return alexaRequestModel.Request.Intent.Slots
                .SingleOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value ?? string.Empty;
        }

        protected virtual bool IsSlotValueValid(string value)
        {
            return this.MapRepository.GetItems()
                .Any(o => o.Name.Equals(value, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
