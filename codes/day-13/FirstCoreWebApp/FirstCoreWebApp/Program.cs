namespace FirstCoreWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("this is going to be a host for web app..");

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            //spawned internal web server
            //set up request-response pipeline
            //default middlewares will be applied on the pipeline
            //port number assignment for the web app
            WebApplication app = builder.Build();

            //name => route parameter
            //https://localhost:5005/home/hello/joydip
            //controller = home => HomeController
            //action = hello => Hello(string? name)
            //name/x (route-parameter) = joydip (route data)
            app.MapControllerRoute(
                "default",
                "{controller}/{action}/{x?}",
                new { controller = "Home", action = "Index" }
                );

            //endpoint
            //http://localhost:5005
            //app.MapGet("/", () => "Hello World!");

            //this method blocks the main thread until the shutdown
            app.Run();
        }
    }
}
