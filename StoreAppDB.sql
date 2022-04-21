-- CREATE SCHEMA StoreApp;
-- GO

--------------------------------------------------------------
------------------------- DROP TABLES ------------------------
--------------------------------------------------------------
-- DROP TABLE StoreApp.Product;
-- DROP TABLE StoreApp.Store;
-- DROP TABLE StoreApp.Customer;
-- DROP TABLE StoreApp.Orders;

/*
CREATE TABLE StoreApp.Store( 
    ID INT PRIMARY KEY IDENTITY(400,2),
    Address NVARCHAR (255),
    InventoryID INT NULL
);
*/

/*
CREATE TABLE StoreApp.Product( 
    ProductID INT PRIMARY KEY IDENTITY(100,2),
    ProductType NVARCHAR (255),
    ProductName NVARCHAR (255),
    Quantity INT NULL,
    Cost DECIMAL(38, 2) NULL
);
*/

/*
CREATE TABLE StoreApp.Customer(
    CustomerID INT NOT NULL PRIMARY KEY,
    FirstName NVARCHAR (255),
    LastName NVARCHAR (255),
    PhoneNumber NVARCHAR (255),
    Zipcode NVARCHAR (255)
);
*/



/*
CREATE TABLE StoreApp.Orders( 
    OrderID INT PRIMARY KEY IDENTITY(6002, 2),
    CustomerID INT,
    ProductID INT,
    Location NVARCHAR (255),
    Time DATE NULL
);
*/


---------------------------------------------------------------------------
-------------------------- INSERTION --------------------------------------
---------------------------------------------------------------------------

INSERT INTO StoreApp.Product (ProductType, ProductName, Quantity, Cost) VALUES
('Cell phone', 'Pixel 6', 4, 564.85),
('Cell phone', 'Pixel 6', 5, 564.85),
('Cell phone', 'Pixel 6', 3, 564.85),
('Cell phone', 'Iphone 13', 6, 743.50),
('Cell phone', 'Iphone 13', 4, 743.50),
('Cell phone', 'Iphone 13', 1, 743.50),
('Cell phone', 'Iphone 13', 2, 743.50),
('Cell phone', 'Motorola One', 3, 175.99),
('Cell phone', 'Iphone 11', 6, 583.99),
('Cell phone', 'Iphone 11', 8, 583.99),
('Cell phone', 'Samsung Galaxy S21', 8, 850.99 ),
('Cell phone', 'Samsung Galaxy S21', 5, 850.99 ),
('Cell phone', 'Samsung Galaxy S9', 4, 599.99 ),
('Cell phone', 'LG K22', 10, 889.99),
('Cell phone', 'LG K22', 8, 889.99),
('Cell phone', 'LG K31', 3, 999.99),
('T.V', 'TCL QLED', 7, 449.99),
('T.V', 'Sony X85J', 4, 699.99),
('T.V', 'Sony X85J', 6, 699.99),
('T.V', 'Sony X85J', 4, 699.99),
('T.V', 'LG C1', 10, 1149),
('T.V', 'LG GX', 8, 999.99),
('T.V', 'Vizio OLED', 11, 799.99),
('T.V', 'Samsung Q90', 6, 1499.99),
('T.V', 'Samsung Q90', 5, 1499.99),
('T.V', 'Hisense U6G', 5, 599.99),
('T.V', 'Hisense U9DG', 3, 699.99);


INSERT INTO StoreApp.Store(Address, InventoryID) VALUES
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 100)),
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 110)),
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 120)),
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 130)),
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 140)),
('12 Orchestra Terrace Germantown 99362', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 150)),

('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 102)),
('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 112)),
('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 122)),
('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 132)),
('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 142)),
('89 Jefferson Way Portland	97201', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 152)),

('87 Polk St San Francisco 94117', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 104)),
('87 Polk St San Francisco 94117', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 114)),
('87 Polk St San Francisco 94117', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 124)),
('87 Polk St San Francisco 94117', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 134)),
('87 Polk St San Francisco 94117', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 144)),

('722 DaVinci Blvd Kirkland 98034', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 106)),
('722 DaVinci Blvd Kirkland 98034', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 116)),
('722 DaVinci Blvd Kirkland 98034', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 126)),
('722 DaVinci Blvd Kirkland 98034', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 136)),
('722 DaVinci Blvd Kirkland 98034', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 146)),

('50 Chiro Rd Portland 97219', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 108)),
('50 Chiro Rd Portland 97219', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 118)),
('50 Chiro Rd Portland 97219', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 128)),
('50 Chiro Rd Portland 97219', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 138)),
('50 Chiro Rd Portland 97219', (SELECT ProductID FROM StoreApp.Product WHERE ProductID = 148));


INSERT INTO StoreApp.Customer(CustomerID, FirstName, LastName, PhoneNumber, Zipcode) VALUES
(1000, 'Adja', 'Fof', '234524', '1243'),
(1002, 'Amed', 'York', '948321', '9472'),
(1004, 'Adja', 'Kante', '993242', '1243'),
(1006, 'Fakoly', 'Keith', '938245', '4329'),
(1008, 'Nabelle', 'Lee', '568321', '1276'),
(1010, 'Bibi', 'Malika', '349582', '8734'),
(1012, 'Fatou', 'Yanks', '738203', '1276'),
(1014, 'Adams', 'Keith', '123234', '1134');

INSERT INTO StoreApp.Orders(CustomerID, ProductID, Location, Time) VALUES
(1000, 100, '12 Orchestra Terrace Germantown 99362', (SELECT CURRENT_TIMESTAMP)),
(1002, 102, '89 Jefferson Way Portland	97201', (SELECT CURRENT_TIMESTAMP)),
(1006, 106, '87 Polk St San Francisco 94117', (SELECT CURRENT_TIMESTAMP)),
(1008, 108, '722 DaVinci Blvd Kirkland 98034', (SELECT CURRENT_TIMESTAMP)),
(1010, 110, '50 Chiro Rd Portland 97219', (SELECT CURRENT_TIMESTAMP)),
(1012, 112, '12 Orchestra Terrace Germantown 99362', (SELECT CURRENT_TIMESTAMP)),
(1014, 114, '89 Jefferson Way Portland	97201', (SELECT CURRENT_TIMESTAMP)),
(1016, 116, '87 Polk St San Francisco 94117', (SELECT CURRENT_TIMESTAMP));
---------------------------------------------------------------------------
---------------------------- SELECTION ------------------------------------
---------------------------------------------------------------------------

-- Select ProductID, ProductType, ProductName, Quantity, Cost FROM StoreApp.Product;


SELECT * FROM StoreApp.Product WHERE ProductID = (SELECT ProductID FROM StoreAPP.Orders WHERE CustomerID = 1000);