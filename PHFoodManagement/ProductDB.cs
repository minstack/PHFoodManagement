using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PHFoodManagement
{
    public class ProductDB
    {
        MySqlConnection conn = new MySqlConnection();
        string connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        string getProducts = "SELECT * FROM product";
        //string addProducts = "INSERT INTO Product(productName, organic, price, description) VALUES(;

        public List<Product> GetProducts()
        {
            OpenConnection();
            List<Product> products = new List<Product>();
            using (conn)
            {
                using (MySqlCommand command = new MySqlCommand(getProducts, conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product currProd = new Product
                        {
                            Id = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = (decimal)reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            Organic = bool.Parse(reader.GetString(4))
                        };
                        products.Add(currProd);
                    }
                }
            }

            return products;
        }

        public bool AddProduct(string name, bool org, decimal price, string dec)
        {
            OpenConnection();
            
                using (conn)
                {
                    
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand(
                            "INSERT INTO product (productName, price, description, organic) VALUES(@productName, @price, @description, @organic)", conn))
                        {
                            command.Parameters.Add(new MySqlParameter("productName", name));
                            command.Parameters.Add(new MySqlParameter("organic", org));
                            command.Parameters.Add(new MySqlParameter("price", price));
                            command.Parameters.Add(new MySqlParameter("description", dec));
                            command.ExecuteNonQuery();
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex.InnerException;
                        
                    }
                }
            conn.Close();
            return true;
        }

        public bool updateProduct(int id, string name, bool org, decimal price, string dec)
        {
            OpenConnection();

            using (conn)
            {

                try
                {
                    using (MySqlCommand command = new MySqlCommand(
                        "UPDATE product SET productName = @nm, price = @pr, description = @ds, organic = @or WHERE productId = @id)", conn))
                    {
                        command.Parameters.Add(new MySqlParameter("nm", name));
                        command.Parameters.Add(new MySqlParameter("or", org));
                        command.Parameters.Add(new MySqlParameter("pr", price));
                        command.Parameters.Add(new MySqlParameter("ds", dec));
                        command.Parameters.Add(new MySqlParameter("id", id));
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;

                }
            }
            conn.Close();
            return true;
        }

        private void OpenConnection()
        {
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
        }
    }
}
