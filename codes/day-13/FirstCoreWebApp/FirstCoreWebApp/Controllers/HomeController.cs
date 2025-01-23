using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World!!!";
        }
        public string Hello(string? x)
        {
            return $"hello {x ?? "NA"}";
        }
    }
}
