--Connect to a database server, then run this whole file to create an example database
--Create Schema
CREATE SCHEMA VLLibrary;
GO

--View all tables (uncomment, highlight, and run to use)
--SELECT * FROM VLLibrary.Books;
--SELECT * FROM VLLibrary.Rentals;
--SELECT * FROM VLLibrary.Accounts;
--GO


--Drop all tables and schema (uncomment, highlight, and run to use)
--DROP TABLE VLLibrary.Books;
--DROP TABLE VLLibrary.Accounts;
--DROP TABLE VLLibrary.Rentals;
--GO
--DROP SCHEMA VLLibrary
--GO

--Create and populate tables
CREATE TABLE VLLibrary.Books (
    BookID INT IDENTITY (100,1) NOT NULL PRIMARY KEY,
    Title VARCHAR (255) NOT NULL,
    Author VARCHAR (255) NOT NULL,
    Price DECIMAL (19,2),
    InStock INT DEFAULT 1
);

CREATE TABLE VLLibrary.Accounts (
    MemberID INT IDENTITY (1,1) NOT NULL PRIMARY KEY,
    FirstName VARCHAR (255) NOT NULL,
    LastName VARCHAR (255) NOT NULL,
    Phone VARCHAR (255)
);

CREATE TABLE VLLibrary.Rentals (
    RentalID INT IDENTITY (1000,1) NOT NULL PRIMARY KEY,
    MemberID INT NOT NULL FOREIGN KEY REFERENCES VLLibrary.Accounts (MemberID) ON DELETE CASCADE,
    BookID INT NOT NULL FOREIGN KEY REFERENCES VLLibrary.Books (BookID) ON DELETE CASCADE,
    --OutDate DATETIME NOT NULL DEFAULT GETDATE(), 
    --InDate DATETIME NULL
    --These were being used in tests for future function
);
GO

