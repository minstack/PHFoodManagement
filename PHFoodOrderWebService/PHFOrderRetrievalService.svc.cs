using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MySql.Data.MySqlClient;

namespace PHFoodOrderWebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PHFOrderRetrievalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PHFOrderRetrievalService.svc or PHFOrderRetrievalService.svc.cs at the Solution Explorer and start debugging.
    public class PHFOrderRetrievalService : IPHFOrderRetrievalService
    {
        private string _connString = Properties.Settings.Default.ConnectionString;
        private MySqlConnection _conn = new MySqlConnection();
        private string _insertOrder = "INSERT INTO `order` " +
            "(orderDate, deliveryDate, orderTotal, paid, clientId) " +
            "VALUES (\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\")";

        private string _insertOrderItem = "INSERT INTO `orderitem` " +
            "(orderId, productId, quantity) " +
            "VALUES (\"{0}\",\"{1}\",\"{2}\")";

        public PHFOrderRetrievalService ()
        {
            _conn.ConnectionString = _connString;
        }

        public int AddNewOrder(string oDate, string dDate, decimal oTotal, bool paid, int cId)
        {
            string query = string.Format(_insertOrder,
                oDate,dDate,oTotal,paid,cId);

            if (RunNonExecuteQuery(query) > 0) {
                return GetOrderID();
            }

            return -1;
        }

        private int GetOrderID()
        {
            OpenConnection();
            string query = "SELECT orderId FROM `order` ORDER BY orderId DESC LIMIT 1";
            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                }
            }

            return -1;
        }

        public int AddOrderItem(int orderId, int productId, double quantity)
        {
            string query = string.Format(_insertOrderItem, orderId, productId, quantity);

            return RunNonExecuteQuery(query);

        }

        private int RunNonExecuteQuery(string query)
        {
            OpenConnection();
            int rows = 0;
            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
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
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                    }
                }
            }

            return "";
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
