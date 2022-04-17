using BettaFishApp.Logic;

namespace BettaFishApp.DataLogic
{
    public interface IRepository
    {

        Task<IEnumerable<BettaType>> GetAllBettaTypeAsync();
        Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFactsAsync();
        Task WebRegistration(BettaRegistration bettaregistration);

    }
}