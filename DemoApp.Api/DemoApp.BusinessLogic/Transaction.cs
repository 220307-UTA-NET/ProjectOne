namespace DemoApp.BusinessLogic
{
    public class Transaction
    {

        //Fields:

        public int transId { get; set; }
        public DateTime transDate { get; set; }
        public string? transType { get; set; }

        public int? custSenderId { get; set; }
        public int? custSenderAccountId { get; set; }
        
        public int? custReceiverId { get; set; }
        public int? custReceiverAccountId { get; set; }
        
      
        public decimal amount { get; set; }
       



        //Constructors

        public Transaction() { }
        public Transaction(int transId, DateTime transDate,string transType, int custSenderId, int custSenderAccountId, int custReceiverId,int custReceiverAccountId, decimal amount)
        {
            this.transId = transId;
            this.transDate = transDate;
            this.custSenderId = custSenderId;
            this.custSenderAccountId = custSenderAccountId;
            this.custReceiverId = custReceiverId;
            this.custReceiverAccountId = custReceiverAccountId;
            this.amount = amount;
      
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

        public decimal getTransactionAmount()
        {
            return this.amount;
        }

        public decimal setTransactionAmount(decimal amount)
        {
            return this.amount = amount;
        }

        

    }
}