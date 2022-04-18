using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business__logic;
using Microsoft.AspNetCore.Mvc;

namespace irepository
{
    public interface Irepository
    {
        Task<IEnumerable<inventory>> getinvetory(int storeid);
        Task<ContentResult> registercustomers(string name, string lastname);
        Task<int> getcustomerid(string name, string lastname);

        Task<IEnumerable<registercustomers>> getregisteredcustomers(int customerid);

        Task<ContentResult> registerorders(string name, string lastname, int storeid, DateTime date, string customerid, int number_of_pieces);

        Task<ContentResult> Updateinventory(List<inventory> updateinventory);
    }
}
