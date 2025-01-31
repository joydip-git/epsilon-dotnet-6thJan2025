using ProductManagementSystem.UserInterface.Filters;
using ProductManagementSystem.UserInterface.Models;
using System.Net.Http.Headers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//builder.Services.AddHttpClient<IUserApiManager, UserApiManager>(
//    httpOptions =>
//    {
//        httpOptions.BaseAddress = new Uri(builder.Configuration["APIRequestUrls:AuthAPIUrl"] ?? "http://localhost:5030/api/auth");
//    }
//);
builder.Services.AddSingleton<IUserApiManager, UserApiManager>();

//builder.Services.AddHttpClient<IProductApiManager, ProductApiManager>(
//    httpOptions =>
//    {
//        httpOptions.BaseAddress = new Uri(builder.Configuration["APIRequestUrls:ProductAPIUrl"] ?? "http://localhost:5030/api/productapi");
//        httpOptions.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken.Token);
//    }
//);
builder.Services.AddSingleton<IProductApiManager, ProductApiManager>();

builder.Services.AddControllersWithViews(
//options =>
//{
//    options.Filters.Add<ProtectedRouteFilterAttribute>();
//}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{id?}",
//    new { controller = "Product", action = "Index" }
//    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{routedata?}"
    );


app.Run();
