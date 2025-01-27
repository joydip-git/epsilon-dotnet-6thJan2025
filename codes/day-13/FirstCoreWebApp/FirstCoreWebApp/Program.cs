using FirstCoreWebApp.Infrastructure;
using FirstCoreWebApp.Models;
using FirstCoreWebApp.PiplelineExtensions;

namespace FirstCoreWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("this is going to be a host for web app..");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            //dependency injection
            //you don't need to create instance of conatiner (ServiceCollection) as well as provider manually, since WebApplicaionBuilder will provide you both the container and provider for services
            IServiceCollection services = builder.Services;

            //registering the required service [RequestLogger] which is need by the RequestLoggingMiddleware class instance
            services.AddSingleton<IRequestLogger, RequestLogger>();

            services.AddScoped<IPersonManager, PersonManager>();

            //registering services which is required to process controller-based web app request as singleton instances, which will also create service provider for the same services          
            //services.AddControllers();

            //will provide required services for m-v-c application with support for views
            services.AddControllersWithViews();

            //spawned internal web server
            //set up request-response pipeline
            //default middlewares will be applied on the pipeline
            //port number assignment for the web app
            WebApplication app = builder.Build();

            //applying the custom RequestLoggingMiddleware on the pipline
            //app.UseRequestLogger();

            //applying a middleware which processes a request for controller-based web app
            //name => route parameter
            //https://localhost:5005/home/hello/joydip
            //controller = home => HomeController
            //action = hello => Hello(string? name)
            //name/x (route-parameter) = joydip (route data)
            //app.MapControllerRoute(
            //    "default",
            //    "{controller}/{action}/{x?}",
            //    new { controller = "Home", action = "Index" }
            //    );

            app.MapControllerRoute(
               "default",
               "{controller}/{action}/{x?}"
               );


            //endpoint
            //http://localhost:5005
            //app.MapGet("/", () => "Hello World!");

            //this method blocks the main thread until the shutdown
            app.Run();
        }
    }
}
