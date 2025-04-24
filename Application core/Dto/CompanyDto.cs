namespace WebStudio.Application_core.Dto
{// We are using this to get Company data
    public class CompanyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string FullAddress { get; set; }
    }
}
