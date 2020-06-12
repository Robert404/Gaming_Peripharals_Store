using Peripharals_Store.Models.Product;
using Peripharals_Store.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.ShoppingBasket
{
    public class CartLine
    {
        public int Id { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        public ApplicationUser Customer { get; set; }
    }
}
