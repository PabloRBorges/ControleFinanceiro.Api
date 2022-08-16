using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces.DataContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Income>();
            modelBuilder.Entity<Expense>();
        }
    }
}
