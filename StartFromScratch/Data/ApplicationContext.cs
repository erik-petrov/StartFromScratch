using StartFromScratch.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bruh.Database
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Agent> Agents => Set<Agent>();
        public DbSet<RealEstate> RealEstates => Set<RealEstate>();
        public DbSet<Buy> Buys => Set<Buy>();
        public DbSet<Rent> Rents => Set<Rent>();
        public DbSet<Consultation> Consultations => Set<Consultation>();
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=bruh.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().ToTable("Agent");
            modelBuilder.Entity<RealEstate>().ToTable("RealEstate");
            modelBuilder.Entity<Buy>().ToTable("Buy");
            modelBuilder.Entity<Rent>().ToTable("Rent");
            modelBuilder.Entity<Agent>()
            .HasIndex(u => u.Email)
            .IsUnique();
        }
    }
}
