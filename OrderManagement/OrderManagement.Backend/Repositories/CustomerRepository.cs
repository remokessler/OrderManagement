using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(OrderManagementDbContext dbContext) : base(dbContext)
        {

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> where)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> GetAddresses(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
