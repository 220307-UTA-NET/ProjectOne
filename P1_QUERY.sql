CREATE SCHEMA Horoscope;
GO 

CREATE TABLE Horoscope.Client (
USER_ID INT NOT NULL PRIMARY KEY IDENTITY,
ZODIAC_SIGN NVARCHAR (255) NOT NULL,
FIRST_NAME VARCHAR (255) NOT NULL,
LAST_NAME VARCHAR (255) NOT NULL,
BIRTH_DATE NVARCHAR (31) NOT NULL,
PHONE_NUMBER NVARCHAR (255) NOT NULL,
CHECK (LEN(FIRST_NAME)>0),
CHECK (LEN(LAST_NAME)>0)
);

ALTER TABLE Horoscope.Client
ADD 



-- ALTER TABLE Horoscope.Capricorn
-- ADD CONSTRAINT FK_CLIENT_CAPRICORN
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Aquarius
-- ADD CONSTRAINT FK_CLIENT_AQUARIUS
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;

-- ALTER TABLE Horoscope.Pisces
-- ADD CONSTRAINT FK_CLIENT_PISCES
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;

-- ALTER TABLE Horoscope.Aries
-- ADD CONSTRAINT FK_CLIENT_ARIES
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;

-- ALTER TABLE Horoscope.Taurus
-- ADD CONSTRAINT FK_CLIENT_TAURUS
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;

-- ALTER TABLE Horoscope.Gemini
-- ADD CONSTRAINT FK_CLIENT_GEMINI
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Cancer
-- ADD CONSTRAINT FK_CLIENT_CANCER
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Leo
-- ADD CONSTRAINT FK_CLIENT_LEO
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Virgo
-- ADD CONSTRAINT FK_CLIENT_VIRGO
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;



-- ALTER TABLE Horoscope.Libra
-- ADD CONSTRAINT FK_CLIENT_LIBRA
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Scorpio
-- ADD CONSTRAINT FK_CLIENT_SCORPIO
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;


-- ALTER TABLE Horoscope.Sagittarius
-- ADD CONSTRAINT FK_CLIENT_SAGITTARIUS
-- FOREIGN KEY (USER_ID)
-- REFERENCES
-- Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;

-- --Drop Table Horoscope.Client

-- CREATE TABLE Horoscope.Capricorn (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Capricorn

-- CREATE TABLE Horoscope.Aquarius (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Aquarius

-- CREATE TABLE Horoscope.Pisces (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Pisces

-- CREATE TABLE Horoscope.Aries (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Aries

-- CREATE TABLE Horoscope.Taurus (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Taurus

-- CREATE TABLE Horoscope.Gemini (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Gemini

-- CREATE TABLE Horoscope.Cancer (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Cancer

-- CREATE TABLE Horoscope.Leo (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Leo

-- CREATE TABLE Horoscope.Virgo (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Virgo

-- CREATE TABLE Horoscope.Libra (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Libra

-- CREATE TABLE Horoscope.Scorpio (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

-- --Drop Table Horoscope.Scorpio

-- CREATE TABLE Horoscope.Sagittarius (
--  USER_ID INT NOT NULL PRIMARY KEY,  
-- DATE_RANGE NVARCHAR (40) NOT NULL,
-- SIGN_READING NVARCHAR (4000) NOT NULL,
-- READING_DATE NVARCHAR (255) NOT NULL,
-- );

--Drop Table Horoscope.Sagittarius

CREATE TABLE Horoscope.UserZodiac (
USER_ID INT NOT NULL,
ZODIAC_SIGN NVARCHAR (255) NOT NULL,
TODAYS_READING NVARCHAR (4000) NOT NULL,
TOMORROWS_READING NVARCHAR (4000) NOT NULL,
YESTERDAYS_READING NVARCHAR (4000) NOT NULL,
SAVED_READINGS NVARCHAR (4000) NOT NULL,
);

ALTER TABLE Horoscope.UserZodiac
ADD CONSTRAINT FK__Client__USER_ID
FOREIGN KEY (USER_ID) 
REFERENCES Horoscope.Client (USER_ID) ON DELETE CASCADE ON UPDATE CASCADE;



INSERT INTO Horoscope.UserZodiac
VALUES
    ('Capricorn'),
    ('Aquarius'),
    ('Pisces'),
    ('Aries'),
    ('Taurus'),
    ('Gemini'),
    ('Cancer'),
    ('Leo'),
    ('Virgo'),
    ('Libra'),
    ('Scorpio'),
    ('Sagittarius');



  'Aquarius', 'Pisces', 'Aries', 'Taurs', 'Gemini', 'Cancer', 'Leo', 'Virgo', 'Libra', 'Scorpio', 'Sagittarius');

--Drop Table Horoscope.UserZodiac

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Capricorn', 'Brandon', 'Smith', 'Jan-2nd', '281-221-6315');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Aquarius', 'Ally', 'Johnson', 'Feb-15th', '781-614-9001');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Pisces', 'Rachel', 'Hope', 'Mar-5th', '956-455-1801');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Aries', 'Alexa', 'Wayne', 'Apr-11th', '628-981-5624');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Taurus', 'Brian', 'Griffin', 'May-7th', '411-900-6218');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Gemini', 'Juan', 'Garza', 'Jun-10th', '956-612-8212');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Cancer', 'Felipe', 'Loera', 'Jul-15th', '210-588-6112');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Leo', 'Ashley', 'Styles', 'Aug-18th', '584-200-7717');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Virgo', 'Karla', 'Cantu', 'Sep-2nd', '772-441-6262');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Libra', 'Buck', 'Hunter', 'Oct-17th', '644-944-2121');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Scorpio', 'Jennifer', 'Chills', 'Nov-6th', '554-281-9242');

INSERT INTO Horoscope.Client
(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER) 
VALUES ('Sagittarius', 'Aure', 'Silva', 'Dec-4th', '956-584-9912');