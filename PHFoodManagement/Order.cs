using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class Order
    {
        private int _orderNumber;
        //private Client _client;
        private bool _paid;
        //private List<OrderItem> _orderItems;
        private DateTime _deliveryDate;
        private DateTime _orderDate;

        public List<OrderItem> OrderItems { get; set; }
        //TODO need OrderItem and Client classes to have the constructor created
        //public Order (Client client, OrderItem item)
        //{
        //      
        //}

        public decimal CalculateTotal()
        {
            //iterate through all orderitems and calculate the total of this order
            //sum of product quantity * (product cost - client.extraDiscount)
            throw new NotImplementedException("Not yet implemented");
        }

        public void AddProduct(Product product, double quantity)
        {
            //add the product with quantity to orderitem list
            //_orderItems.Add(new OrderItem(product, quantity));
        }
    }
}
