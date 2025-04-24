using AutoMapper;
using WebStudio.Application_core.Entities;
using WebStudio.Application_core.Dto;

namespace WebStudio.Application_core.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', new object?[] { x.Address, x.Country })));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyforCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();

        }
    }
}
