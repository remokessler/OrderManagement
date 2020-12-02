using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public interface ICustomerRepository
    {

        IEnumerable<Customer> Get();
        IEnumerable<Customer> Get(Func<Customer, bool> where);
        Customer Get(int id);
        IEnumerable<Address> GetAddresses(int id);
        Customer Update(Customer customer);
        void Delete(int id);
    }
}
