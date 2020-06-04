using Microsoft.AspNetCore.Mvc;
using Peripharals_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peripharals_Store.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public NavigationMenuViewComponent(ApplicationDbContext context) 
        {
            _context = context;
        }
        public IViewComponentResult Invoke() 
        {
            return View(_context.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
