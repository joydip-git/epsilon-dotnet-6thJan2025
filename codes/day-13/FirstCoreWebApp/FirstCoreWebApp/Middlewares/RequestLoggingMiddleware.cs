using FirstCoreWebApp.Infrastructure;
using System.Text;

namespace FirstCoreWebApp.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IRequestLogger _logger;

        public RequestLoggingMiddleware(RequestDelegate requestDelegate, IRequestLogger logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            HttpRequest request = context.Request;
            string path = request.Path;
            DateTime logTime = DateTime.Now;

            StringBuilder builder = new();
            builder.Append($"Request path: {path}");
            builder.Append(Environment.NewLine);
            builder.Append($"Logged at: {logTime}");

            _logger.Log(builder.ToString());   

            //hand over to the next middleware
            await _requestDelegate(context);
        }
    }
}
