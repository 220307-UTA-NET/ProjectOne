CREATE SCHEMA BettaFish; -- new filing cabinet
GO

--Table 1
CREATE TABLE BettaFish.Type (
    tail_ID INT PRIMARY KEY IDENTITY, 
    tailType NVARCHAR (255) NULL,
    description NVARCHAR (4000) NULL 
);

-- DROP TABLE BettaFish.Type; 
SELECT * FROM BettaFish.Type;
-- DELETE FROM BettaFish;
SELECT tail_ID,  tailType FROM BettaFish.Type
SELECT TOP 1 * FROM BettaFish.Type ORDER BY tail_ID 
SELECT * FROM BettaFish.Type WHERE tail_ID = 0
SELECT tail_ID FROM BettaFish.Type
SELECT TOP 14 * FROM BettaFish.Type ORDER BY tail_ID

-- Table 2
CREATE TABLE BettaFish.Facts (
    fact_ID INT PRIMARY KEY IDENTITY, 
    funFact NVARCHAR (4000) NULL, 
);

-- DROP TABLE BettaFish.Facts; 
SELECT * FROM BettaFish.Facts;
-- SELECT Fact_ID, funFact FROM BettaFish.Facts;
-- SELECT funFact FROM BettaFish.Facts WHERE fact_ID = 4
-- DELETE FROM BettaFish.Facts;



--Table 3
CREATE TABLE BettaFish.Registration (
    registration_ID INT PRIMARY KEY IDENTITY, -- creates a unique value that changes with every entry in the table
    fName NVARCHAR (255) NOT NULL,
    lName NVARCHAR (255) NOT NULL,
    email NVARCHAR (255) NOT NULL,
);

DROP TABLE BettaFish.Registration;
SELECT * FROM BettaFish.Registration;


-- Table 4
CREATE TABLE BettaFish.Stories (
    story_ID INT PRIMARY KEY IDENTITY, -- creates a unique value that changes with every entry in the table
    nameOfBetta NVARCHAR (255) NOT NULL,
    story NVARCHAR (3000) NOT NULL,
);

DROP TABLE BettaFish.Stories;
SELECT * FROM BettaFish.Stories;

-- Table 5
CREATE TABLE BettaFish.Stores (
    store_ID INT PRIMARY KEY IDENTITY, -- creates a unique value that changes with every entry in the table
    storeName NVARCHAR (255) NULL,
    storeAddress NVARCHAR (255) NULL,
);

-- DROP TABLE BettaFish.Stores;
SELECT * FROM BettaFish.Stores;


/*******************************************************************************
   Create Foreign Keys
********************************************************************************/
-- link the table EternalFlowStore.Location to referenece EternalFlowStore.Customers through Location_ID with Customer_ID
--ALTER TABLE BettaFish.Registration
    --ADD CONSTRAINT FK__Location__Location_ID FOREIGN KEY ( Location_ID )
        --REFERENCES EternalFlowStore.Customers (Customer_ID)


