using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Request.ResourceViewModels
{
    public class Order
    {
        public string CustomerName { get; set; }
        public string ServerName { get; set; }
        public List<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
