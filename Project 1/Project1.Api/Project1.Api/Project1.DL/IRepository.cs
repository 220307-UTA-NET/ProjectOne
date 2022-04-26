using Project1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DL
{
    public interface IRepository
    {
        Task<IEnumerable<ERCOT>> GetERCOTEnergy();
        Task<IEnumerable<ERCOT>> GetEnergyERCOTMonth(string Month);
        Task<IEnumerable<NEISO>> GetEnergyNEISO();
        Task PostNEISOEnergyReport(NEISOEnergyReport HourlyEnergyReport);
        Task PutNEISOEnergyReport(NEISO HourlyEnergyReport);
        Task DeleteNEISOEnergyReport(int id);
    }
}