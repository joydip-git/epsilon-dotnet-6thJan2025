using ProductManagementSystem.UserInterface.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddControllersWithViews();

//ConfigurationManager manager = builder.Configuration;
//IConfigurationSection connectionStringSection = manager.GetSection("ConnectionStrings");
//string? connectionString = connectionStringSection.GetValue<string>("EpsilonDbConStr");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}/{id?}"
    );

app.Run();
