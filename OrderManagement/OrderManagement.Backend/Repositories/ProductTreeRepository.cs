using Microsoft.EntityFrameworkCore;
using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Backend.Repositories
{
    public class ProductTreeRepository : BaseRepository, IRepository<ProductGroup>
    {
        public ProductTreeRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public ProductGroup Add(ProductGroup obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroup> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductGroup> Get(Func<ProductGroup, bool> where)
        {
            throw new NotImplementedException();
        }

        public ProductGroup Get(int id)
        {
            // Here's CTE magic. I know id.ToString() ain't optimal. But ey only got so much time.
            var cteString = @";with TreeProductGroups as (
                    select * from ProductGroups
                        where ProductGroups.Id = " + id + @"
                    union all
                    select pg.* from ProductGroups pg
                        inner join 
                    TreeProductGroups tpg on pg.ParentId = tpg.Id
                )
                select * from TreeProductGroups;";

            var productGroups = DbContext.ProductGroups.FromSqlRaw(cteString).ToList();

            return productGroups.First(p => p.Id == id);
        }

        public ProductGroup Update(ProductGroup newObject)
        {
            throw new NotImplementedException();
        }
    }
}
