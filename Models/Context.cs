using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(s => new {s.FirearmID, s.CustomerID});
        }

        public DbSet<Firearm> Firearm {get; set;} = default!;
        public DbSet<Customer> Customer {get; set;} = default!; 
        public DbSet<Order> Order {get; set;} = default!;
    }
}