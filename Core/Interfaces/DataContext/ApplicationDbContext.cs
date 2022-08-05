using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces.DataContext
{
    public partial class ApplicationDbContext : DbContext
    {
       // public virtual DbSet<Income> Income { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Income>();
        }

        //public ApplicationDbContext(string ConnectionString) : base(new DbContextOptionsBuilder().UseSqlServer(ConnectionString).Options)
        //{

        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Income>();
        //}
    }
}
