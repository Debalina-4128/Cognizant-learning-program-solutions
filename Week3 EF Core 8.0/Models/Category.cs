﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}
