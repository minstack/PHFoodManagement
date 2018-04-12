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

        private string _selectAll = "SELECT * FROM {0} {1}";
        private string _deleteQuery = "DELETE FROM {0} WHERE {1}";
        private string _updateQuery = "UPDATE {0} SET {1} WHERE {2}";

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
        
        public int UpdateOrder(string o)
        {
            string[] temp = o.Split('|');
            string setStatement = "orderDate=\"" + temp[1] + "\","
                                   + " deliveryDate=\"" + temp[2] + "\","
                                   + " orderTotal=\"" + temp[3] + "\","
                                   + " paid=\"" + temp[4] + "\","
                                   + " clientId=\"" + temp[5] + "\"";

            string query = string.Format(_updateQuery, "`order`", setStatement, "orderId=" + temp[0]);

            return RunNonExecuteQuery(query);

        }

        public int DeleteOrder(int id)
        {
            string query = string.Format(_deleteQuery, "`order`", "orderId=\"" + id + "\"");

            return RunNonExecuteQuery(query);
        }

        public string GetOrder(int id)
        {
            string query = string.Format(_selectAll, "`order`", "WHERE orderId=\"" + id + "\" LIMIT 1");

            OpenConnection();
            string resultString = "";

            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        resultString += reader.GetInt32(0) + ","
                                        + reader.GetDateTime(1) + ","
                                        + reader.GetDateTime(2) + ","
                                        + reader.GetBoolean(4) + ","
                                        + reader.GetInt32(5);
                    }
                }
            }

            return resultString;
        }

        public string GetAllOrders()
        {
            string query = string.Format(_selectAll, "`order`", "");

            OpenConnection();
            string resultString = "";

            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        resultString += reader.GetInt32(0) + ","
                                        + reader.GetDateTime(1) + ","
                                        + reader.GetDateTime(2) + ","
                                        + reader.GetBoolean(4) + ","
                                        + reader.GetInt32(5) + "|";
                    }
                }
            }

            return resultString.Length == 0 ? "" 
                : resultString.Substring(0, resultString.Length - 1);
        }

        private void OpenConnection()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.ConnectionString = _connString;
                _conn.Open();
            }
        }

        public string GetAllOrderItems(int orderId)
        {
            string query = string.Format(_selectAll, "orderitem", "WHERE orderId=" + orderId);

            OpenConnection();
            string resultString = "";

            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //this allows for splitting of the orderId and productId,qty
                        //for dictionary to match with orders from calling method
                        resultString += reader.GetInt32(0) + "|"
                                        + reader.GetInt32(1) + ","
                                        + reader.GetDecimal(2) + ",";
                    }
                }
            }

            return resultString.Substring(0, resultString.Length-1);
        }
        
        public int DeleteOrderItems(int id)
        {
            string query = string.Format(_deleteQuery, "orderitem", "orderId=" + id);

            return RunNonExecuteQuery(query);
        }
    }
}
