using ComputerStoreApp.BusinessLogic;

namespace ComputerStoreApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Computer_Make>> GetAllComputers();
        
        //Task<IEnumerable<Computer_Make>> GetComputer(string Name);

        Task<IEnumerable<Computer_Make>> AddComputer();
    }
}