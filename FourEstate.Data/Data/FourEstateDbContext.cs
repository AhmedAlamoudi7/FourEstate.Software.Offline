using FourEstate.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        //    base.OnModelCreating(builder);
        //    builder.Entity<Invoice>().Property(x => x.FullValueWithOutTaxValue).HasComputedColumnSql("[]");
        //}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<RealEstatetAttachment> RealEstatetAttachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<ContentChangeLog> ContentChangeLogs { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<AuctionDb> AuctionsDb { get; set; }
        public DbSet<AuctionDbAttachment> AuctionDbAttachments { get; set; }
        public DbSet<RentContract> RentContracts { get; set; }
        public DbSet<SaleContract> SaleContracts { get; set; }
        public DbSet<BuyContract> BuyContracts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<CatchReceipt> CatchReceipts { get; set; }






    }
}
