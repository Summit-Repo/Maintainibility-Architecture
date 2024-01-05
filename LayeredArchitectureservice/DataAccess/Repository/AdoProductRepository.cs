using DataAccess.Domain;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AdoProductRepository
    {
        private readonly string connectionString;

        public AdoProductRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("artifactDbContext");
        }

        public Product GetProductById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };

                            return product;
                        }
                    }
                }
            }

            return null;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Products";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"].ToString(),
                                Price = Convert.ToInt32(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"])
                            };

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Products (Name, Price, Quantity) VALUES (@Name, @Price, @Quantity)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);

                    command.ExecuteNonQuery();
                }
            }
        }



        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Products SET Name = @Name, Price = @Price, Quantity = @Quantity WHERE ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Quantity", product.Quantity);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void DeleteProduct(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Products WHERE ProductId = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}






