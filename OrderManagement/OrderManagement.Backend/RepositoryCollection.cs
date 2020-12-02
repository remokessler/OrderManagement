using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend
{
    public class RepositoryCollection
    {
        private static RepositoryCollection _instance { get;set; }
        public static RepositoryCollection Instance => _instance ??= new RepositoryCollection();

        public ICustomerRepository CustomerRepository { get; private set; }

        private OrderManagementDbContext dbContext { get; set; }

        public RepositoryCollection()
        {
            // AKA: StartUp
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=OrderManagement;MultipleActiveResultSets=True;Trusted_Connection=True";

            var options = new DbContextOptionsBuilder<OrderManagementDbContext>().UseSqlServer(connectionString);
            dbContext = new OrderManagementDbContext(options.Options);

            CustomerRepository = new CustomerRepository(dbContext);
        }
    }
}
