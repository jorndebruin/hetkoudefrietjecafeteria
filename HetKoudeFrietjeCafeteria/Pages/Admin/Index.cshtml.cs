using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HetKoudeFrietjeCafeteria.Data;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly HetKoudeFrietjeCafeteria.Data.ApplicationDbContext _context;

        public IndexModel(HetKoudeFrietjeCafeteria.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync(DateTimeOffset? date)
        {
            if (date.HasValue)
            {
                Order = await _context.Order
                    .Where(order=>order.Placed.HasValue 
                        && order.Placed.Value >= date.Value.Date 
                        && order.Placed.Value < date.Value.Date.AddDays(1)
                    )
                    .Include(order => order.Items)
                    .ThenInclude(item => item.FoodItem)
                    .OrderBy(item=>item.OrderID)
                    .ToListAsync();
            }
            else
            {
                Order = await _context.Order
                    .Where(order => order.Placed.HasValue)
                    .Include(order => order.Items)
                    .ThenInclude(item => item.FoodItem)
                    .OrderBy(item => item.OrderID)
                    .ToListAsync();
            }
        }
    }
}
