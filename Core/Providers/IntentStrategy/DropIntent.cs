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

    internal class DropIntent : IntentBase, IIntent
    {
        public static string IntentType = "DropIntent";
        private const string SlotType = "item";

        public DropIntent() : this(new PlayerRepository(), 
            new MapRepository()) { }

        public DropIntent(IPlayerRepository playerRepository,
            IMapRepository mapRepository) : base(playerRepository, mapRepository) { }

        public void Execute(IntentModel intentModel)
        {
            var value = base.GetSlotValue(intentModel.Request, SlotType);

            var item = base.MapRepository.GetItem(value);
            var inventory = intentModel.Player.Inventories.FirstOrDefault(o => o.ItemRefId == item.ItemId);

            var output = new StringBuilder();
            if (inventory != null)
            {
                base.PlayerRepository.DeleteInventoryItem(inventory.InventoryId);

                var cellItem = Mapper.Map<CellItemDTO>(inventory);
                cellItem.CellRefId = intentModel.Cell.CellId;
                base.MapRepository.AddOrUpdateCellItem(cellItem);

                intentModel.Player = this.PlayerRepository
                    .GetPlayer(intentModel.Player.PlayerId);
                intentModel.Cell = base.MapRepository
                    .GetCell(intentModel.Player.MapRefId, intentModel.Player.LocationX, intentModel.Player.LocationY);

                output.Append(string.Format(StaticText.DropIntent_DroppedItem, value));
            }
            else
            {
                output.Append(base.IsSlotValueValid(value)
                    ? string.Format(StaticText.DropIntent_DontHaveItem, value)
                    : StaticText.DropIntent_DropWhatItem);
            }

            intentModel.Output.Append(output);
        }

    }
}
