using System;
namespace DemoApp.DTOs
{
	public class AccountDTO
	{
		public int accountId { get; set; }
		public int accountNumber { get; set; }
		public int customerId { get; set; }
		public int accountType { get; set; }
		public string OpenningDate { get; set; }
		public string LastTransactionDate { get; set; }
		public int Status; // 1 for active , 2 for closed
		public decimal accountBalance { get; set; }

	public AccountDTO(int accountNumber, int customerId, int accountType, string OpenningDate, string LastTransactionDate, int Status, decimal accountBalance, int accountId = 0)
    {
		this.accountNumber = accountNumber;
			this.customerId = customerId;
			this.accountType = accountType;
			this.OpenningDate = OpenningDate;
			this.LastTransactionDate = LastTransactionDate;
			this.Status = Status;
			this.accountBalance = accountBalance;
			this.accountId = accountId;
    }
	}

}

