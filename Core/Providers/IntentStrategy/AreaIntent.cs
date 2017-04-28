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

    internal class GoIntent : IntentBase, IIntent
    {
        public static string IntentType = "GoIntent";
        public static string SlotType = "direction";

        public GoIntent() : this(new PlayerRepository(), new MapRepository()) { }

        public GoIntent(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository) { }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType) ?? string.Empty;
            var enumValue = Directions.None;
            Enum.TryParse(value.UpcaseFirst(), out enumValue);

            var hasMoved = EnteredPortal(enumValue, intentModel.Player, intentModel.Cell);
            if (hasMoved.HasValue && hasMoved.Value)
            {
                intentModel.Map = base.MapRepository.GetMap(intentModel.Player.MapRefId);
            }

            if (!hasMoved.HasValue || !hasMoved.Value)
            {
                hasMoved = MoveDirection(enumValue, intentModel.Player, intentModel.Cell);
            }

            intentModel.Player = base.PlayerRepository.UpdatePlayer(intentModel.Player);
            intentModel.Cell = base.MapRepository.GetCell(intentModel.Player.MapRefId, intentModel.Player.LocationX, intentModel.Player.LocationY);
            intentModel.Output.Append(BuildMovementOutput(value, intentModel.Cell, hasMoved));
        }

        private static bool? EnteredPortal(Directions enumValue, PlayerDTO playerDTO, CellDTO cellDTO)
        {
            if (cellDTO.GotoMapRefId.HasValue
                && cellDTO.GotoX.HasValue
                && cellDTO.GotoY.HasValue
                && cellDTO.PortalDirections.HasValue
                && cellDTO.PortalDirections.Value.HasFlag(enumValue))
            {
                playerDTO.MapRefId = (Guid)cellDTO.GotoMapRefId;
                playerDTO.LocationX = (int)cellDTO.GotoX;
                playerDTO.LocationY = (int)cellDTO.GotoY;

                return true;
            }

            return false;
        }

        private static bool? MoveDirection(Directions enumValue, PlayerDTO playerDTO, CellDTO cellDTO)
        {
            if (enumValue == Directions.None)
            {
                return null;
            }

            var canGoNorth = enumValue == Directions.North && cellDTO.Directions.HasFlag(Directions.North);
            playerDTO.LocationY = canGoNorth ? --playerDTO.LocationY : playerDTO.LocationY;

            var canGoEast = enumValue == Directions.East && cellDTO.Directions.HasFlag(Directions.East);
            playerDTO.LocationX = canGoEast ? ++playerDTO.LocationX : playerDTO.LocationX;

            var canGoSouth = enumValue == Directions.South && cellDTO.Directions.HasFlag(Directions.South);
            playerDTO.LocationY = canGoSouth ? ++playerDTO.LocationY : playerDTO.LocationY;

            var canGoWest = enumValue == Directions.West && cellDTO.Directions.HasFlag(Directions.West);
            playerDTO.LocationX = canGoWest ? --playerDTO.LocationX : playerDTO.LocationX;

            return (canGoNorth || canGoEast || canGoSouth || canGoWest);
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
