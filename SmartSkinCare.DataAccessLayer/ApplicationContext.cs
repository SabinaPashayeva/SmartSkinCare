using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartSkinCare.Entities;

namespace SmartSkinCare.DataAccessLayer
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cream> Creams { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<SkinHumidity> SkinHumidities { get; set; }
        public DbSet<SkinOiliness> SkinOilinesses { get; set; }
    }
}
