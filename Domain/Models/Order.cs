using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string ServerName { get; set; }
        public List<OrderItem> Items { get; set; }
        public OrderState OrderState { get; set; }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    public enum OrderState
    {
        OrderStarted,
        OrderPaid
    }
}
