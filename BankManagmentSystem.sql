CREATE SCHEMA BankManagementSystem;
GO

-----------Transaction Type Table---------------
Drop table if exists BankManagementSystem.TransactionType;

CREATE TABLE BankManagementSystem.TransactionType(
ID int Not NULL,
Name varchar(100),
Constraint PK_TransactionType Primary Key (ID));

SELECt *
FROM BankManagementsystem.TransActionType

INSERT INTO BankManagementSystem.TransactionType VALUES(1, 'Atm deposit');
INSERT INTO BankManagementSystem.TransactionType VALUES(2, 'Internal Transfer');
INSERT INTO BankManagementSystem.TransactionType VALUES(3, 'External transfer');
INSERT INTO BankManagementSystem.TransactionType VALUES(4, 'Branch deposit');
INSERT INTO BankManagementSystem.TransactionType VALUES(5, 'Branch credit');

SELECT * FROM BankManagementSystem.Customer 
--WHERE (FirstName = 'Hosna') OR (LastName = 'Hosna');


------------- Customer Table-------------
Drop table if exists BankManagementSystem.Customer;

CREATE TABLE BankManagementSystem.Customer(
    CustomerID INT IDENTITY NOT NULL PRIMARY KEY,
    IsVerified INT NOT NULL,
    FirstName NVARCHAR(32)  NOT NULL,
    LastName NVARCHAR(32) NOT NULL,
    CustAddress NVARCHAR(200) NOT Null,
    DOB NVARCHAR(32) NOT Null
);

INSERT INTO BankManagementsystem.Customer(IsVerified, FirstName,LastName,CustAddress, DOB)
VALUES('2','Hamid','Hamedi','Address2', '1989-06-06')

UPDATE BankManagementSystem.Customer set CustAddress =  'customer.custAddress' WHERE CustomerID = 2

SELECt *
FROM BankManagementsystem.Customer

--////////////////////////////////////////////////////////////////////////////////////////////////

-------------Account Table-------------------

Drop table if exists BankManagementSystem.Account;

CREATE TABLE BankManagementSystem.Account(
AccountID INT IDENTITY(1, 1) NOT NULL,
AccountNumber INT NOT NULL,
CustomerID INT NOT NULL,
[Type] int NOT NULL, --1 checking 2: saving
OpenningDate DATETIME NOT NULL,
LastTransactionDate DATETIME NOT NULL,
[Status] int NOT NULL, -- 1 for active, 2 closed
--InitialDeposit DECIMAL NOT NULL,
--Interest FLOAT NOT NULL,
Balance DECIMAL(18, 2) NOT NULL,
constraint PK_Account Primary key (AccountID),
Constraint FK_Account_Customer FOREIGN KEY(CustomerID) REFERENCES BankManagementSystem.Customer(CustomerID),
Constraint UK_Account Unique (AccountNumber)
);

SELECt *
FROM BankManagementsystem.Account

INSERT INTO BankManagementsystem.Account(
    [AccountNumber],[CustomerID],[Type],[OpenningDate],[LastTransactionDate],[Status],[Balance]
)
VALUES(222, 1, 1, '2021-05-05', '2022-04-04', 1, '2000')

INSERT INTO BankManagementsystem.Account(
    [AccountNumber],[CustomerID],[Type],[OpenningDate],[LastTransactionDate],[Status],[Balance]
)
VALUES(223, 1, 1, '2021-05-05', '2022-04-04', 1, '5000')

--////////////////////////////////////////////////////////////////////////////////////

------------Bank Branch Table------------

CREATE TABLE BankManagementsystem.Branch(
BranchCode Int NOT NULL PRIMARY KEY,
BranchName VARCHAR(32) NOT NULL,
BranchAddress VARCHAR(200) NOT NULL
);


--DROP TABLE BankManagementSystem.Branch

Select *
FROM BankManagementSystem.Branch
Insert INTO BankManagementSystem.Branch(BranchCode, BranchName, BranchAddress)
VALUES('B456','SaratogaBranch','MNP')


--////////////////////////////////////////////////////////////////////////////////////////

--------------Employee Table------------

CREATE TABLE BankManagementSystem.Employee(
EmplID INT IDENTITY NOT NULL PRIMARY KEY,
EmplFirstName NVARCHAR(32) NOT NULL,
EmplLastName NVARCHAR(32) NOT NULL,
--BranchCode VARCHAR(32) NOT NULL,
);

DROP TABLE BankManagementSystem.Employee

SELECt *
FROM BankManagementsystem.Employee
INSERT INTO BankManagementsystem.Employee(EmplFirstName,EmplLastName)
VALUES('Employee1F', 'Employee2L')


--//////////////////////////////////////////////////////////////////////////////////////



-------------Transaction  Table---------------
Drop table if exists BankManagementSystem.AccountTransaction;

CREATE TABLE BankManagementSystem.AccountTransaction(
TransId         BigINT NOT NULL Identity (1,1),
TransDate       DATETime NOT NULL,
AccountID       INT NOT NULL,-- FOREIGN KEY REFERENCES BankManagementSystem.Account(AccountID),
TransTypeID     INT NOT NULL,
DebitAmount     Numeric(18, 2) NOT NULL,
CreditAmount    Numeric(18, 2) NOT NULL,
Balance         Numeric(18, 2) NOT NULL,
Constraint PK_AccountTransaction Primary Key (TransID),
Constraint FK_Transaction_Account FOREIGN key (AccountID) references BankManagementSystem.ACCOUNT(AccountID),
Constraint FK_Transaction_TransactionType FOREIGN key (TransTypeID) references BankManagementSystem.TransActionType(ID)
);
--EmployeeID INT NOT NULL FOREIGN KEY REFERENCES BankManagementSystem.Employee(EmplID)

SELECt *
FROM BankManagementsystem.AccountTransaction
INSERT INTO BankManagementSystem.AccountTransaction(TransId,TransDate,AccountID,TransTypeID,DebitAmount,CreditAmount,Balance)
VALUES(1,'2022-03-04', 1 ,2, '200', '200',0)
