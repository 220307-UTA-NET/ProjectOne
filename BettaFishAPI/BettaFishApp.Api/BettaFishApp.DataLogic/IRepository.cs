using BettaFishApp.InformationLogic;

namespace BettaFishApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<BettaType>> GetAllBettaType();
        Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFacts();
      
    }
}