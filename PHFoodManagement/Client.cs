﻿using System;
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
        public decimal additionalDiscount { get; set; }


        public Order placeOrder()
        {
            return null;
        }

        public void SetAdditionalDiscount(decimal price)
        {

        }

        public override string ToString()
        {
            return null;
        }
    }

    
}