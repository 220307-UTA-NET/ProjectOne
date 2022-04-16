--20220307 Project1 SQL
CREATE SCHEMA Project1

--To create the table of the bank user
CREATE TABLE Users(
bankUserId INT PRIMARY KEY IDENTITY,
bankUserFirstName NVARCHAR(25) NOT NULL,
bankUserLastName NVARCHAR(25) NOT NULL,
bankUserUsername NVARCHAR(25) NOT NULL,
bankUserPassword NVARCHAR(25) NOT NULL,
--bankRoleId INT reference Role (bankRoleId)

);
INSERT INTO Users values(bankUserFirstName, bankUserLastName, bankUserUsername, bankUserPassword);
INSERT INTO Users values('Kevin', 'Lee', 'Libra','Opal');
INSERT INTO Users values('Richard','Hawkins','test2','test2')

SELECT * FROM Users


CREATE TABLE Account(
bankAccountId INT PRIMARY KEY IDENTITY,
bankAccountBalance Decimal(14,2) NOT NULL,
--bankAccountTypeId INT reference AccountType (AccountType),
--bankAccountStatusId INT reference AccountStatus (AccountStatus)
bankUserId INT FOREIGN KEY REFERENCES Users(bankUserId)
);

SELECT * FROM Account;

INSERT INTO Account values(10000.00, 1);

CREATE TABLE AccountType(
bankAccountTypeId INT PRIMARY KEY IDENTITY,
bankAccountType NVARCHAR(25) NOT NULL
);

INSERT INTO AccountType values('Checking');
INSERT INTO AccountType values('Saving');

CREATE TABLE AccountStatus(
bankAccountStatusId INT PRIMARY KEY IDENTITY,
bankAccountStatus NVARCHAR(25) NOT NULL
);

INSERT INTO AccountStatus values('Pending');
INSERT INTO AccountStatus values('Open');
INSERT INTO AccountStatus values('Closed');
INSERT INTO AccountStatus values('Denied');


CREATE TABLE Role(
bankRoleId INT PRIMARY KEY IDENTITY,
bankRole NVARCHAR(25) NOT NULL
);

INSERT INTO Role values ('Admin');
INSERT INTO Role values ('Employee');
INSERT INTO Role values ('Standard');
INSERT INTO Role values ('Premium');