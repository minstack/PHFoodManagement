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

        public ProductList()
        {
            Products = new List<Product>();
        }

        public void InitProductsFromDB(PHFoodDB db)
        {
            Products = db.GetProducts();
        }
    }
}
