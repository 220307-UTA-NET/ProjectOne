using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Horoscope.Logic
{
    public class Client
    {
        // Fields
        int USER_ID;
        string ZODIAC_SIGN;
        string FIRST_NAME;
        string LAST_NAME;
        string BIRTH_DATE;
        string PHONE_NUMBER;



        // Constructor
        public Client() { }
        public Client(int USER_ID, string ZODIAC_SIGN, string FIRST_NAME, string LAST_NAME, string BIRTH_DATE, string PHONE_NUMBER)
        {
            this.USER_ID = USER_ID;
            this.ZODIAC_SIGN = ZODIAC_SIGN;
            this.FIRST_NAME = FIRST_NAME;
            this.LAST_NAME = LAST_NAME;
            this.BIRTH_DATE = BIRTH_DATE;
            this.PHONE_NUMBER = PHONE_NUMBER;
        }


        // Methods
        public int GetUSER_ID()
        { return this.USER_ID; }
        public string GetZODIAC_SIGN()
        { return this.ZODIAC_SIGN; }
        public string GetFIRST_NAME()
        { return this.FIRST_NAME; }
        public string GetLAST_NAME()
        { return this.LAST_NAME; }
        public string GetBIRTH_DATE()
        { return this.BIRTH_DATE; }
        public string GetPHONE_NUMBER()
        { return this.PHONE_NUMBER; }   

        public void SetZODIAC_SIGN(string ZODIAC_SIGN)
        { this.ZODIAC_SIGN = ZODIAC_SIGN; }
        public void SetFIRST_NAME(string FIRST_NAME)
        { this.FIRST_NAME = FIRST_NAME; }
        public void SetLAST_NAME(string LAST_NAME)
        { this.LAST_NAME= LAST_NAME; }
        public void SetBIRTH_DATE(string BIRTH_DATE)
        { this.BIRTH_DATE = BIRTH_DATE; }   
        public void SetPHONE_NUMBER(string PHONE_NUMBER)
        { this.PHONE_NUMBER = PHONE_NUMBER; }



        public string Introduce()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my name is {this.FIRST_NAME}, and my userID is {this.USER_ID}");
            return sb.ToString();
        }

    }
}