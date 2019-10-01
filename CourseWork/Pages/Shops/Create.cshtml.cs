using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseWork.Data;
using CourseWork.Models;
using Microsoft.AspNetCore.Authorization;

namespace CourseWork.Pages.Shops
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CourseWork.Data.ApplicationDbContext _context;

        public CreateModel(CourseWork.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shop Shop { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shop.Add(Shop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}