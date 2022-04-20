using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horoscope.Logic;

namespace Horoscope.DataInfrastructure
{
    public interface IRepository
    {
        Client CreateNewClient(string ZODIAC_SIGN, string FIRST_NAME, string LAST_NAME, string BIRTH_DATE, string PHONE_NUMBER);
        string GetUserZodiac(int USER_ID);
    }
}