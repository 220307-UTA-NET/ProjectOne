using System;
namespace DemoApp.DTOs
{
	public class TransactionDTO
	{
        public int transId { get; set; }
        public DateTime transDate { get; set; }
        public int accountId { get; set; }
        public int transTypeId { get; set; }

        public decimal debitAmount { get; set; }
        public decimal creditAmount { get; set; }

        public decimal balance { get; set; }

    }
}

