using StreetStyleApp.BusinessLogic;

namespace StreetStyleApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Clothes>> GetAllClothes();
        Task<IEnumerable<Clothes>> AddClothes(Clothes clo);
        Task<IEnumerable<Clothes>> DeleteClothes(int ID);
    }
}