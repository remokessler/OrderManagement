using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public Order Add(Order obj)
        {
            var toAdd = new Order()
            {
                CustomerId = obj.CustomerId,
                Date = obj.Date
            };
            DbContext.Orders.Add(toAdd);
            DbContext.SaveChanges();
            return toAdd;
        }

        public void Delete(int id)
        {
            var order = DbContext.Orders.First(o => o.Id == id);
            DbContext.Remove(order);
            DbContext.SaveChanges();
        }

        public IEnumerable<Order> Get()
        {
            return DbContext.Orders.Where(a => true);
        }

        public IEnumerable<Order> Get(Func<Order, bool> where)
        {
            return DbContext.Orders.Where(where);
        }

        public Order Get(int id)
        {
            return DbContext.Orders.First(o => o.Id == id);
        }

        public Order Update(Order newObject)
        {
            var oldOrder = DbContext.Orders.First(o => o.Id == newObject.Id);
            oldOrder.CustomerId = newObject.CustomerId;
            oldOrder.Customer = DbContext.Customers.First(c => c.Id == newObject.CustomerId.ToString());
            oldOrder.Date = newObject.Date;
            DbContext.Update(oldOrder);
            DbContext.SaveChanges();
            return oldOrder;
        }
    }
}
