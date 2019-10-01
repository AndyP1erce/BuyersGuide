using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseWork.Data;
using CourseWork.Models;

namespace CourseWork.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly CourseWork.Data.ApplicationDbContext _context;

        public IndexModel(CourseWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get;set; }

        public async Task OnGetAsync()
        {
            Shop = await _context.Shop.ToListAsync();
            ViewData["print"] = Shop;
            Shop = Shop.OrderBy(g => g.Popularity).Reverse().ToList();
        }
    }
}
