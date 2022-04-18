using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.Model;

namespace Project1.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<IEnumerable<Account>> GetAllAccounts();
        Task RegisterUser(User bankUser);
        Task RegisterAccount(Account bankAccount);
        Task UpdateUser(User bankUser);
        Task UpdateAccount(Account bankAccount);
        Task DeleteUser(User bankUser);
        Task DeleteAccount(Account bankAccount);
    }
}
