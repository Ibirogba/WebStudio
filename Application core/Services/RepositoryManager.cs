using WebStudio.Application_core.Interface;
using WebStudio.Application_core.Database_Context;


namespace WebStudio.Application_core.Services
{
    //I created  a manager to be able to save multiple instance of both the employee and company repository , it is having a final say on each decision made by the two repository
    //_repository.Company.Create(company)
    //_repository.Company.Create(anotherCompany)
    //_repository.Employee.Update(employee)
    //_repository.Employee.Update(anotherEmployee)
    //_repository.Employee.Delete(oldCompany)
    //_repository.Save().
    //This works like UnitOfWork pattern but the only difference here is that am only saving, am not committing, rollbacking and disposing.
    public class RepositoryManager:IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;

        }

        public ICompanyRepository Company
        {
            get
            {
                if (companyRepository == null)
                
                    companyRepository = new CompanyRepository(_repositoryContext);
                    return companyRepository;
                
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(_repositoryContext);
                return employeeRepository;

            }
        }

        public void SaveAsync() => _repositoryContext.SaveChanges();
    }
}
