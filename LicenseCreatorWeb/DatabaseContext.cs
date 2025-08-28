using Microsoft.EntityFrameworkCore;
using System;
using LicenseCreatorWeb.Model;
namespace LicenseCreatorWeb
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<LicenseData> Licenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicenseData>()
                .HasKey(ld => ld.Id);
        }
    }
}
