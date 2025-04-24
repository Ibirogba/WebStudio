using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStudio.Application_core.Entities;

namespace WebStudio.Application_core.Configuration
{
    public class CompanyConfiguration:IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                new Company
                {
                    id=  new Guid("76032384-50ad-4903-9889-f0e95ac9eedf"),
                    Name = "WALURE CAPITAL",
                    Address = "75 Ogunnusi Road, Off Ojodu-Berger, Ogba, Lagos-State",
                    Country = "NIGERIA"

                },

                new Company
                {
                    id=new Guid("8d19dc2d-f84a-4ddb-9980-5f9326661dd0"),
                    Name = "VISION STEP",
                    Address = "62 Ajayi Road, Ogba, Ikeja",
                    Country = "NIGERIA",
                }








                );
        }
    }
}
