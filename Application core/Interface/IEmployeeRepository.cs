using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Paging;
namespace WebStudio.Application_core.Interface
{
    public interface IEmployeeRepository
    {
      Task<PageList<Employee>> GetEmployeesAsync(Guid id,EmployeeParameter employeeParameter ,bool trackChanges);
        Task<Employee> GetEmployeebyIdAsync(Guid CompanyId, Guid id, bool trackChanges);

        void CreateEmployeeForCompany(Guid id, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
