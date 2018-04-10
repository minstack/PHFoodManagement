using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class ProductList
    {
        public List<Product> Products { get; set; }
        private List<Product> _originalProducts;

        public ProductList()
        {
            Products = new List<Product>();
        }

        public void InitProductsFromDB(PHFoodDB db)
        {
            Products = db.GetProducts();
            _originalProducts = Products.ToList();
        }

        public void SaveNewProducts(PHFoodDB db)
        {
            db.AddNewProducts(Products);
        }
    }
}
