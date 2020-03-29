using FinanceControl.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure
{
    public class FinanceControlContext : DbContext
    {
        public FinanceControlContext(DbContextOptions<FinanceControlContext> options) : base(options) { }
        public DbSet<Spent> SpentItems { get; set; }
        public DbSet<SpentCategory> SpentCategoryItems { get; set; }
    }
}