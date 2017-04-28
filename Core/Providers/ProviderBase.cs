namespace Core.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Common.Enums;
    using Common.Extensions;
    using Common.Models;
    using Common.Security;
    using Data.Repositories;

    public abstract class ProviderBase
    {
        protected readonly IPlayerRepository PlayerRepository;
        protected readonly IMapRepository MapRepository;

        protected ProviderBase(IPlayerRepository playerRepository,
            IMapRepository mapRepository)
        {
            this.PlayerRepository = playerRepository;
            this.MapRepository = mapRepository;
        }

        protected ICustomPrincipal CustomPrincipal => Thread.CurrentPrincipal as ICustomPrincipal;

        protected static StringBuilder BuildDirectionOutput(IntentModel intentModel)
        {
            var output = new StringBuilder();

            var directions = new List<string>();
            directions.Add(intentModel.Cell.Directions.HasFlag(Directions.North) ? Directions.North.GetDescription() : string.Empty);
            directions.Add(intentModel.Cell.Directions.HasFlag(Directions.South) ? Directions.South.GetDescription() : string.Empty);
            directions.Add(intentModel.Cell.Directions.HasFlag(Directions.East) ? Directions.East.GetDescription() : string.Empty);
            directions.Add(intentModel.Cell.Directions.HasFlag(Directions.West) ? Directions.West.GetDescription() : string.Empty);
            directions.RemoveAll(o => o == string.Empty);

            for (var i = 0; i < directions.Count; i++)
            {
                var isLast = (i + 1) == directions.Count;
                var isTwoOrMore = directions.Count > 1;
                var isOnlyTwo = directions.Count == 2;

                if (i == 0)
                {
                    output.Append($"The {intentModel.Cell.PathDescription} leads {directions[i]}");
                }
                else
                {
                    if (!isLast && isTwoOrMore)
                    {
                        output.Append($", {directions[i]}");
                    }
                }

                if (isLast && isTwoOrMore)
                {
                    if (!isOnlyTwo)
                    {
                        output.Append($",");
                    }

                    output.Append($" and {directions[i]}");
                }
            }

            output.Append(". ");
            output.Append(" . . ");

            return output;
        }

        protected StringBuilder BuildCellItemsOutput(IntentModel intentModel)
        {
            var output = new StringBuilder();

            if (!intentModel.Cell.CellItems.Any())
            {
                return output;
            }
            
            if (intentModel.Cell.CellItems.Count == 1)
            {
                var item = this.MapRepository.GetItem(intentModel.Cell.CellItems[0].ItemRefId);

                output.Append($"You see a {item.Name} on the ground. ");
            }
            else
            {
                output.Append($"You see several items on the ground. ");
            }

            output.Append(" . . . ");

            return output;
        }

        protected static StringBuilder BuildAreaDescription(IntentModel intentModel)
        {
            var output = new StringBuilder();

            output.Append(!string.IsNullOrEmpty(intentModel.Cell.Description) ? intentModel.Cell.Description : intentModel.Map.Description);
            output.Append(" . . . ");

            return output;
        }

        protected virtual string GetSlotValue(AlexaRequestModel alexaRequestModel, string key)
        {
            return alexaRequestModel.Request.Intent.Slots
                .SingleOrDefault(o => o.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).Value ?? string.Empty;
        }
    }
}
