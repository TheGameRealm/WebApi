using AutoMapper;
using Common.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MapRepository : RepositoryBase, IMapRepository
    {
        public MapDTO GetMap(Guid mapId)
        {
            using (var context = new RealmContext())
            {
                var map = context.Maps.AsNoTracking()
                    .Single(o => o.MapId == mapId);

                return Mapper.Map<MapDTO>(map);
            }
        }

        public List<CellDTO> GetCells(Guid mapId)
        {
            using (var context = new RealmContext())
            {
                var cells = base.GetCache<List<Cell>>(mapId.ToString());
                if (cells == null)
                {

                    cells = context.Cells.AsNoTracking()
                        .Where(o => o.MapRefId == mapId).ToList();

                    base.AddCache<List<Cell>>(mapId.ToString(), cells);
                }

                return Mapper.Map<List<CellDTO>>(cells);
            }
        }

        public CellDTO GetCell(Guid mapId, int locationX, int locationY)
        {
            var cells = this.GetCells(mapId);

            var cellDto = cells
                .Single(o => o.MapRefId == mapId 
            && o.LocationX == locationX 
            && o.LocationY == locationY);

            cellDto.CellItems = this.GetCellItems(cellDto.CellId);

            return cellDto;
        }

        public List<CellItemDTO> GetCellItems(Guid cellId)
        {
            using (var context = new RealmContext())
            {
                var cellItems = context.CellItems.AsNoTracking()
                    .Where(o => o.CellRefId == cellId);

                return Mapper.Map<List<CellItemDTO>>(cellItems);
            }
        }

        public CellItemDTO AddOrUpdateCellItem(CellItemDTO cellItemDto)
        {
            using (var context = new RealmContext())
            {
                var result = context.CellItems.AsNoTracking()
                    .SingleOrDefault(o => o.CellItemId == cellItemDto.CellItemId);
                
                if (result != null)
                {
                    result = Mapper.Map(cellItemDto, result);
                    context.Entry(result).State = EntityState.Modified;
                }
                else
                {
                    cellItemDto.CellItemId = Guid.NewGuid();
                    result = Mapper.Map<CellItem>(cellItemDto);
                    context.Entry(result).State = EntityState.Added;
                }
                context.SaveChanges();

                return Mapper.Map<CellItemDTO>(result);
            }
        }

        public void DeleteCellItem(Guid cellItemId)
        {
            using (var context = new RealmContext())
            {
                var result = context.CellItems.AsNoTracking()
                    .SingleOrDefault(o => o.CellItemId == cellItemId);
                if (result == null) throw new ArgumentNullException(nameof(result));
                context.Entry(result).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<ItemDTO> GetItems()
        {
            using (var context = new RealmContext())
            {
                var items = this.GetCache<List<Item>>("Items");
                if (items == null)
                {
                    items = context.Items.AsNoTracking().ToList();

                    this.AddCache<List<Item>>("Items", items);
                }

                return Mapper.Map<List<ItemDTO>>(items);
            }
        }

        public ItemDTO GetItem(string name)
        {
            var item = this.GetItems()
                .Single(o => o.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

            return Mapper.Map<ItemDTO>(item);
        }

        public ItemDTO GetItem(Guid itemId)
        {
            var item = this.GetItems()
                .Single(o => o.ItemId == itemId);

            return Mapper.Map<ItemDTO>(item);
        }

    }
}
