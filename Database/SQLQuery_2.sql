-- Creating My Project_One Database
 -- ////// CREATE Database POne; \\\\\\
-- GO

SELECT * FROM ComputerStore.Computer_Type;

SELECT * FROM ComputerStore.Computer_OS;

SELECT * FROM ComputerStore.Computer_Make;

-- ===== Create Tables ===== 
--CREATE TABLE Computer.Type;
--CREATE Table Computer.OS;
--CREATE TABLE Computer.Price;

---------- CREATE SCHEMA 
--CREATE SCHEMA ComputerStore;
--GO

CREATE TABLE Computer_Type(
    Computer_Type_ID INT IDENTITY PRIMARY KEY,
    Computer_Type_Name NVARCHAR(128) NOT NULL,
);

CREATE TABLE ComputerStore.Computer_OS(
    OS_ID INT IDENTITY PRIMARY KEY,
    OS_Name NVARCHAR(128) NOT NULL
);

CREATE TABLE ComputerStore.Computer_Make(
    Computer_Make_ID INT IDENTITY PRIMARY KEY,
    Computer_Make_Name NVARCHAR(128) NOT NULL,
    Computer_Make_Price SMALLMONEY NOT NULL,
    Computer_Type_ID INT NOT NULL FOREIGN KEY REFERENCES ComputerStore.Computer_Type(Computer_Type_ID) ON UPDATE CASCADE ON DELETE CASCADE,
    Computer_OS_ID INT NOT NULL FOREIGN KEY REFERENCES ComputerStore.Computer_OS(OS_ID) ON UPDATE CASCADE ON DELETE CASCADE
);
-- Renaming the Computer_Price Table
-- EXEC sp_rename 'ComputerStore.Computer_Price', 'Computer_Make';

-- /////// Drop Tables \\\\\\\\
--DROP TABLE ComputerStore.Computer_OS;
--DROP TABLE ComputerStore.Computer_Make;
--DROP TABLE ComputerStore.Computer_Type;

-- /////// INSERT TABLES \\\\\\\
-- Table Type
INSERT INTO 
ComputerStore.Computer_Type(Computer_Type_Name)
VALUES('Desktop'), ('Laptop');

-- Table OS
INSERT INTO 
ComputerStore.Computer_OS(OS_Name)
VALUES('Windows'), ('Mac'), ('Ubuntu');

-- Table Make
INSERT INTO 
ComputerStore.Computer_Make
(Computer_Make_Name, Computer_Type_ID, Computer_OS_ID, Computer_Make_Price)
VALUES
('DELL',1, 1, 800), 
('APPLE', 2, 2, 1000), 
('IBM', 2, 3, 1200), 
('APPLE', 2, 3, 900), 
('LENOVO', 1, 2, 800), 
('SONY', 1, 3, 500); 


