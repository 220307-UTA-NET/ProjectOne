using Horoscope.DataInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horoscope.Logic;

namespace Horoscope.App
{
    public class Horoscope
    {
        // Fields
        IRepository repo;


        // Constructor
        public Horoscope(IRepository repo)
        {
            this.repo = repo;
        }

        // Methods
        public string GetUserZodiac(int ID)
        {
            return repo.GetUserZodiac(ID);
            
        }
    
        public Client CreateNewClient(string ZODIAC_SIGN, string FIRST_NAME, string LAST_NAME, string BIRTH_DATE, string PHONE_NUMBER)
        { return repo.CreateNewClient(ZODIAC_SIGN, FIRST_NAME, LAST_NAME, BIRTH_DATE, PHONE_NUMBER); }


       
    }
}