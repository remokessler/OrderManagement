using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend
{
    public class OrderManagementDbContextFactory : IDesignTimeDbContextFactory<OrderManagementDbContext>
    {
        public OrderManagementDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=(local);Database=OrderManagement;MultipleActiveResultSets=True;Trusted_Connection=True";

            var options = new DbContextOptionsBuilder<OrderManagementDbContext>().UseSqlServer(connectionString);

            return new OrderManagementDbContext(options.Options);
        }
    }
}
