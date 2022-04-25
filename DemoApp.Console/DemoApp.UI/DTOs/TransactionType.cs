using System;
using DemoApp.DTOs;

namespace DemoApp.UI.DTOs
{
	public class TransactionType
	{
		//feilds

		public AccountDTO  FromAccount { get; set; }
		public AccountDTO ToAccount { get; set; }
		public decimal amount { get; set; }

	}
}

