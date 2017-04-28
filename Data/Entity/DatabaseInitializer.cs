//using Common.Enums;
//using Data.Entities;
//using System;
//using System.Data.Entity;
//using System.Linq;
//using System.Collections.Generic;
//using Data.Entities.Alexa;

//namespace Data.Entity
//{
//    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<RealmContext>
//    {
//        protected override void Seed(RealmContext context)
//        {
//            if (context.Maps.FirstOrDefault() != null)
//            {
//                return;
//            }

//            // Populate: Maps
//            var dryLands = new Map() { MapId = Guid.NewGuid(), Name = "Dry Lands", Description = "This is an arid dead land. You shoud move on before you die of thirst.", Level = 0 };
//            context.Maps.Add(dryLands);

//            var forgottenValley = new Map() { MapId = Guid.NewGuid(), Name = "Forgotten Valley", Description = "The area is covered with dense jungle and the smell of decay.", Level = 1 };
//            context.Maps.Add(forgottenValley);

//            var caltera = new Map() { MapId = Guid.NewGuid(), Name = "Caltera", Description = "The land is mostly flat and full of vegetation", Level = 2 };
//            context.Maps.Add(caltera);

//            var calteraRidge = new Map() { MapId = Guid.NewGuid(), Name = "Caltera Ridge", Description = "The flat lands have given way to the hills. This area seems more wild and dangerous.", Level = 2 };
//            context.Maps.Add(calteraRidge);

//            var windPort = new Map() { MapId = Guid.NewGuid(), Name = "WindPort", Description = "Your in a small nearly abandoned village", Level = 1 };
//            context.Maps.Add(windPort);

//            // Populate Map : "Dry Lands"
//            var cell1 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 0, Directions = Directions.East | Directions.South, hasPortal = true, GotoMapId = dryLands.MapId, GotoX = 2, GotoY = 2, PortalDescription = "A magical portal. I wonder where it will take you?" };
//            context.Cells.Add(cell1);

//            var cell2 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 1, Directions = Directions.East | Directions.North | Directions.South, hasPortal = false };
//            context.Cells.Add(cell2);

//            var cell3 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 0, LocationY = 2, Directions = Directions.East | Directions.North, hasPortal = false };
//            context.Cells.Add(cell3);

//            var cell4 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 0, Directions = Directions.East | Directions.South | Directions.West, hasPortal = false };
//            context.Cells.Add(cell4);

//            var cell5 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 1, Directions = Directions.East | Directions.South | Directions.North | Directions.West, hasPortal = false };
//            context.Cells.Add(cell5);

//            var cell6 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 1, LocationY = 2, Directions = Directions.East | Directions.North | Directions.West, hasPortal = false };
//            context.Cells.Add(cell6);

//            var cell7 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 0, Directions = Directions.South | Directions.West, hasPortal = false };
//            context.Cells.Add(cell7);

//            var cell8 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 1, Directions = Directions.North | Directions.South | Directions.West, hasPortal = false };
//            context.Cells.Add(cell8);

//            var cell9 = new Cell() { Map = dryLands, CellId = Guid.NewGuid(), Description = "", LocationX = 2, LocationY = 2, Directions = Directions.North | Directions.West, hasPortal = true, GotoMapId = dryLands.MapId, GotoX = 0, GotoY = 0, PortalDescription = "A magical portal. I wonder where it will take you?" };
//            context.Cells.Add(cell9);

//            var defaultAccount = new AlexaAccount() {  AccountId = Guid.Empty, DateCreated = DateTime.UtcNow, LastRequest = DateTime.UtcNow };
//            context.AlexaAccounts.Add(defaultAccount);

//            var defaultPlayer = new Player()
//            {
//                LocationX = 1,
//                LocationY = 1,
//                MapId = dryLands.MapId,
//                Name = "Default Player",
//                Inventory = new List<Inventory>(),
//                AccountRefId = Guid.Empty,
//                Level = 1,
//                Toughness = 0,
//                Gold = 100,
//                Energy = 100
//            };

//            context.Players.Add(defaultPlayer);

//            context.SaveChanges();
//        }
//    }
//}
