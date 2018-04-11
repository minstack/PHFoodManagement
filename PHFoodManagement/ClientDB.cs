using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PHFoodManagement
{
    class ClientDB
    {
        MySqlConnection conn = new MySqlConnection();

        string connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        //string allClientsQuery = "SELECT * FROM ClientWithNoFks";

        //string connString = "Server =yoosungm.dev.fast.sheridanc.on.ca;Database=yoosungm_phfooddb;UID=yoosungm_group;Password=csharpgroup!1";
  
        string allClientsQuery = "SELECT * FROM client";

        public ClientDB()
        {
            //conn.ConnectionString = connString;
        }

        public List<Client> GetClients()
        {
            OpenConnection();

            List<Client> clients = new List<Client>();

            using (conn)
            {
                using (MySqlCommand command = new MySqlCommand(allClientsQuery, conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client currClient = new Client
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            phoneNumber = reader.GetString(2),
                            address = reader.GetString(3),
                            additionalDiscount = (decimal)reader.GetDecimal(4),
                            type = (ClientType)Enum.Parse(typeof(ClientType), reader.GetString(5)),
                            zone = (Zone)Enum.Parse(typeof(Zone), reader.GetString(6))
                        };

                        clients.Add(currClient);
                    }
                }
            }
            return clients;
        }

        public bool InsertUpdateClients(string sql)
        {
            OpenConnection();

            using (conn)
            {
                using (MySqlCommand command = new MySqlCommand(sql, conn))
                {
                    try
                    {
                        int rowCount = command.ExecuteNonQuery();

                        if (rowCount == 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
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
