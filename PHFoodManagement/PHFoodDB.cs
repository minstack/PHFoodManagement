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
        private SqlConnection _conn = new SqlConnection();
        private string _connString = PHFoodManagement.Properties.Settings.Default.ConnectionString;
        private string _allClientsQuery = "SELECT * FROM ClientWithNoFks";
        private string _allProductsQuery = "SELECT * FROM Product";
        private string _allOrderItemsWithFks = "SELECT * FROM OrderItem";
        private string _allRecent20OrdersWithFks = "Select * FROM Recent20Orders";
        private string _insertNewProducts = "INSERT INTO Product (productName, organic, price, description)" +
                                    "VALUES ({0},{1},{2},{3})";
        string _insertNewClients = "INSERT INTO Client (clientName, phone, address, additionalDiscount, clientTypeId, zoneId)" +
                                    "VALUES ({0},{1},{2},{3},{4},{5})";


        public PHFoodDB ()
        {
            _conn.ConnectionString = _connString;
        }

        public int AddNewClients(List<Client> clients)
        {
            OpenConnection();

            int rowsAffected = 0;

            using (_conn)
            {
                foreach (Client c in clients)
                {
                    string insertQuery = string.Format(_insertNewClients,
                        c.name, c.phoneNumber, c.address, c.additionalDiscount
                        , (int)c.type, (int)c.zone);

                    using (SqlCommand command = new SqlCommand(insertQuery, _conn))
                    {
                        rowsAffected += command.ExecuteNonQuery();
                    }
                }
            }

            return rowsAffected;
        }

        public List<Client> GetClients()
        {
            OpenConnection();

            List<Client> clients = new List<Client>();

            using (_conn)
            {
                using (SqlCommand command = new SqlCommand(_allClientsQuery, _conn))
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

            using (_conn)
            {
                using (SqlCommand command = new SqlCommand(_allProductsQuery, _conn))
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

        public Dictionary<Order, int[]> GetOrderToClientAndDelivery(out int lastOrderNum)
        {
            OpenConnection();

            Dictionary<Order, int[]> orderFksDictionary = new Dictionary<Order, int[]>();
            int tempLastOrderId = -1;
            using (_conn)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT Max(orderId) as LastId FROM Recent20Orders", _conn);
                SqlDataReader reader;

                //retreives the max order number of the recent 20
                //needed when initializing the orderlist with order items
                //to avoid retreiving 'out-of-bounds' order items
                using (command)
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tempLastOrderId = reader.GetInt32(0);
                    }
                }

                //retrieving all orders and the fks deliveryid and clientid
                using (command = new SqlCommand(_allRecent20OrdersWithFks, _conn))
                using (reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order currOrder = new Order
                        {
                            OrderNumber = reader.GetInt32(0),
                            OrderDate = reader.GetDateTime(1),
                            DeliveryDate = reader.GetDateTime(2),
                            Paid = bool.Parse(reader.GetString(3))
                        };

                        orderFksDictionary.Add(currOrder,
                            new int[] { reader.GetInt32(4), reader.GetInt32(5) });

                    }
                }
            }

            lastOrderNum = tempLastOrderId;
            return orderFksDictionary;
        }

        //seems inefficient but this is the solution I came up with for now
        public Dictionary<int, List<OrderItem>> 
            GetOrderItemsWithFks(int maxOrderId, List<Product> prods)
        {
            OpenConnection();

            Dictionary<int, List<OrderItem>> 
                orderItemsFksDictionary = new Dictionary<int, List<OrderItem>>();
            string query = _allOrderItemsWithFks 
                + " WHERE orderId <= " + maxOrderId;

            using (_conn)
            {
                using (SqlCommand command = new SqlCommand(query, _conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(0);
                        int prodId = reader.GetInt32(1);
                        double quantity = reader.GetDouble(2);
                        Product prod = GetProduct(prodId, prods);

                        List<OrderItem> tempList = orderItemsFksDictionary[orderId];

                        if (tempList == null)
                        {
                            orderItemsFksDictionary[orderId] = new List<OrderItem>();
                            tempList = orderItemsFksDictionary[orderId];
                        }

                        tempList.Add(new OrderItem { Product = prod, Quantity = quantity });
                    }
                }
            }

            return orderItemsFksDictionary;
        }

        private Product GetProduct(int prodId, List<Product> products)
        {
            foreach (Product p in products)
            {
                //need id in product class
                //if (p.id == prodId)
                //{
                //    return p;
                //}
            }

            return null;
        }

        private void OpenConnection()
        {
            if (_conn != null && _conn.State == ConnectionState.Closed)
            {
                _conn.ConnectionString = _connString;
                _conn.Open();
            }
        }
    }
}
