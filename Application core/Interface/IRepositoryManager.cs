namespace WebStudio.Application_core.Interface
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }

        void SaveAsync();
    }
}
