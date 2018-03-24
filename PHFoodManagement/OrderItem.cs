using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    class OrderItem
    {
        private Product _product;
        private double _quantity;

        public Product Product { get; set; }
        public double Quantity { get; set; }

        public static decimal GetTotalCost(Product p, double q)
        {
            decimal cost = (p.Price * (decimal)q);
            return cost;
        }
    }
}
