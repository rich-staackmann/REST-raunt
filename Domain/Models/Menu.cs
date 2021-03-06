﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }
    }

    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
