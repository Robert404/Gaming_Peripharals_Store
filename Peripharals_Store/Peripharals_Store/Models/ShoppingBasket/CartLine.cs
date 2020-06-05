using Peripharals_Store.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.ShoppingBasket
{
    public class CartLine
    {
        public int CartId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
