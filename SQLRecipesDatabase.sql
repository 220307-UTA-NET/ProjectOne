CREATE SCHEMA Recipes;
GO

CREATE TABLE Recipes.Users(
username NVARCHAR(255) PRIMARY KEY,
password NVARCHAR(255)NOT NULL,
FirstName NVARCHAR(255)NOT NULL,
LastName NVARCHAR(255)NOT NULL
);
-- DROP TABLE Recipes.Users;
-- DELETE FROM Recipes.Users();

INSERT INTO Recipes.Users (username, password, FirstName, LastName)  
VALUES
    ('kelly0211', 'password', 'Kelly', 'Keng'),
    ('myNewUserName', 'password', 'FName', 'LName');

SELECT username
FROM Recipes.Users;

SELECT *
FROM Recipes.Users;



