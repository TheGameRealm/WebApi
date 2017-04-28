using System;
namespace Core.Providers.IntentStrategy
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.DTOs;
    using Common.Enums;
    using Common.Extensions;
    using Common.Models;
    using Common.Static;
    using Data.Repositories;

    internal class AreaIntent : IntentBase, IIntent
    {
        public static string IntentType = "AreaIntent";
        public static string SlotType = "";

        public AreaIntent() : this(new PlayerRepository(), new MapRepository()) { }

        public AreaIntent(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository) { }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType) ?? string.Empty;
            var enumValue = Directions.None;
            Enum.TryParse(value.UpcaseFirst(), out enumValue);

            intentModel.Player = base.PlayerRepository.UpdatePlayer(intentModel.Player);
            intentModel.Cell = base.MapRepository.GetCell(intentModel.Player.MapRefId, intentModel.Player.LocationX, intentModel.Player.LocationY);
            intentModel.Output.Append(BuildMovementOutput(value, intentModel.Cell, false));
        }

        protected static StringBuilder BuildMovementOutput(string value, CellDTO cellDTO, bool? hasMoved)
        {
            var output = new StringBuilder();

            switch (hasMoved)
            {
                case true:
                    {
                        output.Append(string.Format(StaticText.GoIntent_Traveled, value));
                        break;
                    }
                case false:
                    {
                        output.Append(string.Format(StaticText.GoIntent_CantGoThatWay, value));
                        break;
                    }
                case null:
                default:
                    {
                        output.Append(StaticText.GoIntent_DontKnowHow);
                        break;
                    }
            }

            return output;
        }

    }
}
