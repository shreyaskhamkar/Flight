using Microsoft.EntityFrameworkCore;
using Domain;

namespace Data
{
    public class Entites : DbContext
    {
        public DbSet<Flight> Flights => Set<Flight>();

        public Entites(DbContextOptions options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasKey(f => f.Id);

            modelBuilder.Entity<Flight>().OwnsMany(f => f.BookingList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
