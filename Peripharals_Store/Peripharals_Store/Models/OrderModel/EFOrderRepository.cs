using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Models.OrderModel
{
    public class EFOrderRepository:IOrderRepository
    {
        private ApplicationDbContext _context;

        public EFOrderRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders.Include(o => o.Lines).ThenInclude(p => p.Product);
                            

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
