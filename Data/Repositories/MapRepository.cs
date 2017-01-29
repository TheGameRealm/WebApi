using AutoMapper;
using Common.DTOs;
using Data.Entity;
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
        public MapRepository(RealmContext context) : base(context)
        {

        }

        public MapDTO GetMap(Guid mapGuid)
        {
            var result = Context.Maps.Include(o => o.Cells).SingleOrDefault(o => o.MapGuid == mapGuid) ?? new Map();

            var mapDTO = Mapper.Map<MapDTO>(result);

            mapDTO.CellsDTO = Mapper.Map<List<CellDTO>>(result.Cells);

            return mapDTO;
        }
        
    }
}