--Put example values into the tables we created
INSERT INTO VLLibrary.Accounts ( FirstName, LastName, Phone )
    VALUES ('David', 'Davidson', '9995551405'),
    ('Thomas', 'Thompson', '9995551212'),
    ('Ezio','Ferdinand', '9998887755'),
    ('Beth','Sanchez','9994445555'),
    ('Shorton','Welton', '9995558787'),
    ('Kevin','Macalister', '2101115555'),
    ('Jan','Bathman', '8885554258'),
    ('Daniel', 'Fontaine', '9995552312'),
    ('Jerilyn', 'Robottom', '9995558528'),
    ('Alex', 'Anderson', '9995559787'),
    ('Adele', 'Canova', '9995553969'),
    ('Melvin', 'Cardinale', '9995550121'),
    ('Margaret', 'Desormeaux', '9995557357'),
    ('Rodney', 'Chard', '9995558164'),
    ('Adrian', 'Cosie', '9995556914'),
    ('James', 'Crysup Jr.', '9995550909'),
    ('Josephy', 'Dyer', '9995557316'),
    ('Clarence', 'Francois', '99955543781'),
    ('Charles', 'Frazier', '999555083'),
    ('William', 'Frey', '9995553888'),
    ('Avery', 'Gardner Sr.', '9995559999'),
    ('Luke', 'Gross', '9995551111'),
    ('Elizabeth', 'Guillot', '9995550000'),
    ('Elex', 'Hosley', '9995552222'),
    ('Magan', 'Jimerson', '9995553333'),
    ('Linda', 'Lambert', '9995554444'),
    ('Francisco', 'Leal', '9995555555'),
    ('Dorian', 'Lewis', '9995556666'),
    ('Anthony', 'Loria', '9995557777'),
    ('Brenda', 'Marshall', '9995558888'),
    ('Wilma', 'Miller', '99995559998'),
    ('Michael', 'Morris', '9995550000'),
    ('Stanley', 'Petes', '9995550001'),
    ('Cynthia', 'Recasner', '9995550002'),
    ('Barbara', 'Sheppard', '9995550003'),
    ('Lois', 'Shiell', '9995550004'),
    ('Joseph', 'Sias', '9995550005'),
    ('Finn', 'Skorge', '9995550006'),
    ('Johnie', 'Sullivan', '9995550007'),
    ('Aaron', 'Thompson', '9995550008'),
    ('Melanie', 'Thompson', '9995550009'),
    ('Marie', 'Rome', '9995550010'),
    ('Patricia', 'Weaver', '9995550011'),
    ('Maxine', 'Wiltz', '9995550012'),
    ('Arthur', 'Young', '9995550013'),
    ('Joan', 'Baldo', '9995550014'),
    ('Corey', 'Baptiste', '9995550015'),
    ('James', 'Brown', '9995550016'),
    ('Shaquille', 'Cooper', '9995550017'),
    ('Eileen', 'Donovan', '9995550018'),
    ('Horace', 'Gervais', '9995550019'),
    ('Virgie', 'Gosey-Stevenson', '9995550020'),
    ('Kirk', 'Haynes', '9995550021'),
    ('Bernell', 'Henderson', '9995550022'),
    ('Mervin', 'Higgins', '9995550023'),
    ('Hiawatha', 'Lewis', '9995550024'),
    ('Ruby', 'Marcell', '9995550025'),
    ('Kenneth', 'Meyers', '9995550026'),
    ('Margaret', 'Schaff', '9995550027'),
    ('Terry', 'Searls', '9995550028'),
    ('Alma', 'Shepard', '9995550029'),
    ('Wendell', 'Stipelcovich', '9995550030'),
    ('Andrew', 'Twohig', '9995550031'),
    ('William', 'Walker', '9995550032'),
    ('Linda', 'Ball', '9995550033'),
    ('Joyce', 'Balsamo', '9995550034'),
    ('Octave', 'Barovechio', '9995550035'),
    ('Edward', 'Constantine', '9995550036'),
    ('Debra', 'Francis', '9995550037'),
    ('Valerie', 'Gross', '9995550038'),
    ('Rosemary', 'Honore', '9995550039'),
    ('Clayton', 'Joffrion', '9995550040'),
    ('Lionel', 'Jones', '9995550041'),
    ('Constance', 'Laneri', '9995550042'),
    ('Vida', 'Lewis', '9995550043'),
    ('Zachary', 'McGee', '9995550044'),
    ('Rosie', 'Monica', '9995550045'),
    ('Avery', 'Natal', '9995550046'),
    ('Noemie', 'Raymond', '9995550047'),
    ('Haywood', 'Reed', '9995550048'),
    ('Lousie', 'Richarson', '9995550049'),
    ('Regina', 'Scanio', '9995550050'), 
    ('Sophia', 'Tadlock', '9995550051'),
    ('Frank', 'Vallarautto', '9995550052'),
    ('David', 'Wright', '9995550053'),
    ('Katherine', 'Bourg', '9995550054'),
    ('Gregory', 'Cannella', '9995550055'),
    ('Brenda', 'Chimento', '9995550056'),
    ('Paul', 'Daniel', '9995550057'),
    ('Antonio', 'Planells', '9995550058'),
    ('Patricia', 'Andrews', '9995550059'),
    ('Anthony', 'Birkel', '9995550060'),
    ('Beverly', 'Broussard', '9995550061'),
    ('Courtney', 'Clark', '9995550062'),
    ('Blanche', 'Peralta', '9995550063'),
    ('Charles', 'Favrot', '9995550064'),
    ('Gloria', 'Flettrich', '9995550065'),
    ('William', 'Font', '9995550066'),
    ('Virginia', 'Gaudet', '9995550067'),
    ('Foster', 'Johnson', '9995550068'),
    ('Jacqueline', 'LeBan', '9995550069'),
    ('Geraldine', 'Greenlee', '9995550070'),
    ('James', 'Martin', '9995550071'),
    ('Louis', 'Mason-Duplessis', '9995550072'),
    ('Lucretia', 'McGee', '9995550073'),
    ('Edward', 'Nagin', '9995550074'),
    ('Geraldine', 'Norman', '9995550075'),
    ('Alexander', 'Riecke', '9995550076'),
    ('Frederick', 'Rogers', '9995550077'),
    ('Michelle', 'Schumert', '9995550078'),
    ('Jacobo', 'Solano', '9995550079');

