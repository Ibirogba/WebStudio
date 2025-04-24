using WebStudio.Application_core.Entities;


namespace WebStudio.Application_core.Interface
{
    public interface ICompanyRepository
    {
        //Get AllCompanies
        Task<IEnumerable<Company>>GetAllCompaniesAsync(bool trackChanges);
       Task <Company> GetCompanyByIdAsync(Guid companyid, bool trackChanges);


        void CreateCompany(Company company);
       
        void DeleteCompany(Company company);
    }
}
