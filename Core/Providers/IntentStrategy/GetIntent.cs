namespace Core.Providers.IntentStrategy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.DTOs;
    using Common.Extensions;
    using Common.Models;
    using Common.Static;
    using Data.Repositories;

    internal class GetIntent : IntentBase, IIntent
    {
        public static string IntentType = "GetIntent";
        private const string SlotType = "item";

        public GetIntent() : this(new PlayerRepository(), 
            new MapRepository()) { }

        public GetIntent(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository) { }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType);

            var item = base.MapRepository.GetItem(value);
            var cellItem = intentModel.Cell.CellItems.FirstOrDefault(o => o.ItemRefId == item.ItemId);

            var output = new StringBuilder();
            if (cellItem != null)
            {
                base.MapRepository.DeleteCellItem((Guid)cellItem.CellItemId);
                var inventory = Mapper.Map<InventoryDTO>(cellItem);
                inventory.PlayerRefId = intentModel.Player.PlayerId;
                base.PlayerRepository.AddOrUpdateInventory(inventory);

                intentModel.Player = base.PlayerRepository
                    .GetPlayer(intentModel.Player.PlayerId);
                intentModel.Cell = base.MapRepository
                    .GetCell(intentModel.Player.MapRefId, intentModel.Player.LocationX, intentModel.Player.LocationY);

                output.Append(string.Format(StaticText.GetIntent_GetItem, value));
            }
            else
            {
                output.Append(base.IsSlotValueValid(value)
                    ? string.Format(StaticText.GetIntent_DontSeeItem, value)
                    : StaticText.GetIntent_GetWhatItem);
            }

            intentModel.Output.Append(output);
        }

    }
}