INSERT INTO VLLibrary.Books ( Title, Author, Price )
    VALUES ('The Prince and The Discourses', 'Nicolo Machiavelli', 3.49),
    ('House Of Leaves', 'Mark Z. Danielewski', 9.99),
    ('The Wild Muir', 'Lee Stetson', 12.99),
    ('The Moral Landscape', 'Sam Harris', 26.99),
    ('The Book of Cthulhu', 'Ross E. Lockhart', 12.68),
    ('The Hobbit', 'J.R.R. Tolkien', 13.95),
    ('Complications', 'Atul Gawande', 13.00),
    ('Bloodletting and Miraculous Cures', 'Vincent Lam', 23.95),
    ('On the Genealogy of Morals and Ecce Homo', 'Friedrich Nietzsche', 5.39),
    ('The Gay Science', 'Friedrich Nietzsche', 13.80),
    ('The Antichrist', 'Friedrich Nietzsche', 7.95),
    ('God is not Great', 'Christopher Hitchens', 14.99),
    ('Fundamentals of Python', 'Kenneth Lambert', 52.00),
    ('The Story of Philosophy', 'Will Durant', 5.09),
    ('American Gods', 'Neil Gaiman', 7.99),
    ('A Game of Thrones', 'George R.R. Martin', 9.99),
    ('Consciousness: a very short introduction', 'Susan Blackmore', 9.95),
    ('Pass Your Amateur Radio Technician Class Test','Craig K4IA', 19.95),
    ('The Secret Cat', 'Tamara Kitt', .59),
    ('Lullaby', 'Chuck Palahniuk', 13.95),
    ('The Rum Diary', 'Hunter S. Thompson', 13.00),
    ('Stranger Than Fiction', 'Chuck Palahniuk', 13.95),
    ('Fight Club', 'Chuck Palahniuk', 13.95),
    ('The Satanic Verses', 'Salman Rushdie', 16.00),
    ('Midnight''s Children', 'Salman Rushdie', 20.00),
    ('Wise Blood', 'Flannery O''Conner', 13.00),
    ('A Confederacy of Dunces', 'John Kennedy Toole', 14.00),
    ('Tropic of Cancer', 'Henry Miller', 11.95),
    ('The Electric Kool-Aid Acid Test', 'Tom Wolfe', 17.00),
    ('Jaws', 'Peter Benchley', 16.00),
    ('I, Lucifer', 'Glen Duncan', 16.00),
    ('The Last Werewolf', 'Glen Duncan', 15.95),
    ('Hell''s Angels', 'Hunter S. Thompson', 19.95),
    ('The Last Lecture', 'Randy Pausch', 21.95),
    ('Animal Farm', 'George Orwell', 6.95),
    ('A Short Guide to a Happy Life', 'Anna Quindlen', 15.00),
    ('Fear and Loathing in Las Vegas', 'Hunter S. Thompson', 16.95),
    ('Down and Out in Paris and London', 'George Orwell', 1.98),
    ('1984', 'George Orwell', 6.95),
    ('The Great Shark Hunt', 'Hunter S. Thompson', 17.00),
    ('Zooman and the Sign', 'Charles Fuller', 7.20),
    ('Nasty Little Secrets', 'Lanie Robertson', 1.98),
    ('Bull Cook and Authentic Historical Recipes and Practices', 'George Leonard Herter and Berthe E. Herter', 8.99),
    ('Wine', 'Hugh Johnson', 10.00),
    ('Betty Crocker''s Picture Cook Book', 'Betty Crocker', 40.00),
    ('The Gourmet Cookbook Volume 1', 'Gourmet Magazine', 12.50),
    ('The Gourmet Cookbook Volume 2', 'Gourmet Magazine', 12.50),
    ('The Only Plane in the Sky', 'Garrett M. Graff', 30.00),
    ('The Dangerous Book for Boys', 'Hal Iggulden', 5.00),
    ('Classic Horror Stories', 'Barnes & Noble', 29.00),
    ('A Brief History of Time', 'Stephen Hawking', 39.95),
    ('A Concise Introduction to Logic', 'Patrick Hurley', 15.66),
    ('Managing and Troubleshooting PCs', 'Mike Meyers', 5.00),
    ('The Lord of the Rings 50th Anniversary Edition', 'J.R.R. Tolkien', 200.00),
    ('Ethical Theory and Moral Problems', ' Howard Curzer', 8.00),
    ('On the Road', 'John Kerouac', 25.95),
    ('The Dalai Lama at MIT', 'Anne Harrington and Arthur Zajonc', 24.95),
    ('An Introduction to Buddhist Ethics', 'Peter Harvey', 15.00),
    ('The World of Tibetan Buddhism', 'The Dalai Lama', 15.95),
    ('The Miracle of Mindfulness', 'Thich Nhat Hanh', 14.00),
    ('Contemplative Science', 'B. Alan Wallace', 10.00),
    ('The Silmarillion', 'J.R.R. Tolkien', 40.00),
    ('A Little Book of Campfire Songs', 'Chronicle Books', 4.54),
    ('The Legion of Regrettable Supervillains', 'Jon Morris', 3.89),
    ('The League of Regrettable SuperHeroes', 'Jon Morris', 7.69),
    ('Figure Fantasy', 'Daniel Picard', 8.00),
    ('The Trial of Colonel Sweeto and Other Stories', 'Nicholas Gurewitch', 14.95),
    ('The Action Hero''s Handbook', 'David Borgenicht and Joe Borgenicht', 14.95),
    ('Cyanide & Happiness', 'Kriss, Rob, Matt & Dave', 13.99),
    ('The Little Book of Beards... and a couple of moustaches!', 'O.S. Belgie', 9.99),
    ('Play Ukelele Today!', 'Hal Leonard', 4.99),    
    ('Pass Your Amateur Radio General Class Test', 'Craig K4IA', 19.95),
    ('An Introduction to Non-Classical Logic', 'Graham Priest', 14.00),
    ('Administering Windows Server 2012', 'Patrick Regan', 10.89),
    ('Microsoft Windows 7 for Power Users', 'Harry Phillips', 4.78),
    ('Network+ Guide to Networks', 'Tamara Dean', 5.34),
    ('Fundamentals of Information Systems Security', 'David Kim and Michael G. Solomon', 8.39),
    ('Systems Analysis and Design', 'Harry Rosenblatt', 50.00),
    ('The Raven', 'Edgar Allan Poe', 8.95);




INSERT INTO VLLibrary.Rentals (MemberID, BookID)
    VALUES (1,114),(2,151),(3,166),(5,165),(7,168),(11,145),(13,113),(17,173),
    (19,142),(23,135),(29,133),(31,177),(37,109),(41,117),(43,103),(47,153),
    (53,119),(59,117),(61,161),(67,127),(71,130),(73,105),(79,126),(83,159),
    (89,126),(97,112),(101,171),(103,178),(107,156),(109,131);

UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 114;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 151;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 166;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 165;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 168;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 145;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 113;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 173;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 142;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 135;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 133;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 177;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 109;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 117;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 103;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 153;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 119;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 117;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 161;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 127;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 130;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 105;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 126;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 159;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 126;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 112;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 171;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 178;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 156;
UPDATE VLLibrary.Books SET InStock = 0 WHERE BookID = 131;
