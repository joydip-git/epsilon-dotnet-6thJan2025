using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductManagementSystem.APIService.Mapping;
using ProductManagementSystem.APIService.Models;
using ProductManagementSystem.Entities;
using ProductManagementSystem.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(AutoMapperPofile));
builder.Services.AddDbContext<EpsilonDbContext>(
    (DbContextOptionsBuilder options) =>
    {
        var connectionString = builder.Configuration.GetConnectionString("EpsilonDbConStr");
        options.UseSqlServer(connectionString);
    }
    );
builder.Services.AddScoped<IEpsilonDbRepository<Product, int>, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITokenManager, JwtTokenManager>();
//not by default included in the web api related services through AddControllers() method
var schemaName = JwtBearerDefaults.AuthenticationScheme;
//schemaName = Bearer
builder.Services
    .AddAuthentication(schemaName)
    .AddJwtBearer(
    (JwtBearerOptions bearerOptions) =>
    {
        string? key = builder.Configuration["Jwt:SecretKey"];
        bearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key ?? "productmanagementapiserverissuerkeyforjwttoken"))
        };
    });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
