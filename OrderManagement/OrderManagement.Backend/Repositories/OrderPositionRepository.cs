using OrderManagement.Backend;
using OrderManagement.Backend.DataModels;
using OrderManagement.Backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Backend.Repositories
{
    public class OrderPositionRepository : BaseRepository, IRepository<OrderPosition>
    {
        public OrderPositionRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public OrderPosition Add(OrderPosition obj)
        {
            var toAdd = new OrderPosition()
            {
                Count = obj.Count,
                OrderId = obj.OrderId,
                Position = obj.Position,
                ProductId = obj.ProductId
            };
            DbContext.OrderPositions.Add(toAdd);
            DbContext.SaveChanges();
            return toAdd;
        }
        public void Delete(int id)
        {
            var orderPosition = DbContext.OrderPositions.First(o => o.Id == id);
            DbContext.Remove(orderPosition);
            DbContext.SaveChanges();
        }

        public IEnumerable<OrderPosition> Get()
        {
            return DbContext.OrderPositions.Where(a => true);
        }

        public IEnumerable<OrderPosition> Get(Func<OrderPosition, bool> where)
        {
            return DbContext.OrderPositions.Where(where);
        }

        public OrderPosition Get(int id)
        {
            return DbContext.OrderPositions.First(o => o.Id == id);
        }

        public OrderPosition Update(OrderPosition newObject)
        {
            var oldOrderPosition = DbContext.OrderPositions.First(o => o.Id == newObject.Id);
            oldOrderPosition.OrderId = newObject.OrderId;
            oldOrderPosition.Order = DbContext.Orders.First(o => o.Id == newObject.OrderId);
            oldOrderPosition.Position = newObject.Position;
            oldOrderPosition.ProductId = newObject.ProductId;
            oldOrderPosition.Product = DbContext.Products.First(f => f.Id == newObject.ProductId);
            DbContext.Update(oldOrderPosition);
            DbContext.SaveChanges();
            return oldOrderPosition;
        }
    }
}
