using WebStudio.Application_core.Interface;
using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Database_Context;
using Microsoft.EntityFrameworkCore;
using WebStudio.Application_core.Paging;


namespace WebStudio.Application_core.Services
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }

        //Okay , the easiest way to explain this is that let say we want to get the third page of our website,counting  20 as the number of results we want,
        //That would mean we want to skip the first ((3-1)*20)=40 , then take the next 20 and return them to the caller
        public async Task<PageList<Employee>> GetEmployeesAsync(Guid id,EmployeeParameter employeeParameter ,bool trackChanges)
        {
            var employees= await FindByCondition(e => e.CompanyId.Equals(id), trackChanges)
                .OrderBy(e => e.Name).ToListAsync();

            return PageList<Employee>.ToPagedList(employees, employeeParameter.PageNumber, employeeParameter.PageSize);
                                                                             
        }

        public async Task< Employee > GetEmployeebyIdAsync(Guid companyId, Guid id, bool trackChanges) => await FindByCondition(e => e.CompanyId.Equals(id) && e.id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid id, Employee employee)
        {
            employee.id = id;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            Delete(employee);
        }
    }  
}
