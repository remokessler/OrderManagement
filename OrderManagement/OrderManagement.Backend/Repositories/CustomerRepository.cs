using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class CustomerRepository : BaseRepository, IRepository<Customer>
    {
        public CustomerRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public Customer Add(Customer obj)
        {
            var toAdd = new Customer()
            {
                AddressId = obj.AddressId,
                Firstname = obj.Firstname,
                Name = obj.Name
            };
            DbContext.Customers.Add(toAdd);
            DbContext.SaveChanges();
            return toAdd;
        }

        public void Delete(int id)
        {
            var customer = DbContext.Customers.First(c => c.Id == id);
            DbContext.Remove(customer);
            DbContext.SaveChanges();
        }

        public IEnumerable<Customer> Get()
        {
            return DbContext.Customers.Where(c => true);
        }

        public IEnumerable<Customer> Get(Func<Customer, bool> where)
        {
            return DbContext.Customers.Where(where);
        }

        public Customer Get(int id)
        {
            return DbContext.Customers.First(c => c.Id == id);
        }

        public Customer Update(Customer newObject)
        {
            var oldCustomer = DbContext.Customers.First(c => c.Id == newObject.Id);
            oldCustomer.Firstname = newObject.Firstname;
            oldCustomer.Name = newObject.Name;
            oldCustomer.AddressId = newObject.AddressId;
            oldCustomer.Address = DbContext.Addresses.First(a => a.Id == newObject.AddressId);
            DbContext.Update(oldCustomer);
            DbContext.SaveChanges();
            return oldCustomer;
        }
    }
}
