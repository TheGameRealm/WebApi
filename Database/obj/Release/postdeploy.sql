/* Post-Deployment Script Template */

/* Clear Data */
DELETE Inventory;
DELETE Players;
DELETE AlexaRequests;
DELETE AlexaAccounts;

DELETE CellItems;
DELETE Cells;
DELETE Maps;

DELETE Items;
DELETE Configs;

/* Set Direction Values */
DECLARE @None int = 0;
DECLARE @N int = 1; /* North */
DECLARE @E int = 2; /* East */
DECLARE @S int = 4; /* South */
DECLARE @W int = 8; /* West */

/* Set Map Id's */
DECLARE @dryLandsMapId uniqueidentifier = NEWID();
DECLARE @forgottenValleyMapId uniqueidentifier = NEWID();
DECLARE @CalteraMapId uniqueidentifier = NEWID();
DECLARE @CalteraRidgeMapId uniqueidentifier = NEWID();
DECLARE @WindPortMapId uniqueidentifier = NEWID();

/* Populate Maps */
INSERT INTO Maps (MapId, Name, [Level], [Description]) Values (@dryLandsMapId, 'Dry Lands', 0, 'This is an arid dead land. You shoud move on before you die of thirst.');
INSERT INTO Maps (MapId, Name, [Level], [Description]) Values (@forgottenValleyMapId, 'Forgotten Valley', 0, 'The area is covered with dense jungle and the smell of decay.');
INSERT INTO Maps (MapId, Name, [Level], [Description]) Values (@CalteraMapId, 'Caltera', 0, 'The land is mostly flat and full of vegetation.');
INSERT INTO Maps (MapId, Name, [Level], [Description]) Values (@CalteraRidgeMapId, 'Caltera Ridge', 0, 'The flat lands have given way to the hills. This area seems more wild and dangerous.');
INSERT INTO Maps (MapId, Name, [Level], [Description]) Values (@WindPortMapId, 'WindPort', 0, 'Your in a small nearly abandoned village.');

/* Populate Map: Dry Lands */
DECLARE @Cell1 uniqueidentifier = NEWID();
DECLARE @Cell2 uniqueidentifier = NEWID();
DECLARE @Cell3 uniqueidentifier = NEWID();
DECLARE @Cell4 uniqueidentifier = NEWID();

INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (NewId(), 'You''re at the north western corner of the Dry Lands.',	(@E + @S),			 @dryLandsMapId, 0, 0);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (@Cell1,  'You''re at the northern edge of the Dry Lands.',			(@W + @E + @S),		 @dryLandsMapId, 1, 0);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY, PortalDirections, GotoMapRefId, GotoX, GotoY)	VALUES (NewId(), 'You''re at the north eastern corner of the Dry Lands.',	(@E + @W + @S),		 @dryLandsMapId, 2, 0, @E, @dryLandsMapId, 2, 2);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (NewId(), 'You''re at the western edge of the Dry Lands.',			(@N + @E + @S),		 @dryLandsMapId, 0, 1);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (@Cell2,  'You''re deep in the Dry Lands.',							(@N + @E + @S + @W), @dryLandsMapId, 1, 1);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (@Cell3,  'You''re at the eastern edge of the Dry Lands.',			(@N + @S + @W),		 @dryLandsMapId, 2, 1);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY, PortalDirections, GotoMapRefId, GotoX, GotoY)	VALUES (@Cell4,  'Your''re at the south western corner of the Dry Lands.',	(@N + @E),			 @dryLandsMapId, 0, 2, @W, @dryLandsMapId, 2, 0);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (NewId(), 'You''re at the southern edge of the Dry Lands.',			(@N + @E + @W),		 @dryLandsMapId, 1, 2);
INSERT INTO Cells (CellId, [Description], Directions, MapRefId, LocationX, LocationY)												VALUES (NewId(), 'Your''re at the south eastern corner of the Dry Lands.',	(@N + @E + @W),		 @dryLandsMapId, 2, 2);

/* Create Default Alexa Account for Default Player Template*/
INSERT INTO AlexaAccounts (AccountId, DateCreated, RequestCount, LastRequest) VALUES ('00000000-0000-0000-0000-000000000000', GetDate(), 0, GetDate());

/* Create Default Player Template */
INSERT INTO Players(PlayerId, AccountRefId, Name, Gold, Energy, Toughness, [Level], MapRefId, LocationX, LocationY, Verbosity) 
	VALUES ('00000000-0000-0000-0000-000000000000', '00000000-0000-0000-0000-000000000000', 'Player', 100, 100, 0, 1, @dryLandsMapId, 1, 1, 7);

DECLARE @Item1 uniqueidentifier = NEWID();
INSERT Items (ItemId, Name, [Description]) VALUES (@Item1, 'Rock', 'A small rock.');
DECLARE @Item2 uniqueidentifier = NEWID();
INSERT Items (ItemId, Name, [Description]) VALUES (@Item2, 'Knife', 'A rusty old dagger');
DECLARE @Item3 uniqueidentifier = NEWID();
INSERT Items (ItemId, Name, [Description]) VALUES (@Item3, 'Coin', 'A gold coin.');
DECLARE @Item4 uniqueidentifier = NEWID();
INSERT Items (ItemId, Name, [Description]) VALUES (@Item4, 'Sword', 'A common iron sword.');

INSERT INTO CellItems (CellItemId, ItemRefId, CellRefId) Values (NewId(), @Item1, @Cell1);
INSERT INTO CellItems (CellItemId, ItemRefId, CellRefId) Values (NewId(), @Item1, @Cell2);
INSERT INTO CellItems (CellItemId, ItemRefId, CellRefId) Values (NewId(), @Item1, @Cell3);
INSERT INTO CellItems (CellItemId, ItemRefId, CellRefId) Values (NewId(), @Item1, @Cell4);
GO
