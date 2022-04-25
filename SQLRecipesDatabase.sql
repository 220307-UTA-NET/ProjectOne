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




-- ////////////////////////////////////////////////////////////////////////
     --~~~~~~~~~~~~~~~~~~~~    SELECTS    ~~~~~~~~~~~~~~~~~~~~~--
SELECT DISTINCT username
FROM Recipes.Users;

SELECT *
FROM Recipes.Users;

SELECT username, password, FirstName, LastName 
FROM Recipes.Users 
WHERE username ='kelly0211';



-- ////////////////////////////////////////////////////////////////////////

CREATE TABLE Recipes.Recipe(
RecipeName NVARCHAR(255) PRIMARY KEY,
IngredientID INT NOT NULL,
StepID INT NOT NULL,
Rating NVARCHAR(255)
);

SELECT * 
FROM Recipes.Recipe;

SELECT RecipeName
FROM Recipes.Recipe;

-- ////////////////////////////////////////////////////////////////////////
---------------   Table for Ingredients  ---------------
CREATE TABLE Recipes.Ingredients(
IngredientID  NVARCHAR(255) PRIMARY KEY,
Quantity INT NOT NULL)


---------------   Table for Steps  ---------------
CREATE TABLE Recipes.Steps(
StepNumber INT PRIMARY KEY IDENTITY,
Step NVARCHAR(255)  NOT NULL)
RecipeID


---------------   Table for Steps  ---------------
CREATE TABLE Recipes.ListOfRecipes(
RecipeID INT PRIMARY KEY IDENTITY,
Recipe NVARCHAR(255)  NOT NULL,
)

INSERT INTO Recipes.Recipe (RecipeName, IngredientID, StepsID)  
VALUES
   ('Hot Fudge', 'Ingredients', Steps),
    ('Macarons', Ingredients, Steps);



---------------   DROP TABLES  ---------------
-- DROP TABLE Recipes.Users;
-- DROP TABLE Recipes.Recipes;







----------------------------------------------------------------------
----------------------------------------------------------------------















