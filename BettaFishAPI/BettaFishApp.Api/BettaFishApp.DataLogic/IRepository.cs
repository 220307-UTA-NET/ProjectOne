using BettaFishApp.InformationLogic;

namespace BettaFishApp.DataLogic
{
    public class IRepository
    {
        public Task<IEnumerable<BettaType>> GetAllBettaType(int y, string b, string c)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFacts(int x, string a)
        {
            throw new NotImplementedException();
        }


    }
}