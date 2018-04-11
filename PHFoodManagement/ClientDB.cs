using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    class ClientDB
    {
        SqlConnection conn = new SqlConnection();
        string connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        string allClientsQuery = "SELECT * FROM ClientWithNoFks";
        //string allClientsQuery = "SELECT * FROM Client";

        public ClientDB()
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
                        Client currClient = new Client
                        {
                            id = reader.GetInt32(0),
                            name = reader.GetString(1),
                            phoneNumber = reader.GetString(2),
                            address = reader.GetString(3),
                            additionalDiscount = (decimal)reader.GetSqlMoney(4),
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
            using (conn)
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    try
                    {
                        OpenConnection();

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
