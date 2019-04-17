using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HetKoudeFrietjeCafeteria.Data;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Pages.Kitchen
{
    public class InfoModel : PageModel
    {
        private readonly HetKoudeFrietjeCafeteria.Data.ApplicationDbContext _context;

        public InfoModel(HetKoudeFrietjeCafeteria.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }
        public Order Next { get; set; }
        public Order Prev { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Address)
                .Include(o => o.Items)
                .ThenInclude(item=>item.FoodItem)
                .FirstOrDefaultAsync(m => m.OrderID == id);

            if (Order == null)
            {
                return NotFound();
            }


            Next = await _context.Order
                .Where(o => o.Placed.HasValue && o.Placed.Value > Order.Placed)
                .OrderBy(o => o.Placed)
                .FirstOrDefaultAsync();

            Prev = await _context.Order
                .Where(o => o.Placed.HasValue && o.Placed.Value < Order.Placed)
                .OrderByDescending(o => o.Placed)
                .FirstOrDefaultAsync();

            return Page();
        }
    }
}
