using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horoscope.Logic
{
    public class UserZodiac
    {
        // Fields
        private int USER_ID;
        public string ZODIAC_SIGN;
        public string TODAYS_READING;
        public string TOMORROWS_READING;
        public string YESTERDAYS_READING;
        public string SAVED_READINGS;
//Initially Wanted a Saved Log of past readings
        // Constructor
        public UserZodiac() { }
        public UserZodiac(int USER_ID,string ZODIAC_SIGN, string TODAYS_READING, string TOMORROWS_READING, string YESTERDAYS_READING, string SAVED_READINGS)
        {
            this.USER_ID = USER_ID;
            this.ZODIAC_SIGN = ZODIAC_SIGN;
            this.TODAYS_READING = TODAYS_READING;
            this.TOMORROWS_READING = TOMORROWS_READING;
            this.YESTERDAYS_READING = YESTERDAYS_READING;
            this.SAVED_READINGS = SAVED_READINGS;
        }

        // Methods
        public int GetUSER_ID()
        { return this.USER_ID; }
        public string GetZODIAC_SIGN()
        { return this.ZODIAC_SIGN; }
        public string GetTODAYS_READING()
        { return this.TODAYS_READING; }
        public string GetTOMORROWS_READING()
        { return this.TOMORROWS_READING; }
        public string GetYESTERDAYS_READING()
        { return this.YESTERDAYS_READING; }
        public string GetSAVED_READINGS()
        { return this.SAVED_READINGS; }
        public void SetZODIAC_SIGN(string ZODIAC_SIGN)
        { this.ZODIAC_SIGN = ZODIAC_SIGN; }
        public void SetTODAYS_READING()
        { this.TODAYS_READING = TODAYS_READING; }
        public void SetTOMORROWS_READING()
        { this.TOMORROWS_READING=TOMORROWS_READING; }
        public void SetYESTERDAYS_READING()
        { this.YESTERDAYS_READING=YESTERDAYS_READING; }
        public void SetSAVED_READINGS()
        { this.SAVED_READINGS = SAVED_READINGS; }   
        public string Introduce1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hello, my userID is {this.USER_ID}, and I am a {this.ZODIAC_SIGN}");
            return sb.ToString();
        }

    }
}
