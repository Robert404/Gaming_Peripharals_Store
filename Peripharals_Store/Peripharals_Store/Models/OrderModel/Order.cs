using Microsoft.AspNetCore.Mvc.ModelBinding;
using Peripharals_Store.Models.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.OrderModel
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zip code")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
