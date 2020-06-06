using Microsoft.AspNetCore.Mvc;
using Peripharals_Store.Data;
using Peripharals_Store.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Controllers
{
    public class ProductController:Controller
    {
        private readonly IProduct _productService;

        public ProductController(IProduct productService) 
        {
            _productService = productService;
        }

        public IActionResult Create() 
        {
            var model = new ProductCreateModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductCreateModel model) 
        {
            var product = new ProductModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Category = model.Category,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            await _productService.AddProduct(product);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Edit(int id) 
        {
            var product = _productService.GetAll().FirstOrDefault(p => p.Id == id);
            var model = new ProductEditModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                ImageUrl = product.ImageUrl,
                Price = product.Price
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductEditModel model) 
        {
            var product = _productService.GetAll().FirstOrDefault(p => p.Id == model.Id);
            product.Name = model.Name;
            product.Description = model.Description;
            product.Category = model.Category;
            product.Id = model.Id;
            product.ImageUrl = model.ImageUrl;
            product.Price = model.Price;

            await _productService.EditProduct(product);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> DeleteProduct(int id) 
        {
            await _productService.DeleteProduct(id);
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Index() 
        {
            var products = _productService.GetAll().Select(p => new ProductModel
            {
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                Category = p.Category,
                ImageUrl = p.ImageUrl,
                Id = p.Id
            });

            var model = new ProductListModel
            {
                Products = products
            };

            return View(model);
        }
    }
}
