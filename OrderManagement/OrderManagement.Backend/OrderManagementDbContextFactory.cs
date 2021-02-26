using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OrderManagement.Backend
{
    public class OrderManagementDbContextFactory : IDesignTimeDbContextFactory<OrderManagementDbContext>
    {
        public OrderManagementDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(local);Database=OrderManagement;Trusted_Connection=True";

            var options = new DbContextOptionsBuilder<OrderManagementDbContext>().UseSqlServer(connectionString);

            return new OrderManagementDbContext(options.Options);
        }
    }
}
