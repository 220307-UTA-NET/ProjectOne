CREATE TABLE Customers(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    UserName VARCHAR(255) NOT NULL,
    NumGames INT DEFAULT 0
);

Alter TABLE Customers ADD NumGames INT;
DROP TABLE Customers;

CREATE TABLE IndieGames(
    ProductID INT IDENTITY(1,1),
    GameName VARCHAR(255),
    Price INT,
    AmountSold INT,
    TotalMade INT DEFAULT 0
);

DROP TABLE IndieGames;

SELECT * FROM IndieGames;

INSERT INTO IndieGames(GameName, Price, AmountSold)
VALUES('Come 4 Alive', 30, 0);

SELECT SUM(Price * AmountSold) as total
FROM IndieGames;

SELECT * FROM Customers;

CREATE TABLE GAMESALES(
    CustomerID INT,

);



INSERT INTO Customers(UserName)
VALUES('Tec16');