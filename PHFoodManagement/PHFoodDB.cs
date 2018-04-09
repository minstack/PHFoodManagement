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
        string allOrderItemsWithFks = "SELECT * FROM OrderItem";
        string allRecent20OrdersWithFks = "Select * FROM Recent20Orders";

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

        public Dictionary<Order, int[]> GetOrderToClientAndDelivery(out int lastOrderNum)
        {
            OpenConnection();

            Dictionary<Order, int[]> orderFksDictionary = new Dictionary<Order, int[]>();
            int tempLastOrderId = -1;
            using (conn)
            {
                SqlCommand command = new SqlCommand(
                    "SELECT Max(orderId) as LastId FROM Recent20Orders",conn);
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
                using (command = new SqlCommand(allRecent20OrdersWithFks, conn))
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
            string query = allOrderItemsWithFks 
                + " WHERE orderId <= " + maxOrderId;

            using (conn)
            {
                using (SqlCommand command = new SqlCommand(query, conn))
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
            if (conn != null && conn.State == ConnectionState.Closed)
            {
                conn.ConnectionString = connString;
                conn.Open();
            }
        }
    }
}
