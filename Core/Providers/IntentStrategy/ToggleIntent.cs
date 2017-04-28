using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Common.Extensions;
using Common.Models;
using Data.Repositories;

namespace Core.Providers.IntentStrategy
{
    internal class ToggleIntent : IntentBase, IIntent
    {
        public static string IntentType = "ToggleIntent";
        private const string SlotType = "Feature";

        public ToggleIntent() : this(new PlayerRepository(), new MapRepository()) { }

        public ToggleIntent(IPlayerRepository playerRepository, IMapRepository mapRepository)
            : base(playerRepository, mapRepository)
        {
        }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType);

            if (!string.IsNullOrEmpty(value))
            {
                if (value == Verbosity.AreaDescription.GetDescription())
                {
                    intentModel.Player.Verbosity = intentModel.Player.Verbosity.HasFlag(Verbosity.AreaDescription)
                        ? intentModel.Player.Verbosity -= Verbosity.AreaDescription
                        : intentModel.Player.Verbosity |= Verbosity.AreaDescription;
                }

                if (value == Verbosity.Direction.GetDescription())
                {
                    intentModel.Player.Verbosity = intentModel.Player.Verbosity.HasFlag(Verbosity.Direction)
                        ? intentModel.Player.Verbosity -= Verbosity.Direction
                        : intentModel.Player.Verbosity |= Verbosity.Direction;
                }

                if (value == Verbosity.CellItems.GetDescription())
                {
                    intentModel.Player.Verbosity = intentModel.Player.Verbosity.HasFlag(Verbosity.CellItems)
                        ? intentModel.Player.Verbosity -= Verbosity.CellItems
                        : intentModel.Player.Verbosity |= Verbosity.CellItems;
                }
            }

            intentModel.Player = base.PlayerRepository.UpdatePlayer(intentModel.Player);
        }
    }
}
