﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class OrderList
    {
        public List<Order> Orders { get; set; }
        private List<OrderItem> _orderItems = new List<OrderItem>();
        private List<Client> _clients;
        private List<Product> _products;
        private Dictionary<Order, int[]> _orderWithFks;
        private Order[] _recentOrders;
        private Dictionary<int, Client> _clientIdToClient = new Dictionary<int, Client>();

        public OrderList(List<Product> products, List<Client> clients)
        {
            Orders = new List<Order>();

            _clients = clients;
            _products = products;

            InitClientIdtoClient(clients);
        }

        private void InitClientIdtoClient(List<Client> clients)
        {
            foreach (Client c in clients)
            {
                _clientIdToClient.Add(c.id, c);
            }
        }

        //public void InitOrders(PHFoodDB db)
        //{
        //    int lastOrderId;
        //    _orderWithFks = db.GetOrderToClientAndDelivery(out lastOrderId);
        //    _recentOrders = _orderWithFks.Keys.ToArray();

        //    Dictionary<int, List<OrderItem>> orderIdtoOrderItems
        //        = db.GetOrderItemsWithFks(lastOrderId, _products);

        //    foreach (Order o  in _recentOrders)
        //    {
        //        int clientId = _orderWithFks[o][1];

        //        //o.Client = GetClient(clientId);
        //        o.Client = _clientIdToClient[clientId];

        //        o.OrderItems = orderIdtoOrderItems[o.OrderNumber];

        //        Orders.Add(o);
        //    }
        //}
        
        private Client GetClient(int clientId)
        {
            foreach (Client c in _clients)
            {
                if (c.id == clientId)
                {
                    return c;
                }
            }

            return null;
        }

        internal void AddOrder(Order quickOrder)
        {
            Orders.Add(quickOrder);
        }
    }
}
