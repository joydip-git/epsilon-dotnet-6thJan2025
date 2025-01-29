// See https://aka.ms/new-console-template for more information
using EfDemo.Models;
using EfDemo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.EntityFrameworkCore.ChangeTracking;

Console.WriteLine("Hello, EF Core!");

//service container
IServiceCollection container = new ServiceCollection();
IServiceProvider provider = container
    .AddDbContext<ProductDbContext>
    (
        (DbContextOptionsBuilder builder) =>
        {
            builder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=sampledb;user id=sa;password=sqlserver2024;TrustServerCertificate=True");
        }
    )
    .BuildServiceProvider();

//var dbContext = new ProductDbContext();
var dbContext = provider.GetService<ProductDbContext>();

//fetching the records from database table
//records variable == database table in application
var records = dbContext?.Products;

//add new record
//var newProduct = new Product { Name = "One Plus 13", Description = "new mobile from One Plus", Price = 56999 };

//EntityEntry<Product> added = records.Add(newProduct);
//records?.Add(newProduct);
//int? result = dbContext?.SaveChanges();
//Console.WriteLine(result.HasValue && result.Value > 0 ? "added" : "not added");

//update an existing record
//var products = records.Where(p => p.Id == 100);
//if (products.Any())
//{
//    var found = products.First();
//    found.Name = "Dell XPS 15";
//    found.Price = 162000;
//    int result = dbContext.SaveChanges();
//    Console.WriteLine(result > 0 ? "updated" : "not updated");
//}
//else
//    Console.WriteLine($"product with id: 100 is not found");

//delete an existng record
//var products = records.Where(p => p.Id == 111);
//if (products.Any())
//{
//    var found = products.First();
//    records.Remove(found);
//    int result = dbContext.SaveChanges();
//    Console.WriteLine(result > 0 ? "deleted" : "not deleted");
//}
//else
//    Console.WriteLine($"product with id: 111 is not found");


//displaying the records
if (records?.Count() > 0)
    records.ToList().ForEach(p => Console.WriteLine(p));
else
    Console.WriteLine("No Records");