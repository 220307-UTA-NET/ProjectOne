DECLARE @RC int
DECLARE @FromAccount int
DECLARE @toAccount int
DECLARE @amount numeric(18,2)
DECLARE @TransType int
DECLARE @transID1 bigint
DECLARE @transID2 bigint

-- TODO: Set parameter values here.

Set @FromAccount    = 223
SET @toAccount      = 652
Set @TransType      = 2
set @amount         = 100

EXECUTE @RC = [BankManagementSystem].[SpTransferMoney] 
   @FromAccount
  ,@toAccount
  ,@amount
  ,@TransType
  ,@transID1 OUTPUT
  ,@transID2 OUTPUT
;


Select @RC, @transID1, @transID2


--  delete From BankManagementSystem.AccountTransaction

Select * from BankManagementSystem.AccountTransaction
Select * from BankManagementSystem.Account
