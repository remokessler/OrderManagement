using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class AddressRepository : BaseRepository, IRepository<Address>
    {
        public AddressRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public Address Add(Address obj)
        {
            var toAdd = new Address()
            {
                City = obj.City,
                Country = obj.Country,
                PostCode = obj.PostCode,
                Street = obj.Street
            };
            DbContext.Addresses.Add(toAdd);
            DbContext.SaveChanges();
            return toAdd;
        }

        public void Delete(int id)
        {
            var address = DbContext.Addresses.First(c => c.Id == id);
            DbContext.Remove(address);
            DbContext.SaveChanges();
        }

        public IEnumerable<Address> Get()
        {
            return DbContext.Addresses.Where(a => true);
        }

        public IEnumerable<Address> Get(Func<Address, bool> where)
        {
            return DbContext.Addresses.Where(where);
        }

        public Address Get(int id)
        {
            return DbContext.Addresses.First(a => a.Id == id);
        }

        public Address Update(Address newObject)
        {
            var oldAddress = DbContext.Addresses.First(a => a.Id == newObject.Id);
            oldAddress.Country = newObject.Country;
            oldAddress.City = newObject.City;
            oldAddress.Street = newObject.Street;
            oldAddress.PostCode = newObject.PostCode;
            DbContext.Update(oldAddress);
            DbContext.SaveChanges();
            return oldAddress;
        }
    }
}