/*******************************************************************************
   Populate Table 1 
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 1
INSERT INTO BettaFish.Type ( tailType )
VALUES(
    'Veiltail'), ('Crowntail'), ('Combtail'), ('Double Tail'), ('Spadetail'), ('Halfmoon'), ('Over-Halfmoon'), ('Delta'), ('Super Delta'),
    ('Half-Sun'), ('Rosetail'), ('Feathertail '), ('Plakat'), ('Dumbo Ear')

-- Update 
UPDATE BettaFish.Type SET description = 'It has a long , flowing, downwards swooping tail, shimmery and translucent tail, which looks like a veil as the fish swims. ' 
WHERE Tail_ID = 1;

UPDATE BettaFish.Type SET description = 'Named because of the spiky appearance of the fins – just like that on the top of a crown.' 
WHERE Tail_ID = 2;

UPDATE BettaFish.Type SET description = 'Like a crowntail betta, the rays in the tail of a combtail are also longer than its webbing.' 
WHERE Tail_ID = 3;

UPDATE BettaFish.Type SET description = 'A double tail betta has two distinct tails that separate at the base. They also tend to have larger dorsal and anal fins. ' 
WHERE Tail_ID = 4;

UPDATE BettaFish.Type SET description = 'This betta has a caudal fin that looks like a spade, which explains its name. Its tail has a wide base that narrows smoothly.' 
WHERE Tail_ID = 5;

UPDATE BettaFish.Type SET description = 'The Halfmoon betta’s tail has a generous spread of approximately 180 degrees. Its tail looks like a capital letter D.' 
WHERE Tail_ID = 6;

UPDATE BettaFish.Type SET description = 'Over-halfmoon betta fish have similar fins to halfmoon bettas. The caudal fin will fan over 180 degrees creating a shape that is larger than half a circle.' 
WHERE Tail_ID = 7;

UPDATE BettaFish.Type SET description = 'The tail has a triangular shape, which looks like the letter D in the Greek alphabet.' 
WHERE Tail_ID = 8;

UPDATE BettaFish.Type SET description = 'The super delta looks very much like a delta betta. However, the main difference is that a super delta has a flared tail that spans between 120 to 160 degrees.' 
WHERE Tail_ID = 9;

UPDATE BettaFish.Type SET description = 'The half sun betta is a result of selective breeding of crown tail and halfmoon bettas.' 
WHERE Tail_ID = 10;

UPDATE BettaFish.Type SET description = 'A rosetail betta is a beautiful variation of the halfmoon.'
WHERE Tail_ID = 11;

UPDATE BettaFish.Type SET description = 'The feather tail has ruffly anal, caudal, and dorsal fins. It is similar to a rose tail, except that the feathertail looks like the betta has gone berserk.' 
WHERE Tail_ID = 12;

UPDATE BettaFish.Type SET description = 'The plakat is a great option if you are looking for small betta species. It has a short fin and a tiny round body. It closely resembles a wild betta.' 
WHERE Tail_ID = 13;

UPDATE BettaFish.Type SET description = 'Dumbo ear bettas deserve a spot on this list because of their beauty. It has extra-large pectoral fins that look like elephant ears. ' 
WHERE Tail_ID = 14;

/*******************************************************************************
   Populate Table 2
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 2
INSERT INTO BettaFish.Facts (funFact )
VALUES(
    'There are approximately 70 Species of betta fish.'), 
    ('Betta fish are named after warriors.'), 
    ('They orginate from Southeast Asia. The fish are native to the Mekong River Basin in Cambodia, Laos, Thailand and Vietnam.'), 
    ('Males are highly territorial, especially prone to aggression. They will attack each other if they are housed together.'), 
    ('Their skin contains several layers of pigment, going from red, yellow, black, iridescent (which consists of blue and green).'), 
    ('Wild Betta fish tend to be a dull brown and green colour.'), 
    ('Betta fish living in an aquarium will eat a very varied diet. They can be fed flakes and pellets, as well as live or frozen foods like bloodworm, brine shrimp, and daphnia.'), 
    ('Betta fish have a special organ, known as the labyrinth organ, that allows them to breathe air at the water’s surface.')

/*******************************************************************************
   Populate Table 3
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 3
INSERT INTO BettaFish.Registration (fName,lName,email) VALUES ('fName', 'lName', 'email');

/*******************************************************************************
   Populate Table 4
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN


/*******************************************************************************
   Populate Table 5
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 5
INSERT INTO BettaFish.Stores (storeName)
VALUES(
     'PetSmart'), ('Petco'), ('Betta Madness'), ('Aqualand Aquarium Center'), ('Tamed Waters'), ('Sonnen Pet Shop'), ('Quality Aquatics Shop')


UPDATE BettaFish.Stores SET storeAddress = '2304 Bedok Reservoir Road Bedok Industrial Park, Ontario CA 94232' WHERE store_ID = 1;
UPDATE BettaFish.Stores SET storeAddress = '1675 Parkway Street, Rochester, MN 55904' WHERE store_ID = 2;
UPDATE BettaFish.Stores SET storeAddress = '4414 Denver Avenue, Bridge City, TX 85423' WHERE store_ID = 3;
UPDATE BettaFish.Stores SET storeAddress = '1149 Canis Heights Drive, Rapid City, IL 65321' WHERE store_ID = 4;
UPDATE BettaFish.Stores SET storeAddress = '3859 Patterson Road, Woodland Hills CA 91337' WHERE store_ID = 5;
UPDATE BettaFish.Stores SET storeAddress = '1623 Bailey Drive, Milwaukee WI 32422' WHERE store_ID = 6;
UPDATE BettaFish.Stores SET storeAddress = '3463 Weekley Street, Miami FL 56942' WHERE store_ID = 7;