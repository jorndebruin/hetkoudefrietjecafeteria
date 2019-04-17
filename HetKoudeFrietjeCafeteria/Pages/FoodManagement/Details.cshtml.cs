using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HetKoudeFrietjeCafeteria.Data;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Pages.FoodManagement
{
    public class DetailsModel : PageModel
    {
        private readonly HetKoudeFrietjeCafeteria.Data.ApplicationDbContext _context;

        public DetailsModel(HetKoudeFrietjeCafeteria.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food.FirstOrDefaultAsync(m => m.FoodID == id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
