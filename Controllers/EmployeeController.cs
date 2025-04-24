using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStudio.Application_core.Interface;
using AutoMapper;
using WebStudio.Application_core.Dto;
using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Paging;

namespace WebStudio.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeController(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;


        }
        [HttpGet]
       public  async Task<IActionResult> GetEmployeesForCompany(Guid id, [FromQuery] EmployeeParameter employeeParameter )
        {
            var Company = await  _repositoryManager.Company.GetCompanyByIdAsync(id, trackChanges: false);
            if (Company == null)
            {
                return NotFound();
            }
            var Employee = await _repositoryManager.Employee.GetEmployeesAsync(id, employeeParameter,trackChanges: false);
            if (Employee == null)
            {
                return NotFound();
            }
            
            var EmployeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(Employee);

            return Ok(EmployeeDto);

        }

        [HttpGet("{id}", Name ="GetEmployeeForCompany")]
        public async Task <IActionResult> GetEmployeesForCompany(Guid companyId, Guid id)
        {
            var Company = await _repositoryManager.Company.GetCompanyByIdAsync(companyId, trackChanges: false);
            if(Company== null)
            {
                return NotFound();
            }
            var Employee = await _repositoryManager.Employee.GetEmployeebyIdAsync(companyId, id, trackChanges: false);
            if (Employee == null)
            {
                return NotFound();
            }
            var Employee_dto = _mapper.Map<EmployeeDto>(Employee);
            return Ok(Employee_dto);
        }
        [HttpPost]
        public async Task <IActionResult> CreateEmployeeForCompany(Guid CompanyId, [FromBody]EmployeeForCreationDto employee)
        {
            if (employee == null)
            {
                return BadRequest("EmployeeForCreationDto object is null");
            }
            var company = await _repositoryManager.Company.GetCompanyByIdAsync(CompanyId, trackChanges: false);
            if (company == null)
            {
                return NotFound();
            }
            var employeeEntity = _mapper.Map<Employee>(employee);
            _repositoryManager.Employee.CreateEmployeeForCompany(CompanyId, employeeEntity);
            _repositoryManager.SaveAsync();
            var employeeToReturn = _mapper.Map<EmployeeDto>(employee);
            return CreatedAtRoute("GetEmployeeForCompany", new { CompanyId, id = employeeToReturn.id }, employeeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task< IActionResult> DeleteEmployee(Guid companyId, Guid id)
        {
            var Company = await _repositoryManager.Company.GetCompanyByIdAsync(companyId, trackChanges: false);
            if (Company == null)
            {
                return NotFound();
            }
            var EmployeeForCompany = await _repositoryManager.Employee.GetEmployeebyIdAsync(companyId, id, trackChanges: false);
            if (EmployeeForCompany == null)
            {
                return NotFound();
            }
            _repositoryManager.Employee.DeleteEmployee(EmployeeForCompany);
            _repositoryManager.SaveAsync();

            return NoContent();

        }

        public async Task<IActionResult> UpdateEmployedForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employee)
        {
            if (employee == null)
            {
                return BadRequest("EmployeeForUpdateDto object is null ");
            }

            var Company =  await _repositoryManager.Company.GetCompanyByIdAsync(companyId, trackChanges: false);
            if (Company == null)
            {
                return NotFound();
            }

            var employeeEntity = await _repositoryManager.Employee.GetEmployeebyIdAsync(companyId, id, trackChanges: false);
            if(employeeEntity == null)
            {
                return NotFound();
            }
            _ = _mapper.Map(employee, employeeEntity);
            _repositoryManager.SaveAsync();

            return NoContent();
        }


    }
}
