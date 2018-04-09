using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class PHFoodDB
    {
        SqlConnection conn = new SqlConnection();
        string connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        string allClientsQuery = "SELECT * FROM ClientWithNoFks";
        string allProductsQuery = "SELECT * FROM Product";

        public PHFoodDB ()
        {
            conn.ConnectionString = connString;
        }

        public List<Client> GetClients()
        {
            OpenConnection();

            List<Client> clients = new List<Client>();

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(allClientsQuery, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client currClient = new Client {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            phoneNumber = reader.GetString(2),
                            address = reader.GetString(3),
                            additionalDiscount = (decimal)reader.GetSqlMoney(4),
                            type = (ClientType) Enum.Parse(typeof(ClientType), reader.GetString(5)),
                            zone = (Zone) Enum.Parse(typeof(Zone), reader.GetString(6))
                        };

                        clients.Add(currClient);
                    }
                }
            }

            return clients;
            
        }

        public List<Product> GetProducts()
        {
            OpenConnection();

            List<Product> products = new List<Product>();

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(allProductsQuery, conn))
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
