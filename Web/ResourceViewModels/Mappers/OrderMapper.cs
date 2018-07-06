using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Response.ResourceViewModels;

namespace Web.ResourceViewModels.Mappers
{
    public static class OrderMapper
    {
        public static Domain.Models.Order MapOrderRequestToDomain(Web.Request.ResourceViewModels.Order order)
        {
            return new Domain.Models.Order
            {
                CustomerName = order.CustomerName,
                ServerName = order.ServerName,
                Items = order.Items.Select(x => new Domain.Models.OrderItem
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()
            };
        }

        public static Web.Response.ResourceViewModels.Order MapDomainToOrderResponse(Domain.Models.Order order)
        {
            return new Web.Response.ResourceViewModels.Order
            {
                CustomerName = order.CustomerName,
                ServerName = order.ServerName,
                OrderState = order.OrderState,
                Items = order.Items.Select(x => new Web.Response.ResourceViewModels.OrderItem
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity
                }).ToList()                
            };
        }
    }
}
