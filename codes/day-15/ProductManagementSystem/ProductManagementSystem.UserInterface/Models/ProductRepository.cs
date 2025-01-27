using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductRepository : IProductRepository
    {
        public Product Delete(int id)
        {
            return new Product { Name = "" };
        }

        public Product? Fetch(int id)
        {
            //var query = "select product_id as ID, product_name as NAME,product_description as DESCRIPTION,product_price as PRICE from products where product_id=@id";
            var query = "sp_GetProductById";
            string connectionString = "server=joydip-pc\\sqlexpress;database=epislondb;user id=sa; password=sqlserver2024;TrustServerCertificate=true;";
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            Product? product = null;
            try
            {
                connection = new(connectionString);
                command = connection.CreateCommand();
                command.CommandText = query;
                //by default
                //command.CommandType = CommandType.Text;
                //of using a stored procedure
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter idParam = new()
                {
                    ParameterName = "@id",
                    Value = id,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                };
                command.Parameters.Add(idParam);

                connection.Open();
                reader = command.ExecuteReader();
                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product = new()
                        {
                            Name = (string)reader.GetValue("NAME"),
                            Id = (int)reader.GetValue("ID"),
                            Description = (string)reader.GetValue("DESCRIPTION"),
                            Price = (decimal)reader.GetValue("PRICE")
                        };
                    }
                }
                return product;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public List<Product>? FetchAll()
        {
            var query = "select product_id, product_name,product_description,product_price from products";
            string connectionString = "server=joydip-pc\\sqlexpress;database=epislondb;user id=sa; password=sqlserver2024;TrustServerCertificate=true;";
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            List<Product>? products = null;
            try
            {
                connection = new(connectionString);
                command = new(query, connection);

                connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    products = [];
                    while (reader.Read())
                    {
                        Product product = new
                        ()
                        {
                            Id = (int)reader.GetValue("product_id"),
                            Name = (string)reader.GetValue(1),
                            Description = (string)reader[2],
                            Price = (decimal)reader["product_price"]
                        };
                        products.Add(product);
                    }
                }
                //connection.State.ToString();
                return products;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public List<Product> FilterProductsByName(string name = "")
        {
            return [new Product { Name = "" }];
        }

        public Product Insert(Product entity)
        {
            return new Product { Name = "" };
        }

        public Product Update(int id, Product entity)
        {
            return new Product { Name = "" };
        }
    }
}
