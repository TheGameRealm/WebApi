using System;
using System.Collections.Generic;
using Common.DTOs;

namespace Data.Repositories
{
    public interface IMapRepository
    {
        MapDTO GetMap(Guid mapId);
        List<CellDTO> GetCells(Guid mapId);
        CellDTO GetCell(Guid mapId, int locationX, int locationY);
        List<CellItemDTO> GetCellItems(Guid cellId);
        CellItemDTO AddOrUpdateCellItem(CellItemDTO cellItemDTO);
        void DeleteCellItem(Guid cellItemId);
        List<ItemDTO> GetItems();
        ItemDTO GetItem(string name);
        ItemDTO GetItem(Guid itemId);
    }
}