using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductManagementSystem.UserInterface.Models
{
    public class ProductRepository : IProductRepository
    {
        //public IConfiguration? Configuration { get; set; }
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductRepository> _logger;
        private readonly string? connectionString;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("EpsilonDbConStr");
            _logger = logger;
        }

        public int Delete(int id)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            try
            {
                CheckConnectionString();
                connection = new(connectionString);

                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _configuration.GetSection("StoredProcedures").GetValue<string>("DELETE_PRODUCT");

                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result;
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

        public Product? Fetch(int id)
        {
            //var query = "sp_GetProductById";
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            Product? product = null;
            try
            {
                if (connectionString != null && connectionString != string.Empty)
                {
                    connection = new(connectionString);
                    command = connection.CreateCommand();
                    var query = _configuration.GetSection("StoredProcedures").GetValue<string>("GET_A_PRODUCT");
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter idParam = new()
                    {
                        ParameterName = "@id",
                        Value = id,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    };
                    //SqlParameterCollection parameters = command.Parameters;
                    //parameters.Add(idParam);
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
                else
                    throw new Exception("connection string is either null or empty");
            }
            catch (Exception)
            {
                //_logger.LogError("");
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
            //var query = "sp_GetProducts";           
            SqlConnection? connection = null;
            SqlCommand? command = null;
            SqlDataReader? reader = null;
            List<Product>? products = null;
            try
            {
                if (connectionString != null && connectionString != string.Empty)
                {
                    connection = new(connectionString);
                    var query = _configuration.GetSection("StoredProcedures").GetValue<string>("GET_ALL_PRODUCTS");
                    command = new(query, connection);
                    command.CommandType = CommandType.StoredProcedure;

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
                else
                    throw new Exception("connection string is either null or empty");
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

        public Product? Insert(Product entity)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            try
            {
                CheckConnectionString();
                connection = new(connectionString);

                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _configuration.GetSection("StoredProcedures").GetValue<string>("ADD_PRODUCT");

                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@desc", entity.Description);
                command.Parameters.AddWithValue("@price", entity.Price);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    return null;
                else
                    return entity;
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

        public Product? Update(int id, Product entity)
        {
            SqlConnection? connection = null;
            SqlCommand? command = null;
            try
            {
                CheckConnectionString();
                connection = new(connectionString);

                command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = _configuration.GetSection("StoredProcedures").GetValue<string>("UPDATE_PRODUCT");

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", entity.Name);
                command.Parameters.AddWithValue("@desc", entity.Description);
                command.Parameters.AddWithValue("@price", entity.Price);

                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    return null;
                else
                    return entity;
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

        private void CheckConnectionString()
        {
            if (connectionString == null || connectionString == string.Empty)
                throw new Exception("connection string is either null or empty");
        }
    }
}
