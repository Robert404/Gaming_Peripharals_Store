using Microsoft.AspNetCore.Mvc;
using Peripharals_Store.Models;
using Peripharals_Store.Models.OrderModel;
using Peripharals_Store.Models.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Peripharals_Store.Controllers
{
    public class OrderController:Controller
    {
        const string path = @"C:\Gaming_Peripharals_Store\orders.txt";
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult CheckoutForm(Order order) 
        {

            string customer = order.Name + "\t" + order.Country + "\t" + order.City + "\t" + order.Address + "\t" + order.State + "\t" + order.Zip;

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default)) 
            {
                sw.WriteLine(customer);
            }

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
