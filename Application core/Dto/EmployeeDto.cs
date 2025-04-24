namespace WebStudio.Application_core.Dto
{// We are using this to get employee data
    public class EmployeeDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string Position { get; set; }
    }
}
