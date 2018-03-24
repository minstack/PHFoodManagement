using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class Product
    {
        private string _productName;
        private decimal _price;
        private string _description;
        private bool _organic;

        public string ProductName { get; set; }
        public decimal Price {
            get { return _price; }
            set { _price = value; }
        }
        public string Description { get; set; }
        public bool Organic { get; set; }

        public Product()
        {
            ProductName = "Untitled";
            Price = 0.0M;
            Description = "None";
            Organic = false;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1} {2}", ProductName, Price, Description);
        }
    }
}
