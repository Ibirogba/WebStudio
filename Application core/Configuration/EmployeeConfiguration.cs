using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStudio.Application_core.Entities;

namespace WebStudio.Application_core.Configuration
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    id= new Guid("35a06106-30f5-44e1-8998-014fc629db35"),
                    Name= "Ibirogba Taiwo",
                    Age=22,
                    Position= "Software Engineer",
                    CompanyId= new Guid("76032384-50ad-4903-9889-f0e95ac9eedf")
                },

                new Employee
                {
                    id= new Guid("a780950f-9138-46c9-93aa-cec6c227f38a"),
                    Name= "Mercy Vivian",
                    Age= 25,
                    Position = "Software Engineer",
                    CompanyId= new Guid("76032384-50ad-4903-9889-f0e95ac9eedf")
                },

                new Employee
                {
                    id= new Guid("b60d66c9-528e-4874-bad8-0c6e7e73bcbe"),
                    Name= "Pearson Goodness",
                    Age= 26,
                    Position= "Sales Person",
                    CompanyId= new Guid("8d19dc2d-f84a-4ddb-9980-5f9326661dd0")  
                }
                
                
                
                
                
                
                );
        }
    }
}
