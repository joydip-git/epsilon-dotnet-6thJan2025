using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebApp.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("index")]
        public string Index()
        {
            return "Hello World!!!";
        }

        [Route("welcome/{x?}")]
        public string SayHello(string? x)
        {
            return $"hello {x ?? "NA"}";
        }
    }
}
