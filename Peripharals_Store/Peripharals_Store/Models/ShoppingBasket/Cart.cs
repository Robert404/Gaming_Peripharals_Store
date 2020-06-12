using Microsoft.AspNetCore.Identity;
using Peripharals_Store.Models.Product;
using Peripharals_Store.Models.User;
using System.Collections.Generic;
using System.Linq;

namespace Peripharals_Store.Models.ShoppingBasket
{
    public class Cart
    {
        public int Id { get; set; }
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(ProductModel product, int quantity, ApplicationUser customer) 
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                    Customer = customer
                });
            }
            else 
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(ProductModel product) =>
            lineCollection.RemoveAll(l => l.Product.Id == product.Id);

        public virtual decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
        
    }
}
