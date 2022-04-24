using System;
namespace DemoApp.BusinessLogic
{
	public class Account
	{
		//Fields
		public int accountId { get; set; }
		public int accountNumber { get; set; }
		public int customerId { get; set; }

		public int accountType { get; set; } // 1: checking, 2:saving

		public string OpenningDate { get; set; }
		public string LastTransactionDate { get; set;}

		public int Status; // 1 for active , 2 for closed

		public decimal accountBalance { get; set; }

		
		//Constructors

		public Account() { }

		public Account(int accountId, int accountNumber, int customerId, int accountType, string OpenningDate, string LastTransactionDate, int Status, decimal accountBalance)
		{
			this.accountId = accountId;
			this.accountNumber = accountNumber;

			this.customerId = customerId;
			this.accountType = accountType;

			this.OpenningDate = OpenningDate;
			this.LastTransactionDate = LastTransactionDate;

			this.Status = Status;

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

		public int GetAccountNumber()
		{
			return this.accountNumber;
		}

		public int SetAccountNumber(int accountNumber)
		{
			return this.accountNumber = accountNumber;
		}


		public int GetAccountType()
        {
			return this.accountType;
        }

		public int SetAccountType(int accountType)
        {
			return this.accountType = accountType;
        }

		public string GetOpenningDate()
        {
			return this.OpenningDate;
        }

		public string SetOpenningDate(string Openningdate)
        {
			return this.OpenningDate = OpenningDate;

        }

		public int GetStatus()
        {
			return this.Status;
        }

		public int SetStatus(int Status)
        {
			return this.Status = Status;
        }


		public decimal GetAccountBalance()
		{
			return this.accountBalance;
		}


		public decimal SetAccountBalance(decimal accountBalance)
        {
			return this.accountBalance = accountBalance;
        }

	


	}
}


