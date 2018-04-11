using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace PHFoodManagement
{
    public class ProductDB
    {
        SqlConnection conn = new SqlConnection();
        string connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        string getProducts = "SELECT * FROM Product";
        //string addProducts = "INSERT INTO Product(productName, organic, price, description) VALUES(;

        public List<Product> GetProducts()
        {
            OpenConnection();
            List<Product> products = new List<Product>();
            using (conn)
            {
                using (SqlCommand command = new SqlCommand(getProducts, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product currProd = new Product
                        {
                            //ProductId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Organic = bool.Parse(reader.GetString(2)),
                            Price = (decimal)reader.GetSqlMoney(3),
                            Description = reader.GetString(4)
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
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO Product VALUES(@productName, @organic, @price, @description)", conn))
                        {
                            command.Parameters.Add(new SqlParameter("productName", name));
                            command.Parameters.Add(new SqlParameter("organic", org));
                            command.Parameters.Add(new SqlParameter("price", price));
                            command.Parameters.Add(new SqlParameter("description", dec));
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
