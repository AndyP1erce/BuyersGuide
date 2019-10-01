using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseWork.Data;
using CourseWork.Models;

namespace CourseWork.Pages.Shops
{
    public class DetailsModel : PageModel
    {
        private readonly CourseWork.Data.ApplicationDbContext _context;

        public DetailsModel(CourseWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Shop Shop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shop = await _context.Shop.FirstOrDefaultAsync(m => m.Id == id);

            if (Shop == null)
            {
                return NotFound();
            }
            Shop.Popularity++;
            _context.Attach(Shop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {

            }
            return Page();
        }
    }
}
