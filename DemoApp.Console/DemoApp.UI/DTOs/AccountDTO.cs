using System;
namespace DemoApp.UI.DTOs
{
	public class Account
	{
		private int accountId { get; set; }
		private int customerId { get; set; }
		private string? accountType { get; set; }
		private int accountNumber { get; set; }
		private decimal accountBalance { get; set; }
		private decimal initialDeposit { get; set; }
		private decimal interest { get; set; }
		
	}
}

