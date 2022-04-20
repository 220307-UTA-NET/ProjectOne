using LibraryApp.BusinessLogias;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.DataLogias
{
    public interface IRepository
    {
        Task<IEnumerable<Member>> LookUpAllMemberInfo();
        Task<IEnumerable<Member>> GetMemberInfoByName(string fName, string lName);
        Task<IEnumerable<Book>> GetAllBooks();
        Task CreateMember(Member member);
        Task<IEnumerable<Book>> GetABook(int specBookID);
        Task<IEnumerable<Rental>> ViewAllRentals();
        Task<List<Rental>> ViewUserRentals(int ID);
        //Task<int> LookUpABookInOutAsync(int bookID);
        Task CreateRental(Rental rental);
    }
}