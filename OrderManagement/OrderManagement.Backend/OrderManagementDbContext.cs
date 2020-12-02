using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;

namespace OrderManagement.Backend
{
    public class OrderManagementDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Address> Adresses => Set<Address>();


        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }
    }
}
