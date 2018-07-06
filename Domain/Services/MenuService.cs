using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    public class MenuService : IMenuService
    {
        public Task<Menu> GetMenu()
        {
            var menu = new Menu
            {
                Items = new List<MenuItem>
                {
                    new MenuItem
                    {
                        Name = "Denver Omelette",
                        Description = "Ham, onion, green pepper, American cheese omlette",
                        Price = 6.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    }
                     ,
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    }
                     ,
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    }
                     ,
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    },
                     new MenuItem
                    {
                        Name = "Pancakes",
                        Description = "4 chocolate chip pancakes",
                        Price = 7.00
                    }
                }
            };

            return Task.FromResult(menu);
        }
    }
}
