using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HetKoudeFrietjeCafeteria.Model;

namespace HetKoudeFrietjeCafeteria.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HetKoudeFrietjeCafeteria.Model.Food> Food { get; set; }
        public DbSet<HetKoudeFrietjeCafeteria.Model.CustomerAddress> CustomerAddress { get; set; }
        public DbSet<HetKoudeFrietjeCafeteria.Model.OrderItem> OrderItem { get; set; }
        public DbSet<HetKoudeFrietjeCafeteria.Model.Order> Order { get; set; }
    }
}
