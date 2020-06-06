using Peripharals_Store.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Data
{
    public interface IProduct
    {
        Task AddProduct(ProductModel product);
        Task DeleteProduct(int productId);
        Task EditProduct(ProductModel product);
        IEnumerable<ProductModel> GetAll();
    }
}
