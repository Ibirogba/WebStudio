using Microsoft.EntityFrameworkCore;
using WebStudio.Application_core.Database_Context;
using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Interface;


namespace WebStudio.Application_core.Services
{
    public class CompanyRepository:RepositoryBase<Company>,ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(c => c.Name).ToListAsync();

       public async Task<Company> GetCompanyByIdAsync(Guid companyid, bool trackChanges)
        
        {
            return await FindByCondition(c => c.id.Equals(companyid), trackChanges).SingleOrDefaultAsync();
        }

        public void CreateCompany(Company company) => Create(company);

        public void DeleteCompany(Company company) => Delete(company);
    }
}
