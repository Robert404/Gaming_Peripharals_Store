using Peripharals_Store.Data;
using Peripharals_Store.Models;
using Peripharals_Store.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Service
{
    public class ProductModelService : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductModelService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task AddProduct(ProductModel product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int productId)
        {
            var product = GetAll().FirstOrDefault(p => p.Id == productId);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task EditProduct(ProductModel product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return _context.Products;
        }
    }
}
