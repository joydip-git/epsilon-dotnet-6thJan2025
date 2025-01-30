WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//web api (with just controllers no views) and core mvc services
builder.Services.AddControllers();

WebApplication app = builder.Build();

app.MapControllers();

app.Run();
