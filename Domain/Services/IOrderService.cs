using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrder(int id);
        Task<Order> UpdateOrder(Order order);
        Task<int> CompleteOrder(int id);
        Task<Order> CreateOrder(Order order);
    }
}
