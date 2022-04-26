-- Table Creation

-- Table: ERCOT
CREATE TABLE ERCOT (
    ERCOT_ID INT NOT NULL IDENTITY PRIMARY KEY,
    Year INT NOT NULL,
    Month VARCHAR (20),
    Peak_MegaWatts INT NOT NULL,
    Monthly_Total_Energy INT NOT NULL
);

-- Table: CAISO
CREATE TABLE CAISO (
    CAISO_ID INT NOT NULL IDENTITY PRIMARY KEY,
    Year INT NOT NULL,
    Total_Consumption INT NOT NULL
);

-- Table: NEISO
CREATE TABLE NEISO (
    NEISO_ID INT NOT NULL IDENTITY PRIMARY KEY,
    Forcast_Date DATETIME,
    Hour INT NOT NULL,
    Reliability_Region VARCHAR (40),
    Mega_Watts INT NOT NULL,
);


-- Insert Values
-- Insert for ERCOT
INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'January', 59218, 33434286);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'February', 59429, 29318272);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'March', 53275, 30811374);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'April', 57493, 30794640);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'May', 65858, 35460197);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'June', 72356, 39832001);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'July', 74984, 42870876);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'August', 77579, 43830180);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'September', 71902, 37740895);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'October', 64650, 34123473);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'November', 55240, 31125399);

INSERT INTO dbo.ERCOT (Year, Month, Peak_MegaWatts, Monthly_Total_Energy)
VALUES (2022, 'December', 58667, 33991441);

-- Insert for CAISO
INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2020, 277773);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2021, 280148);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2022, 288989);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2023, 295771);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2024, 302385);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2025, 308646);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2026, 315478);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2027, 322431);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2028, 329045);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2029, 336006);

INSERT INTO dbo.CAISO (Year, Total_Consumption)
VALUES (2030, 343345);

SELECT * FROM dbo.NEISO;