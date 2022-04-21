using OlympicGames.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Onboarding>> GetAbout();
        Task<IEnumerable<Onboarding>> GetMedalInfo();
        //Task PostConsumerToDatabase(string name);
        Task PostConsumerToDatabase(Consumer consumer);
        Task PostConsumerToDatabase(string name);
        Task<IEnumerable<Country>> GetCountryMedalInfo();
        //Task PostConsumerToDatabase(string full_name);
    }
}
