using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class Delivery
    {
        public int id { get; set; }

        public List<Order> orders{ get; set; }

        public string empName { get; set; }

        //public Zone zone { get; set; }

        public override string ToString()
        {
            return null;
        }
    }
}
