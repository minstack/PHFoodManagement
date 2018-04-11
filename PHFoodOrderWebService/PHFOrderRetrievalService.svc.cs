using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PHFoodManagement;

namespace PHFoodOrderWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PHFOrderRetrievalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PHFOrderRetrievalService.svc or PHFOrderRetrievalService.svc.cs at the Solution Explorer and start debugging.
    public class PHFOrderRetrievalService : IPHFOrderRetrievalService
    {
        private string _connString = Properties.Settings.Default.ConnectionString;
        private SqlConnection _conn = new SqlConnection();
        private string _insertQuery = "INSERT INTO Order " +
            "(orderDate, deliveryDate, orderTotal, paid, deliveryId, clientId) VALUES {0}";

        public PHFOrderRetrievalService ()
        {
            _conn.ConnectionString = _connString;
        }

        public int AddNewOrder(string o)
        {
            string query = string.Format(_insertQuery, "(" + o.Replace('|', ',') + ")");

            RunNonExecuteQuery(query);
            
        }

        private int RunNonExecuteQuery(string query)
        {
            OpenConnection();
            int rows = 0;
            using (_conn)
            {
                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    rows = command.ExecuteNonQuery();
                }
            }

            return rows;
        }

        public string GetOrders(int id)
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(string o)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrder(int id)
        {
            return 0;
        }

        public string GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public string GetAllOrders()
        {
            throw new NotImplementedException();
        }

        private string RunSelectQuery(string query)
        {
            OpenConnection();
            int rows = 0;
            string orders = "";

            using (_conn)
            {
                using (SqlCommand command = new SqlCommand(query, _conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                    }
                }
            }

            return rows;
        }

        private void OpenConnection()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.ConnectionString = _connString;
                _conn.Open();
            }
        }
    }
}
