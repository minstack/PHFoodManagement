﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class OrderList
    {
        public List<Order> Orders { get; set; }

        public OrderList()
        {
            Orders = new List<Order>();
        }
    }
}
