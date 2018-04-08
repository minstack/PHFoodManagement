using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
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
        //TODO need OrderItem and Client classes to have the constructor created
        //public Order (Client client, OrderItem item)
        //{
        //      
        //}

        public decimal CalculateTotal()
        {
            //iterate through all orderitems and calculate the total of this order
            //sum of product quantity * (product cost - client.extraDiscount)
            decimal totalCost = 0;
            foreach (OrderItem oi in OrderItems)
            {
                totalCost += (oi.GetTotalCost() - (oi.Product.Price * (decimal)oi.Quantity));
            }

            return totalCost;
        }

        public void AddProduct(Product product, double quantity)
        {
            //add the product with quantity to orderitem list
            OrderItem newOrderItem = new OrderItem();

            newOrderItem.Product = product;
            newOrderItem.Quantity = quantity;

            OrderItems.Add(newOrderItem);
        }

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

        public void RemoveOrderItem(OrderItem oItem)
        {
            foreach (OrderItem oi in OrderItems)
            {
                if (oi == oItem)
                {
                    OrderItems.Remove(oi);
                }
            }
        }
    }
}
