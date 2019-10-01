using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseWork.Data;
using CourseWork.Models;
using Microsoft.AspNetCore.Authorization;

namespace CourseWork.Pages.Shops
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly CourseWork.Data.ApplicationDbContext _context;

        public DeleteModel(CourseWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shop = await _context.Shop.FindAsync(id);

            if (Shop != null)
            {
                _context.Shop.Remove(Shop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
