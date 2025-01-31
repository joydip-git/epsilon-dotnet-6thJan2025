using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.APIService.Mapping;
using ProductManagementSystem.Entities;
using ProductManagementSystem.Repository;

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

app.UseAuthorization();

app.MapControllers();

app.Run();
