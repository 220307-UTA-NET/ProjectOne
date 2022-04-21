CREATE SCHEMA OlympicGames;
GO

CREATE TABLE OlympicGames.About
(
    Description_ID INT IDENTITY PRIMARY KEY,
    Description_Info VARCHAR(1500),
    Description_Author VARCHAR(55),
    Description_Date DATE DEFAULT getdate(),
    Description_Resource VARCHAR(100),
);

INSERT INTO OlympicGames.About(Description_Info,Description_Author,Description_Resource) 
VALUES ("This Olympic Games Web Application is designed to showcase gold, silver, and bronze medals from the 1896 - 2022 Summer and Winter Olympic seasons in various formats as well as individual country or competitor specifics. It uses a variety of API calls to accomplish this, and the web application database is filled with information from the Wikipedia source.","Austin Hickman","https://en.wikipedia.org/wiki/All-time_Olympic_Games_medal_table"),
("An Olympic medal is awarded to successful competitors at one of the Olympic Games. There are three classes of medal to be won: gold, silver, and bronze, awarded to first, second, and third place, respectively. Medal designs have varied considerably since the Games in 1896, particularly in the size of the medals for the Summer Olympic Games. The design selected for the 1928 Games remained for many years, until its replacement at the 2004 Games in Athens as the result of controversy surrounding the use of the Roman Colosseum rather than a building representing Greek roots. The medals of the Winter Olympic Games never had a common design, but regularly feature snowflakes and the event where the medal has been won.  First place (the gold medal): It is composed of at least 92.5% of silver, plated with 6 grams of gold; the medal at current prices is worth about $800.  Second place (the silver medal): It is composed of at least 92.5% silver; the medal at current prices is worth $460.  Third place (the bronze medal): It is composed of at least 97% copper with 0.5% tin and 2.5% zinc; the medal at current prices is woth $5.","none","none");

CREATE TABLE OlympicGames.Consumer
(
 C_ID INT IDENTITY PRIMARY KEY,
 C_Name VARCHAR(255) NOT NULL,
)

INSERT INTO OlympicGames.Consumer(C_Name) VALUES ("Bob Saget");

CREATE TABLE OlympicGames.Countries
(
  ID INT IDENTITY PRIMARY KEY,
  Country_Name varchar(100),
  Gold_Medals INT,
  Silver_Medals INT,
  Bronze_Medals INT,
  Total INT
);

INSERT INTO OlympicGames.Countries(Country_Name,Gold_Medals,Silver_Medals,Bronze_Medals,Total)
VALUES
("United States",1173,953,833,2959),
("USSR",473,376,355,1204),
("Germany",305,305,312,922),
("Great Britain",296,323,331,950),
("China",284,231,196,711),
("France",265,293,332,889),
("Italy",259,231,269,759),
("Sweden",213,227,239,679),
("Norway",210,184,174,568),
("Russia",196,165,186,547);