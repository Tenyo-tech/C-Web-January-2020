using Microsoft.EntityFrameworkCore;
using Panda.Data.Models;

namespace Panda.Data
{
    public class PandaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<Receipt> Receipts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Packages)
                .WithOne(p=>p.Recipient)
                .HasForeignKey(u=>u.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasMany(x => x.Receipts)
                .WithOne(x => x.Recipient).HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
