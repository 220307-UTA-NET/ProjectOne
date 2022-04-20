using System;
namespace DemoApp.DTOs
{
	public class AccountDTO
	{
		private int accountId { get; set; }
		private int accountNumber { get; set; }
		private int customerId { get; set; }
		private string? accountType { get; set; }
		private DateTime OpenningDate { get; set; }
		private DateTime LastTransactionDate { get; set; }
		private int Status; // 1 for active , 2 for closed
		private decimal accountBalance { get; set; }

	}
}

