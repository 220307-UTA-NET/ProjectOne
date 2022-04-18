using System;
namespace DemoApp.UI.DTOs
{
	public class Transaction
	{
        public int transId { get; set; }
        public DateTime transDate { get; set; }
        public string? transType { get; set; }

        public int? custSenderId { get; set; }
        public int? custSenderAccountId { get; set; }

        public int? custReceiverId { get; set; }
        public int? custReceiverAccountId { get; set; }


        public decimal amount { get; set; }

    }
}

