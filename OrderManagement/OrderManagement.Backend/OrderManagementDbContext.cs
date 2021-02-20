using System;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend
{
    public class OrderManagementDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderPosition> OrderPositions => Set<OrderPosition>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductGroup> ProductGroups => Set<ProductGroup>();


        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Customer).WithMany(c => c.Orders);
            modelBuilder.Entity<OrderPosition>().HasOne(o => o.Order).WithMany(o => o.Positions);
            modelBuilder.Entity<OrderPosition>().HasOne(o => o.Product).WithMany(p => p.OrderPositions);
            modelBuilder.Entity<ProductGroup>().HasOne(x => x.Parent)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

#if DEMODATA
            // Save Test Data
            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = 1, Street = "Gossauerstrasse 15", PostCode = 9200, City = "Gossau", Country = "Switzerland", From = DateTime.Now });
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, Firstname = "Max", Name = "Mueller", AddressId = 1 },
                new Customer() { Id = 1, Firstname = "Moritz", Name = "Meier", AddressId = 2 },
                new Customer() { Id = 1, Firstname = "Tim", Name = "Tanner", AddressId = 3 },
                new Customer() { Id = 1, Firstname = "Obelix", Name = "Oke", AddressId = 4 },
                new Customer() { Id = 1, Firstname = "Asterix", Name = "Amstutz", AddressId = 4 },
                new Customer() { Id = 1, Firstname = "Trubadix", Name = "Traxler", AddressId = 5 },
                new Customer() { Id = 1, Firstname = "Idefix", Name = "Inauen", AddressId = 6 },
                new Customer() { Id = 1, Firstname = "Gute", Name = "Miene", AddressId = 4 },
                new Customer() { Id = 1, Firstname = "Struppi", Name = "Steiner", AddressId = 3 });
#endif
        }
    }
}
