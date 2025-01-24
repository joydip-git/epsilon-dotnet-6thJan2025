using FirstCoreWebApp.Infrastructure;
using FirstCoreWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebApp.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonManager _personManager;
        //built-in logger
        private readonly ILogger<PersonController> _logger;
        //custom logger
        private readonly IRequestLogger _requestLogger;

        public PersonController(IPersonManager personManager, ILogger<PersonController> logger, IRequestLogger requestLogger)
        {
            _personManager = personManager;
            _logger = logger;
            _requestLogger = requestLogger;
        }

        // public ViewResult Index([FromRoute(Name ="x")]int? id)
        public IActionResult Index([FromRoute(Name ="x")]int? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var person = _personManager.Get(id.Value);
                    //return person?.Name ?? $"No record with id:{id} is available";
                    return this.View(person);
                }
                else
                    return this.NotFound();
            }
            catch (Exception ex) 
            {
                //built-in logger
                _logger.LogError(ex.ToString());
                //custom logger
                _requestLogger.Log($"Exception: {ex}, {Environment.NewLine},Logged At: {DateTime.Now}");
                //return ex.Message;
                return this.Problem(detail: ex.Message, statusCode: 500);
            }
        }
    }
}
