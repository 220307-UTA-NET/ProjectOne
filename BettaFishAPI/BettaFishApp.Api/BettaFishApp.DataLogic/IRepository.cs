using BettaFishApp.InformationLogic;
using System.Collections;

namespace BettaFishApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<BettaType>> GetAllBettaTypeAsync();
        Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFactsAsync();
        Task WebRegistration(Registration registration);

    }
}