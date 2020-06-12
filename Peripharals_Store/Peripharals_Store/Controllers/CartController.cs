using Microsoft.AspNetCore.Mvc;
using Peripharals_Store.Infrastructure;
using Peripharals_Store.Models;
using Peripharals_Store.Models.Product;
using Peripharals_Store.Models.ShoppingBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Controllers
{
    public class CartController:Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl) 
        {
            var user = _context.Users.FirstOrDefault(p => p.UserName == User.Identity.Name);
            ProductModel product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product != null) 
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1, user);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl) 
        {
            ProductModel product = _context.Products.FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart() 
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart) 
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

    }
}
