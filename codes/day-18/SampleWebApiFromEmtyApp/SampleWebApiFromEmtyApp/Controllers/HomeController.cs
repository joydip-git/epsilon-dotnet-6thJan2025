using Microsoft.AspNetCore.Mvc;
using SampleWebApiFromEmtyApp.Models;

namespace SampleWebApiFromEmtyApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("welcome/{name}")]
        public string Index(string name)
        {
            return $"welcome {name} to RESTful Web API app";
        }

        [HttpGet]
        [Route("welcome")]
        public string Index()
        {
            return $"welcome to RESTful Web API app";
        }

        [HttpPost]
        [Route("welcome")]        
        public ActionResult<Person> Index([FromBody] Person person)
        {
            return Ok(person);
        }
    }
}
