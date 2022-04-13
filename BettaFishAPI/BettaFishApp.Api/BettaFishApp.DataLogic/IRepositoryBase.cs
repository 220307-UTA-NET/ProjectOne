using BettaFishApp.InformationLogic;

namespace BettaFishApp.DataLogic
{
    public abstract class IRepositoryBase
    {
        public abstract Task<IEnumerable<BettaFunFacts>> GetBettaFunFacts(int fact_ID);
    }
}