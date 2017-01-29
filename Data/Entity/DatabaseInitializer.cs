using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<RealmContext>
    {
        protected override void Seed(RealmContext context)
        {
            if (context.Maps.FirstOrDefault() != null)
            {
                return;
            }

            var dryLands = new Map() { MapGuid = Guid.NewGuid(), Name = "Dry Lands", Description = "This is an arid dead land. You shoud move on before you die of thirst.", Level = 0 };
            context.Maps.Add(dryLands);

            var forgottenValley = new Map() { MapGuid = Guid.NewGuid(), Name = "Forgotten Valley", Description = "The area is covered with dense jungle and the smell of decay.", Level = 1 };
            context.Maps.Add(forgottenValley);

            var caltera = new Map() { MapGuid = Guid.NewGuid(), Name = "Caltera", Description = "The land is mostly flat and full of vegetation", Level = 2 };
            context.Maps.Add(caltera);

            var calteraRidge = new Map() { MapGuid = Guid.NewGuid(), Name = "Caltera Ridge", Description = "The flat lands have given way to the hills. This area seems more wild and dangerous.", Level = 2 };
            context.Maps.Add(calteraRidge);

            var windPort = new Map() { MapGuid = Guid.NewGuid(), Name = "WindPort", Description = "Your in a small nearly abandoned village", Level = 1 };
            context.Maps.Add(windPort);

            // Build Dry Lands Map
            var cell1 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 0, canGoEast = true, canGoNorth = false, canGoSouth = true, canGoWest = false, hasPortal = false, isHostile = false, GotoMap = dryLands.MapGuid, GotoX = 2, GotoY = 2, PortalDescription = "A magical portal. I wonder where it will take you?" };
            context.Cells.Add(cell1);

            var cell2 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 1, canGoEast = true, canGoNorth = true, canGoSouth = true, canGoWest = false, hasPortal = false, isHostile = false };
            context.Cells.Add(cell2);

            var cell3 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 2, canGoEast = true, canGoNorth = true, canGoSouth = false, canGoWest = false, hasPortal = false, isHostile = false };
            context.Cells.Add(cell3);

            var cell4 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 0, canGoEast = true, canGoNorth = false, canGoSouth = true, canGoWest = true, hasPortal = false, isHostile = false };
            context.Cells.Add(cell4);

            var cell5 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 1, canGoEast = true, canGoNorth = true, canGoSouth = true, canGoWest = true, hasPortal = false, isHostile = false };
            context.Cells.Add(cell5);

            var cell6 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 2, canGoEast = true, canGoNorth = true, canGoSouth = false, canGoWest = true, hasPortal = false, isHostile = false };
            context.Cells.Add(cell6);

            var cell7 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 0, canGoEast = false, canGoNorth = false, canGoSouth = true, canGoWest = true, hasPortal = false, isHostile = false };
            context.Cells.Add(cell7);

            var cell8 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 1, canGoEast = false, canGoNorth = true, canGoSouth = true, canGoWest = true, hasPortal = false, isHostile = false };
            context.Cells.Add(cell8);

            var cell9 = new Cell() { Map = dryLands, CellGuid = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 2, canGoEast = false, canGoNorth = true, canGoSouth = false, canGoWest = true, hasPortal = false, isHostile = false, GotoMap = dryLands.MapGuid, GotoX = 0, GotoY = 0, PortalDescription = "A magical portal. I wonder where it will take you?" };
            context.Cells.Add(cell9);

            context.SaveChanges();
        }
    }
}
