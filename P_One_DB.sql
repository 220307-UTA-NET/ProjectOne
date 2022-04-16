CREATE SCHEMA ProjOne; 
GO

CREATE TABLE ProjOne.Player(
    PlayerID INT IDENTITY PRIMARY KEY,
    PlayerName NVARCHAR(100) NOT NULL,
    Trash INT,
    Load INT,
    Moves INT,
);
--DROP TABLE ProjOne.Player
INSERT INTO ProjOne.Player(PlayerName,Trash,Load,Moves)
VALUES
('Daniel',0,0,0),
('Elliott',0,0,0)


CREATE TABLE ProjOne.PlayerInventory(
    PlayerID INT PRIMARY KEY
    CONSTRAINT FK_PlayerID_Inventory FOREIGN KEY (PlayerID)
        REFERENCES ProjOne.Player(PlayerID) ON DELETE CASCADE,
    ItemID1 INT,
    ItemID2 INT,
    ItemID3 INT,
    ItemID4 INT,
    ItemID5 INT
);
--DROP TABLE ProjOne.PlayerInventory


CREATE TABLE ProjOne.Items(
    ItemID INT IDENTITY PRIMARY KEY, 
    ItemName NVARCHAR(255) NOT NULL,
    ItemWeight INT,    
);
--DROP TABLE ProjOne.Items

INSERT INTO ProjOne.Items(ItemName, ItemWeight)
VALUES
('Jar', 2),
('Bedsheets', 2),
('Towel', 2),
('Book', 1),
('Lamp', 3),
('Hat', 1),
('Shirt', 2),
('Pants', 2),
('Papers', 1),
('Box', 1),
('Mail', 1),
('Old Food', 1),
('Slippers', 1),
('Wooden Scraps', 3);


CREATE TABLE ProjOne.Room(
    RoomID INT IDENTITY PRIMARY KEY,
    RoomName NVARCHAR(255) NOT NULL,
    RoomDetails NVARCHAR(255) NOT NULL,
    AdjRoomID1 INT NOT NULL,
    AdjRoomID2 INT,
    AdjRoomID3 INT,
);
--DROP TABLE ProjOne.Room

INSERT INTO ProjOne.Room(RoomName, RoomDetails, AdjRoomID1, AdjRoomID2, AdjRoomID3)
VALUES
('Entryway', 'You enter the house into small dark room, the floor is very muddy, and the door does not close behind you.', 2, 0, 0),
('Hallway', 'This long narrow space is cramped and could not fit two people abreast. How did anyone get furniture in here?', 1, 3, 0),
('Living Room', 'A well worn room with a sad looking couch and rustic coffee table. You watch a cockroach skitter across the cushions.', 2, 4, 5),
('Kitchen', 'The linoleum tile is hideous and outdated. The stove is covered in burned food remains.', 3, 5, 7),
('Dining Room', 'Two sad chairs sit on either side of a table badly in need of a face-lift', 4, 6, 0),
('Half Bathroom', 'Your stomach turns as you enter this room. You make a mental reminder to burn your clothes when you get home.', 3, 5, 0),
('Stairway', 'You do not know if the stairs will be harder to go upr or down. You do know they will creak and squeak under and weight.', 4, 8, 7),
('Upstairs Hallway', 'You feel off-kilter and realize this floor is incredibly un-level.', 7,9,10),
('Small Bedroom', 'Looks more like a prison cell than a bedroom.  Are those bars on the window?', 8,0,0),
('Master Bedroom', 'Barely larger than the previous room, but there is carpet. On second though that should also be burned.',8,11,0),
('Master Bathroom', 'The only place to bath requires you to go through a bedroom? Who designed this house>',10,0,0)

SELECT * FROM ProjOne.Player5RoomItems
--SELECT FLOOR(RAND()*(b-a+1))+a;
/*INSERT INTO ProjOne.Player1RoomItems(RoomID, ItemID1, ItemID2, ItemID3)
VALUES
(1, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0),
(2, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0),
(3, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0, FLOOR(RAND()*(14-0+1))+0)

SELECT * FROM ProjOne.Items INNER JOIN ProjOne.RoomInventory ON Items.ItemID=RoomInventory.ItemID3 WHERE ProjOne.RoomInventory.RoomID=2
SELECT * FROM ProjOne.Room

UPDATE ProjOne.Room
SET AdjRoomID3=0
WHERE RoomName='Stairway'

CREATE TABLE ProjOne.Player1RoomItems(RoomID INT PRIMARY KEY CONSTRAINT FK_Player_RoomID_Inventory FOREIGN KEY (RoomID) REFERENCES ProjOne.Room(RoomID) ON DELETE CASCADE,ItemID1 INT,ItemID2 INT,ItemID3 INT,)

SELECT * FROM ProjOne.Player118roomItems 
SELECT * FROM ProjOne.Player ORDER BY PlayerID DESC
DELETE FROM ProjOne.Player

UPDATE ItemID2.VALUE FROM ProjOne.Player1RoomItems WHERE RoomID=3 

UPDATE ProjOne.Player1RoomItems SET ItemID2=0 WHERE RoomID=3

SELECT * FROM ProjOne.Player105RoomItems WHERE RoomID =2
DROP SCHEMA ProjOne
DROP TABLE ProjOne.Player
DROP TABLE ProjOne.Room
DROP TABLE ProjOne.Items
DROP TABLE ProjOne.PlayerInventory*/