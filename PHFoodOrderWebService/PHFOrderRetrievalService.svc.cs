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
    //Order Web Service, to manipulate order and orderitem tables from DB
    //All return values are 'primitive' types
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

        //add a given order record
        public int AddNewOrder(string oDate, string dDate, decimal oTotal, bool paid, int cId)
        {
            string query = string.Format(_insertOrder,
                oDate,dDate,oTotal,paid,cId);

            if (RunNonExecuteQuery(query) > 0) {
                return GetOrderID();
            }

            return -1;
        }

        //probably not the best way of updating the order number on the client side
        //called right after an insert and returns the 'last' order id
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

        //adds the given orderitem record
        public int AddOrderItem(int orderId, int productId, double quantity)
        {
            string query = string.Format(_insertOrderItem, orderId, productId, quantity);

            return RunNonExecuteQuery(query);
        }

        //the general method to be called for any non-execute method.
        //the given query must be valid
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
        
        //updates the given order to the values within the order itself
        //uses the order id within the string
        //token used is the pipe '|'
        public int UpdateOrder(string o)
        {
            string[] temp = o.Split('|');

            //mysql syntax, since all strings -> literal quotes
            string setStatement = "orderDate=\"" + temp[1] + "\","
                                   + " deliveryDate=\"" + temp[2] + "\","
                                   + " orderTotal=\"" + temp[3] + "\","
                                   + " paid=\"" + temp[4] + "\","
                                   + " clientId=\"" + temp[5] + "\"";

            string query = string.Format(_updateQuery, "`order`", setStatement, "orderId=" + temp[0]);

            return RunNonExecuteQuery(query);
        }

        //Deletes the given order id number
        //the caller must take care of referential integrity 
        public int DeleteOrder(int id)
        {
            string query = string.Format(_deleteQuery, "`order`", "orderId=\"" + id + "\"");

            return RunNonExecuteQuery(query);
        }

        //retreives the order with the given id
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

        //retrieves all orders in the order table
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

            //prevents substring fail
            return resultString.Length == 0 ? "" 
                : resultString.Substring(0, resultString.Length - 1);
        }

        //opens the connection with the connection string
        private void OpenConnection()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.ConnectionString = _connString;
                _conn.Open();
            }
        }

        //retrieves all the order items based on the given
        //orderId.  If the orderId is -1, returns all order items
        public string GetAllOrderItems(int orderId)
        {
            string query = orderId == -1 ?
                string.Format(_selectAll, "orderitem", "")
                : string.Format(_selectAll, "orderitem", "WHERE orderId=" + orderId);

            OpenConnection();
            string resultString = "";

            using (_conn)
            {
                using (MySqlCommand command = new MySqlCommand(query, _conn))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //tokens allow for splitting of the orderId and productId,qty
                        //for dictionary to match with orders from calling method
                        resultString += reader.GetInt32(0) + ","
                                        + reader.GetInt32(1) + ","
                                        + reader.GetDecimal(2) + "|";
                    }
                }
            }

            //prevents substring error when no rows found
            return resultString.Length == 0 ? "" 
                : resultString.Substring(0, resultString.Length-1);
        }
        
        //deletes all order items that match the given order id
        public int DeleteOrderItems(int id)
        {
            string query = string.Format(_deleteQuery, "orderitem", "orderId=" + id);

            return RunNonExecuteQuery(query);
        }
    }
}
