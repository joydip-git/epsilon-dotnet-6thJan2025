using FirstCoreWebApp.Middlewares;

namespace FirstCoreWebApp.PiplelineExtensions
{
    public static class WebApplicationExtension
    {
        //
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
        {
            //to apply the custom middleware
            return app.UseMiddleware<RequestLoggingMiddleware>();
        }
    }
}
