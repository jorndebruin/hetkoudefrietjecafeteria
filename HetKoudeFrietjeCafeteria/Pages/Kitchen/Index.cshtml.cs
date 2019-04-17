using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Pages.Kitchen
{
    public class IndexModel : PageModel
    {
        private readonly HetKoudeFrietjeCafeteria.Data.ApplicationDbContext _context;

        public IndexModel(HetKoudeFrietjeCafeteria.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Address)
                .Where(o => o.Placed.HasValue).OrderBy(o => o.Placed).ToListAsync();
        }
    }
}
