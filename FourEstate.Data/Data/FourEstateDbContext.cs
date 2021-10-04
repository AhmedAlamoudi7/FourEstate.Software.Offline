using FourEstate.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FourEstate.Data
{
    public class FourEstateDbContext : IdentityDbContext<User>
    {
        public FourEstateDbContext(DbContextOptions<FourEstateDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //   // base.OnModelCreating(builder);
        //   // modelBuilder.Entity<Card>()
        //   //.HasRequired(c => c.Stage)
        //   //.WithMany()
        //   //.WillCascadeOnDelete(false);

        //   // modelBuilder.Entity<Side>()
        //   //     .HasRequired(s => s.Stage)
        //   //     .WithMany()
        //   //     .WillCascadeOnDelete(false);
        //}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }


    }
}
