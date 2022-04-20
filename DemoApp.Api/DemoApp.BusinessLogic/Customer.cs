﻿namespace DemoApp.BusinessLogic
{
    public class Customer
    {

        public int custId { get; set; }
        public int IsVerified { get; set; }
        public string? custFirstName { get; set; }
        public string? custLastName { get; set; }
        public string? custAddress{get; set;}
        public string? dob { get; set; }


        public Customer(int custId,int IsVerified, string custFirstName, string custLastName, string custAddress, string dob)
        {
            this.custId = custId;
            this.IsVerified = IsVerified;
            this.custFirstName = custFirstName;
            this.custLastName = custLastName;
            this.custAddress = custAddress;
            this.dob = dob;
        }

        public string getCustFirstName()
        {
            return this.custFirstName;
        }

        public string setCustFirstName(string custFirstName)
        {
            return this.custFirstName = custFirstName;
        }

        public string getCustLastName()
        {
            return this.custLastName;
        }

        public string setCustLastName(string custLastName)
        {
            return this.custLastName = custLastName;
        }


        public int getCustId()
        {
            return this.custId;
        }
        public int setCustId(int custId)
        {
            return this.custId = custId;
        }

        public int getIsVerified()
        {
            return this.IsVerified;

        }

        public int setIsVerified(int IsVerified)
        {
            return this.IsVerified = IsVerified;
        }

        public string getCustAddress()
        {
            return this.custAddress;
        }

        public string setCustAddress(string custAddress)
        {
            return this.custAddress = custAddress;
        }

    }
}