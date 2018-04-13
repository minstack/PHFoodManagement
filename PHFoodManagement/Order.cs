using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    //Author: Sung Min Yoon
    
    //Models an order at PH Food storing infomation including
    //OrderNumber, Paid, OrderDate, Client, OrderItems
    //DeliveryDate
    public class Order
    {
        private DateTime _deliveryDate;
        
        public int OrderNumber { get; set; }
        public bool Paid { get; set; }
        public DateTime OrderDate { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public DateTime DeliveryDate
        {
            get { return _deliveryDate; }

            set
            {
                //removing time discrepancies at this level
                _deliveryDate = value.Date;
            }
        }

        //Default constructor which initializes order items
        //to a new list.
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        //returns the total value of the order by retrieving
        //order item values
        public decimal CalculateTotal()
        {
            //iterate through all orderitems and calculate the total of this order
            //sum of product quantity * (product cost - client.extraDiscount)
            decimal totalCost = 0;
            foreach (OrderItem oi in OrderItems)
            {
                totalCost += oi.GetTotalCost();
            }

            return Math.Round(totalCost, 2);
        }

        //Creates and adds a new order item with the provided
        //product and quantity
        public void AddProduct(Product product, double quantity)
        {
            //add the product with quantity to orderitem list
            OrderItem newOrderItem = new OrderItem();

            newOrderItem.Product = product;
            newOrderItem.Quantity = quantity;

            OrderItems.Add(newOrderItem);
        }

        //Removes order items which include the given product
        public void RemoveProduct(Product product)
        {
            foreach (OrderItem oi in OrderItems)
            {
                if (oi.Product == product)
                {
                    OrderItems.Remove(oi);
                }
            }
        }

        //Removes the given order item from this order
        public void RemoveOrderItem(OrderItem oItem)
        {
            foreach (OrderItem oi in OrderItems)
            {
                if (oi == oItem)
                {
                    OrderItems.Remove(oi);
                    break;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("#{0} - {1}", OrderNumber, Client.name);
        }
    }
}
