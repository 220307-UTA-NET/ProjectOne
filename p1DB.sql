-- Create Schema
CREATE SCHEMA p1;
GO

-- Drop Schema
--DROP SCHEMA IF EXISTS p1;

-- Create Table - p1.Location
CREATE TABLE p1.Location (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    City VARCHAR(40)
        CHECK(LEN(City) > 0),
    State VARCHAR(40)
        CHECK(LEN(State) > 0),
    Country VARCHAR(40) NOT NULL
        CHECK(LEN(Country) > 0)
);

-- Drop Table - p1.Location
--DROP TABLE p1.Location;

-- Create Table - p1.Employee
CREATE TABLE p1.Employee (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName VARCHAR(40) NOT NULL
        CHECK(LEN(FirstName) > 0),
    LastName VARCHAR(40) NOT NULL
        CHECK(LEN(LastName) > 0),
    BirthDate DATE NOT NULL,
    BranchId INT NOT NULL
        FOREIGN KEY REFERENCES p1.Location (Id) ON UPDATE CASCADE ON DELETE CASCADE,
    Department VARCHAR(40) NOT NULL,
    Title VARCHAR(40) NOT NULL,
    HiredDate DATE NOT NULL,
        CHECK (HiredDate > BirthDate)
);

-- Drop Table - p1.Employee
--DROP TABLE p1.Employee;

-- Populate Table - p1.Location
INSERT INTO p1.Location (City, State, Country)
VALUES
    ('Anaheim', 'California', 'United States'),
    ('Orlando', 'Florida', 'United States'),
    ('Urayasu', 'Chiba', 'Japan');

-- Populate Table - p1.Employee
INSERT INTO p1.Employee (FirstName, LastName, BirthDate, BranchId, Department, Title, HiredDate)
VALUES
    ('Mickey', 'Mouse', '1928-11-18', 1, 'Marketing', 'Brand Ambassador', '1948-02-28'),
    ('Minnie', 'Mouse', '1928-11-18', 1, 'Product Management', 'Chief Product Officer', '1948-03-03'),
    ('Donald', 'Duck', '1934-06-09', 2, 'Human Resources', 'Training Manager', '1953-01-30'),
    ('Daisy', 'Duck', '1940-06-07', 3, 'Administrative', 'Administrative Director', '1954-10-22'),
    ('Goofy', 'Goof', '1932-05-25', 2, 'Electrical Engineering', 'Chief Engineer', '1955-04-15');

-- Show Tables
SELECT * FROM p1.Employee;
SELECT * FROM p1.Location;