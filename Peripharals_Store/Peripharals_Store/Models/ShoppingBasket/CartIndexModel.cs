﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.ShoppingBasket
{
    public class CartIndexModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
