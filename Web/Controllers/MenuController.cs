using Domain;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Web.Response.ResourceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET api/menu
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var model = await _menuService.GetMenu();

            var menu = new Menu
            {
                Items = model.Items.Select(x => new MenuItem
                {
                    Name = x.Name,
                    Price = x.Price,
                    Description = x.Description
                }).ToList(),
                Links = new List<HyperMediaLink>
                {
                    new HyperMediaLink
                    {
                        Rel = "self",
                        Uri = "http://localhost:52776/api/menu"
                    }
                }
            };
            return Ok(menu);
        }
    }
}
