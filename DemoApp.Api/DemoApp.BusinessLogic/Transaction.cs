namespace DemoApp.BusinessLogic
{
    public class Transaction
    {

        //Fields:

        public int transId { get; set; }
        public DateTime transDate { get; set; }
        public int accountId { get; set; }
        public int transTypeId { get; set; }

        public decimal debitAmount { get; set;}
        public decimal creditAmount { get; set; }
    
        public decimal balance { get; set; }
       



        //Constructors

        public Transaction() { }
        public Transaction(int transId, DateTime transDate, int accountId, int transTypeId,  decimal debitAmount, decimal creditAmount, decimal balance)
        {
            this.transId = transId;
            this.transDate = transDate;
            this.transTypeId = transTypeId;
            this.debitAmount = debitAmount;
            this.creditAmount = creditAmount;
            this.balance = balance;
      
        }

        public int getTransactionId()
        {
            return this.transId;
        }

        public int setTransactionId(int transId)
        {
            return this.transId = transId;
        }

        public DateTime getTransactionDate ()
        {
            return this.transDate;
        }

        public DateTime setTransActionDate(DateTime transDate)
        {
            return this.transDate = transDate;
        }

        public decimal getTransactionCreditAmount()
        {
            return this.creditAmount;
        }

        public decimal setTransactionCreditAmount(decimal creditAmount)
        {
            return this.creditAmount = creditAmount;
        }

        public decimal getTransactionDebitAmount()
        {
            return this.debitAmount;
        }

        public decimal setTransactionDebitAmount(decimal creditAmount)
        {
            return this.debitAmount = creditAmount;
        }


        public decimal GetTransactionBalance()
        {
            return this.balance;

        }

        public decimal SetTransActionBalance(decimal balance)
        {
            return this.balance = balance;

        }
    }
}