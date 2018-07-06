using Domain.Models;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using Web.ResourceViewModels.Mappers;
using Web.Response.ResourceViewModels;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/order/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var model = await _orderService.GetOrder(id);
                if (model != null)
                {
                    var order = OrderMapper.MapDomainToOrderResponse(model);
                    order.Links = new System.Collections.Generic.List<HyperMediaLink>
                    {
                        new HyperMediaLink
                        {
                            Rel = "self",
                            Uri = $"http://localhost:52776/api/order/{id}"
                        }
                    };

                    return Ok(order);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }          
        }

        // POST api/order/
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Web.Request.ResourceViewModels.Order order)
        {
            try
            {
                var model = OrderMapper.MapOrderRequestToDomain(order);

                var newOrder = await _orderService.CreateOrder(model);

                var response = OrderMapper.MapDomainToOrderResponse(newOrder);
                response.Links = new System.Collections.Generic.List<HyperMediaLink>
                {
                    new HyperMediaLink
                    {
                        Rel = "self",
                        Uri = $"http://localhost:52776/api/order/{newOrder.Id}"
                    },
                    new HyperMediaLink
                    {
                        Rel = "update",
                        Uri = $"http://localhost:52776/api/order/{newOrder.Id}"
                    },
                    new HyperMediaLink
                    {
                        Rel = "complete",
                        Uri = $"http://localhost:52776/api/order/{newOrder.Id}"
                    }
                };

                return Created($"http://localhost:52776/api/order/{newOrder.Id}", response);                
            }
            catch (Exception)
            {
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        // PUT api/order/
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]Web.Request.ResourceViewModels.Order order)
        {
            try
            {
                var model = OrderMapper.MapOrderRequestToDomain(order);
                model.Id = id;
               
                var updatedModel = await _orderService.UpdateOrder(model);

                if (updatedModel.Id == -1)
                {
                    return NotFound();
                }

                if (updatedModel.OrderState == OrderState.OrderPaid)
                {
                    //updating a paid order violates domain logic
                    //another method to handle this is to throw custom exception for domain logic violation
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }

                var response = OrderMapper.MapDomainToOrderResponse(updatedModel);
                response.Links = new System.Collections.Generic.List<HyperMediaLink>
                {
                    new HyperMediaLink
                    {
                        Rel = "self",
                        Uri = $"http://localhost:52776/api/order/{id}"
                    },
                    new HyperMediaLink
                    {
                        Rel = "complete",
                        Uri = $"http://localhost:52776/api/order/{id}"
                    }
                };

                return Ok(response);
            }
            catch (Exception)
            {
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }

        // DELETE api/order/
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Complete(int id)
        {
            try
            {

                var removed = await _orderService.CompleteOrder(id);

                if (removed == -1)
                {
                    return NotFound();
                }               

                return Ok("Order Complete");
            }
            catch (Exception)
            {
                return new ObjectResult("Internal Server Error")
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
        }
    }
}
