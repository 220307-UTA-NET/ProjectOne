using System;
namespace DemoApp.BusinessLogic
{
	public class Account
	{
		//Fields
		private int accountId { get; set; }
		private int customerId { get; set; }
		private string? accountType { get; set; }
		private int accountNumber { get; set; }
		private decimal accountBalance { get; set; }
		private decimal initialDeposit { get; set; }
		private decimal interest { get; set; }

		
		//Constructors

		public Account() { }

		public Account(int accountId, int customerId, string? accountType, int accountNumber, decimal interest, decimal accountBalance)
		{
			this.accountId = accountId;
			this.customerId = customerId;
			this.accountType = accountType;
			this.accountNumber = accountNumber;
			this.interest = interest;
			this.accountBalance = accountBalance;

		}
		//Methods
		public int GetAccountId()
        {
			return this.accountId;
        }

		public int SetAccountId(int accountId)
        {
			return this.accountId = accountId;
        }


		public int GetCustomerId()
        {
			return this.customerId;
        }

		public int SetCustomerId(int customerId)
        {
			return this.customerId = customerId;
        }


		public string GetAccountType()
        {
			return this.accountType;
        }

		public string SetAccountType(string accountType)
        {
			return this.accountType = accountType;
        }

		public int GetAccountNumber()
		{
			return this.accountNumber;
		}

		public int  SetAccountNumber(int accountNumber)
        {
			return this.accountNumber = accountNumber;
        }


		public decimal GetAccountBalance()
		{
			return this.accountBalance;
		}


		public decimal SetAccountBalance(decimal accountBalance)
        {
			return this.accountBalance = accountBalance;
        }

		public decimal GetInterest()
		{
			return this.interest;
		}


		public decimal SetInterest(decimal interst)
        {
			return this.interest = interest;
        }


	}
}


