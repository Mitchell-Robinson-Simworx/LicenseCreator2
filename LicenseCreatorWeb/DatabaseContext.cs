using Microsoft.EntityFrameworkCore;
using System;
using LicenseCreatorWeb.Model;
namespace LicenseCreatorWeb
{
    public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
    {
        public DbSet<LicenseData> Licenses { get; set; }
    }
}
