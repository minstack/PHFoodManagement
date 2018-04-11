using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class OrderItem
    {
        private Product _product;
        public Product Product = new Product();
        public double Quantity { get; set; }

        public OrderItem()
        {
            Quantity = 22;
        }
        public decimal GetTotalCost()
        {
            return (Convert.ToDecimal(Quantity) * Product.Price);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Product.ProductName, Quantity);
        }
    }
}
