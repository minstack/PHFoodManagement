using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public Zone zone { get; set; }
        public ClientType type { get; set; }
        public decimal additionalDiscount { get; set; }


        public Order placeOrder()
        {
            return null;
        }

        public override string ToString()
        {
            return name;
        }

        public bool Equals(string oldValue, string newValue)
        {
            if (oldValue.Equals(newValue))
            {
                return true;
            } else
            {
                return false;
            }
        }
    }

    
}
