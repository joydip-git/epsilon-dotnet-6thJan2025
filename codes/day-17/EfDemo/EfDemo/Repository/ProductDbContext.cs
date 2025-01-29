using EfDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Repository
{
    public class ProductDbContext : DbContext
    {
        //uncomment this after the Migration files generated and database is updated
        public ProductDbContext(DbContextOptions<ProductDbContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }

        //comment this method after the migration and database update and prefer to supply the connection string through DbContextOptions<T> to the constructor of this DbContext class

        //base class virtual method being overriden here
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"server=joydip-pc\sqlexpress;database=sampledb;user id=sa;password=sqlserver2024;TrustServerCertificate=True");
        //}
    }
}
