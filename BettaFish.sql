CREATE SCHEMA BettaFish; -- new filing cabinet
GO

CREATE TABLE BettaFish.Type (
    tail_ID INT PRIMARY KEY IDENTITY, 
    tailType NVARCHAR (255) NULL,
    description NVARCHAR (4000) NULL 
);

DROP TABLE BettaFish.Type; 
SELECT * FROM BettaFish.Type;
-- SELECT tailType, description FROM BettaFish.Type WHERE tail_ID = 1
-- DELETE FROM BettaFish;

CREATE TABLE BettaFish.Facts (
    fact_ID INT PRIMARY KEY IDENTITY, 
    funFact NVARCHAR (4000) NULL, 
);

DROP TABLE BettaFish.Facts; 
SELECT * FROM BettaFish.Facts;
-- SELECT Fact_ID, funFact FROM BettaFish.Facts;
-- SELECT funFact FROM BettaFish.Facts WHERE fact_ID = 4
-- DELETE FROM BettaFish.Facts;


/*******************************************************************************
   Create Foreign Keys
********************************************************************************/







/*******************************************************************************
   Populate Table 1 
********************************************************************************/
-- Using DML NOW
-- INSERT, UPDATE, DELETE, TRUNCATE data in my tables
-- Use VERB NOUN

-- TABLE 1
INSERT INTO BettaFish.Type (tailType )
VALUES(
    'Veiltail'), ('Crowntail'), ('Combtail'), ('Double Tail'), ('Spadetail'), ('Halfmoon'), ('Over-Halfmoon'), ('Delta'), ('Super Delta'),
    ('Half-Sun'), ('Rosetail'), ('Feathertail '), ('Plakat'), ('Dumbo Ear')

-- Update 
UPDATE BettaFish.Type SET description = 'It has a long , flowing, downwards swooping tail. The name comes from its shimmery and translucent tail, which looks like a veil as the fish swims. ' 
WHERE Tail_ID = 1;

UPDATE BettaFish.Type SET description = 'Named because of the spiky appearance of the fins – just like that on the top of a crown.' 
WHERE Tail_ID = 2;

UPDATE BettaFish.Type SET description = 'Like a crowntail betta, the rays in the tail of a combtail are also longer than its webbing. However, combtails use this feature more subtly. ' 
WHERE Tail_ID = 3;

UPDATE BettaFish.Type SET description = 'A double tail betta has two distinct tails that separate at the base. They also tend to have larger dorsal and anal fins. ' 
WHERE Tail_ID = 4;

UPDATE BettaFish.Type SET description = 'This betta has a caudal fin that looks like a spade, which explains its name. Its tail has a wide base that narrows smoothly.' 
WHERE Tail_ID = 5;

UPDATE BettaFish.Type SET description = 'The Halfmoon betta’s tail has a generous spread of approximately 180 degrees. Its tail looks like a capital letter D.' 
WHERE Tail_ID = 6;

UPDATE BettaFish.Type SET description = 'Over-halfmoon betta fish have similar fins to halfmoon bettas. The difference is that when flared, the caudal fin will fan over 180 degrees creating a shape that is larger than half a circle.' 
WHERE Tail_ID = 7;

UPDATE BettaFish.Type SET description = 'A delta tail starts to narrow towards the body of the betta fish and widens towards the tip. The tail has a triangular shape, which looks like the letter D in the Greek alphabet.' 
WHERE Tail_ID = 8;

UPDATE BettaFish.Type SET description = 'The super delta looks very much like a delta betta. However, the main difference is that a super delta has a flared tail that spans between 120 to 160 degrees.' 
WHERE Tail_ID = 9;

UPDATE BettaFish.Type SET description = 'The half sun betta is a result of selective breeding of crown tail and halfmoon bettas. Its tail has a 180-spread like the halfmoon and an extended caudal fin webbing like the crown tail. ' 
WHERE Tail_ID = 10;

UPDATE BettaFish.Type SET description = 'A rosetail betta is a beautiful variation of the halfmoon. Nonetheless, the biggest difference is that its tail has excessive branching on the rays of the fins. As a result, it creates an overlap, making the tail look like a rose. ' 
WHERE Tail_ID = 11;

UPDATE BettaFish.Type SET description = 'The feather tail has ruffly anal, caudal, and dorsal fins. It is similar to a rose tail, except that the feathertail looks like the betta has gone berserk.' 
WHERE Tail_ID = 12;

UPDATE BettaFish.Type SET description = 'The plakat is a great option if you are looking for small betta species. It has a short fin and a tiny round body. It closely resembles a wild betta rather than those that are bred commercially. ' 
WHERE Tail_ID = 13;

UPDATE BettaFish.Type SET description = 'While not necessarily a tail type, Dumbo ear bettas deserve a spot on this list because of their beauty. It has extra-large pectoral fins that look like elephant ears. ' 
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
    ('Bettas are called fighting fish for a reason. They are highly territorial and males are especially prone to aggression. They cannot be housed together or else they will attack each other.'), 
    ('Their skin contains several layers of pigment, going from red, yellow, black, iridescent (which consists of blue and green), and an outer layer that appears metallic, which changes how the other colors look.'), 
    ('Wild Betta fish tend to be a dull brown and green colour. The will only exhibit the brighter colours mentioned above when they are agitated and will use this as a threat display.'), 
    ('Betta fish living in an aquarium will eat a very varied diet. They can be fed flakes and pellets, as well as live or frozen foods like bloodworm, brine shrimp, and daphnia.'), 
    ('Betta fish have a special organ, known as the labyrinth organ, that allows them to breathe air at the water’s surface.')
