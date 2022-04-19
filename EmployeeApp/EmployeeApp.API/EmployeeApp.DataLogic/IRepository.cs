using EmployeeApp.BusinessLogic;

namespace EmployeeApp.DataLogic
{
    public interface IRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Employee>> GetEmployeeAsync(int Id);
        Task<IEnumerable<Employee>> AddEmployeeAsync(Employee emp);
        Task<IEnumerable<Employee>> UpdateEmployeeAsync(int Id, Employee emp);
        Task<IEnumerable<Employee>> DeleteEmployeeAsync(int Id);

        Task<IEnumerable<Location>> GetLocationsAsync();
    }

}