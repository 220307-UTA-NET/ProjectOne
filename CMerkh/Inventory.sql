CREATE SCHEMA ShopData;
GO

CREATE TABLE ShopData.StoreNames(
    Name NVARCHAR (100),
    Store_ID INT,
    CHECK (LEN(Name) >0)
)

INSERT INTO ShopData.StoreNames (Name, Store_ID) VALUES     ('2025 M St NW (DC)', 0);
INSERT INTO ShopData.StoreNames (Name, Store_ID) VALUES     ('147th St (New York)', 1);
INSERT INTO ShopData.StoreNames (Name, Store_ID) VALUES     ('Delancy St AKA Canal St (New York)', 2);
INSERT INTO ShopData.StoreNames (Name, Store_ID) VALUES     ('95th St (New York)', 3);
INSERT INTO ShopData.StoreNames (Name, Store_ID) VALUES     ('Cicero Ave (Chicago)', 4);

SELECT * FROM ShopData.StoreNames;



CREATE TABLE ShopData.Inventory(
    Item_ID INT PRIMARY KEY IDENTITY,
    Name NVARCHAR (100) NOT NULL,
    Maker NVARCHAR (100) NOT NULL,
    StoreQuantity0 INT,
    StoreQuantity1 INT,
    StoreQuantity2 INT,
    StoreQuantity3 INT,
    StoreQuantity4 INT,
    Price SMALLMONEY,
)

INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('100 asstd Lug Nuts', 'Auburn Motor Car Company', 1585, 5312, 4367, 6541, 4011, 499.99);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Garlic Bread in a Can', 'B & R House of Toast', 5001, 3421, 6663, 4868, 4558, 12.49);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Raw Toast Loaf','B & R House of Toast', 5173, 5830, 3447, 5132, 5737,4.79);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Box of Canadian Air','CCA', 563, 496, 357, 517, 387, 18.98);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Box of Quebec Air','CCA', 552, 659, 449, 687, 391, 17.30);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Roll of Flypaper','Einbinder Flypaper', 15152, 11862, 7902, 7740, 11855, 1.19);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Sheet of Flypaper','Einbinder Flypaper', 18231, 17498, 10721, 15475, 15520, 2.19);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Battery Powered Battery Charger', 'Feld Electrical', 1191, 802, 1101, 941, 1046, 24.99);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Standing Cashregister','Feld Electrical', 951, 687, 570, 510, 977, 1389.00);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Box of 100 Paperclips','Great Lakes Paperclip Company', 33357, 28747, 22397, 36525, 28320, 0.27);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Gross Boxes of 100 Paperclips','Great Lakes Paperclip Company', 409, 555, 487, 586, 579, 38.88);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Box of Mushies','Kretchford', 3034, 5676, 5677, 5728, 4900, 4.59);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('25 lb Bag of Flour (Gluten-free)','Kretchford', 5311, 4795, 3390, 4168, 6644, 16.98);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('1 lb of Veal (Cruelty-free)','Kretchford', 2491, 3234, 2191, 1706, 3052, 19.9);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Single Steel Ingots (Gloss)','Monongahela', 2472, 2565, 1996, 2469, 2405, 2.80);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Single Steel Ingots (High Gloss)','Monongahela', 2949, 2680, 1516, 2277, 2713, 3.80);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Single Steel Ingots (Matte)','Monongahela', 1669, 1840, 1894, 1947, 3653, 2.5);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Chocolate Cookies with White Stuff In-Between','Penuche', 5723, 3768, 3997, 5184, 5772, 3.98);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Chocolate Wobblie','Penuche', 3970, 5593, 3264, 3980, 4763, 14.99);
INSERT INTO ShopData.Inventory (Name, Maker, StoreQuantity0, StoreQuantity1, StoreQuantity2, StoreQuantity3, StoreQuantity4, Price) VALUES ('Pallet of Fudge','Penuche', 108, 148, 123, 163, 71, 12635.30);

--SELECT * FROM ShopData.Inventory;

--DROP TABLE ShopData.Inventory;

-- UPDATE ShopData.Inventory SET StoreQuantity0 = 1586, StoreQuantity1 = 5312 WHERE Item_Id = 1;