using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class Account
    {
        public int bankAccountId { get; set; }
        public decimal bankAccountBalance { get; set; }
        //public AccountType bankAccountType { get; set; }
        //public AccountStatus bankAccountStatus { get; set; }
        public int bankUserId { get; set; }
        public Account() { }
        public Account(int bankAccountId, decimal bankAccountBalance, int bankUserId)
        {
            this.bankAccountId = bankAccountId;
            this.bankAccountBalance = bankAccountBalance;
            this.bankUserId = bankUserId;
        }

       public decimal GetbankAccountBalance()
        { return bankAccountBalance; }

        public int GetbankUserId()
        { return bankUserId; }
    }
}
