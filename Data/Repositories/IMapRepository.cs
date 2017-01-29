using System;
using Common.DTOs;

namespace Data.Repositories
{
    public interface IMapRepository
    {
        MapDTO GetMap(Guid mapGuid);
    }
}