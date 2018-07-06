using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    public class OrderService : IOrderService
    {
        private static List<Order> _orders;
        private static int OrderCounter;
        public OrderService()
        {
            if (_orders == null)
            {
                _orders = new List<Order>();
            }
        }

        public Task<Order> CreateOrder(Order order)
        {
            order.Id = ++OrderCounter;
            order.OrderState = OrderState.OrderStarted;
            _orders.Add(order);
           return  Task.FromResult(order);
        }

        public Task<Order> GetOrder(int id)
        {
            var order = _orders.Find((x => x.Id == id));
            return Task.FromResult(order);
        }

        public Task<Order> UpdateOrder(Order order)
        {          
            var index = _orders.FindIndex((x => x.Id == order.Id));
            
            if (index == -1)
            {
                return Task.FromResult(new Order
                {
                    Id = -1
                });
            }

            //if the order is paid we shouldn't be able to update it 
            var persistedOrder = _orders.Find((x => x.Id == order.Id));
            if (persistedOrder.OrderState == OrderState.OrderPaid)
            {
                return Task.FromResult(persistedOrder);
            }

            _orders.Insert(index, order);

            //simulate some other part of the api marking the order as paid
            var modifiedOrder = new Order
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                ServerName = order.ServerName,
                Items = order.Items.Select(x =>  new OrderItem {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                    }).ToList(),
                OrderState = OrderState.OrderPaid
            };
            _orders.Insert(index, modifiedOrder);
            //-------------------------------------------------------------------

            return Task.FromResult(order);
        }

        public Task<int> CompleteOrder(int id)
        {
            var index = _orders.FindIndex((x => x.Id == id));
            if (index != -1)
            {
                _orders.RemoveAt(index);
            }           

            return Task.FromResult(index);
        }
    }
}
