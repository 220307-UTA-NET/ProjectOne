using BettaFishApi.Logic;

namespace BettaFishApi.DataLogic
{
    public interface IRepository
    {

        Task<IEnumerable<BettaType>> GetAllBettaTypeAsync();
        Task<IEnumerable<BettaFunFacts>> GetAllBettaFunFactsAsync();
        Task WebRegistration(BettaRegistration bettaregistration);
        Task GetBettaStories(BettaStories bettastories);
        Task <List<BettaType>>GetBettaDescriptionAsync();
        Task<List<BettaStories>> GetAllBettaFanStoriesAsync();
        Task<List<BettaRegistration>> GetAllWebRegistrationAsync();
        Task<List<BettaStoreLocation>> GetAllStoreLocationAsync();


    }
}