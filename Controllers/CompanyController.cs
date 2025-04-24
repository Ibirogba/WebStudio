using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStudio.Application_core.Interface;
using WebStudio.Application_core.Dto;
using WebStudio.Application_core.Entities;

namespace WebStudio.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;


        public CompanyController(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {


            var companies = await _manager.Company.GetAllCompaniesAsync(trackChanges: false);

            if (companies == null)
            {
                return NotFound();
            }
            var companiesDTO = _mapper.Map<IEnumerable<CompanyDto>>(companies);


            return Ok(companiesDTO);

        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<IActionResult> GetCompanyId(Guid id)
        {
            var Company = await _manager.Company.GetCompanyByIdAsync(id, trackChanges: false);
            if (Company == null)
            {
                return NotFound();
            }
            var companyDto = _mapper.Map<CompanyDto>(Company);
            return Ok(companyDto);
        }


        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyforCreationDto company)
        {
            if (company == null)
            {
                return BadRequest("CompanyForCreationDto object  is null");
            }
            var CompanyEntity = _mapper.Map<Company>(company);
            _manager.Company.CreateCompany(CompanyEntity);
            _manager.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(CompanyEntity);
            return CreatedAtRoute("GetCompanyById", new { id = companyToReturn.Id }, companyToReturn);
        }

         [HttpDelete]

         public async Task<IActionResult> DeleteCompanyId(Guid id)
        {
            var Company =  await _manager.Company.GetCompanyByIdAsync(id, trackChanges: false);
            if (Company == null)
            {
                return NotFound();
            }

            _manager.Company.DeleteCompany(Company);
            _manager.SaveAsync();

            return NoContent();
        }
    }
}
