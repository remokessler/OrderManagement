#define DEMODATA
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
            new TestData(modelBuilder);
#endif
        }
    }
}
