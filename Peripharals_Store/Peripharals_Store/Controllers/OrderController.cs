using Microsoft.AspNetCore.Mvc;
using Peripharals_Store.Models;
using Peripharals_Store.Models.OrderModel;
using Peripharals_Store.Models.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Controllers
{
    public class OrderController:Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Checkout(Cart cart)
        {
            var model = new Order
            {
                Lines = cart.Lines.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(Order order) 
        { 
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Completed", "Order");
        }

        public IActionResult Completed() 
        {
            return View();
        }
    }
}
