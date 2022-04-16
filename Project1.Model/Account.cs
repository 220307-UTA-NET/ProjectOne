using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Model
{
    public class Account
    {

        //Fields
        private int bankAccountId;
        private decimal bankAccountBalance;
        private AccountType bankAccountType;
        private AccountStatus bankAccountStatus;

        //Constructor
        public Account() { }

        public Account(int bankAccountId, decimal bankAccountBalance, AccountType bankAccountType, AccountStatus bankAccountStatus)
        {
            this.bankAccountId = bankAccountId;
            this.bankAccountBalance = bankAccountBalance;
            this.bankAccountType = bankAccountType;
            this.bankAccountStatus = bankAccountStatus;
        }

        public int GetBankAccountId()
        {
            return this.bankAccountId;
        }

        public decimal GetBankAccountBalance()
        {
            return this.bankAccountBalance;
        }
        public AccountType GetAccountType()
        {
            return this.bankAccountType;
        }
        public AccountStatus GetAccountStatus()
        {
            return this.bankAccountStatus;
        }
    }

    


}
