using LibraryApp.BusinessLogias;

namespace LibraryApp.DataLogias
{
    public interface IRepository
    {
        Task<IEnumerable<Member>> LookUpAllMemberInfo();
        Task<IEnumerable<Member>> GetMemberInfoByName(string fName, string lName);
        Task<IEnumerable<Book>> GetAllBooks();
    }
}