using LibraryApp.BusinessLogias;

namespace LibraryApp.DataLogias
{
    public interface IRepository
    {
        Task<IEnumerable<Member>> LookUpAllMemberInfo();
    }
}