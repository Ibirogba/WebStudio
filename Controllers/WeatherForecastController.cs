using Microsoft.AspNetCore.Mvc;
using WebStudio.Application_core.Interface;

namespace WebStudio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
      

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepositoryManager _manager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IRepositoryManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult<IEnumerable<string>> Get()
        {
            _manager.Company.GetType();
            _manager.Employee.GetType();

            return new string [] { "value1","value2" };
              
        }
    }
}
