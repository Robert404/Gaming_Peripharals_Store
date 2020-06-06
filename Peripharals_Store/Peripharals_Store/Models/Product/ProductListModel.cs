using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.Product
{
    public class ProductListModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
