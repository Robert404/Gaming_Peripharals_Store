using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.Product
{
    public interface IProductRepository
    {
        IQueryable<ProductModel> Products { get; }
    }
}
