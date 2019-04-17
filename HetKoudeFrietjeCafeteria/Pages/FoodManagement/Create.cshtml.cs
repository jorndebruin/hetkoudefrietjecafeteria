using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HetKoudeFrietjeCafeteria.Data;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Pages.FoodManagement
{
    public class CreateModel : PageModel
    {
        private readonly HetKoudeFrietjeCafeteria.Data.ApplicationDbContext _context;

        public CreateModel(HetKoudeFrietjeCafeteria.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}