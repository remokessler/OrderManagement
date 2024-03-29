﻿using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class ProductGroupRepository : BaseRepository, IRepository<ProductGroup>
    {
        public ProductGroupRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public ProductGroup Add(ProductGroup obj)
        {
            var toAdd = new ProductGroup()
            {
                Id = Guid.NewGuid().ToString(),
                Name = obj.Name,
                ParentId = obj.ParentId
            };
            DbContext.ProductGroups.Add(toAdd);
            DbContext.SaveChanges();
            return toAdd;
        }

        public void Delete(string id)
        {
            var productGroup = DbContext.ProductGroups.First(p => p.Id == id);
            DbContext.Remove(productGroup);
            DbContext.SaveChanges();
        }

        public IEnumerable<ProductGroup> Get()
        {
            return DbContext.ProductGroups.Where(p => true);
        }

        public IEnumerable<ProductGroup> Get(Func<ProductGroup, bool> where)
        {
            return DbContext.ProductGroups.Where(where);
        }

        public ProductGroup Get(string id)
        {
            return DbContext.ProductGroups.First(p => p.Id == id);
        }

        public ProductGroup Update(ProductGroup newObject)
        {
            if (newObject == null || newObject.Id == null)
            {
                return newObject;
            }

            var oldProductGroup = DbContext.ProductGroups.First(p => p.Id == newObject.Id);
            oldProductGroup.Name = newObject.Name;
            oldProductGroup.ParentId = newObject.ParentId;
            oldProductGroup.Parent = DbContext.ProductGroups.First(p => p.Id == newObject.ParentId);
            DbContext.Update(oldProductGroup);
            DbContext.SaveChanges();
            return oldProductGroup;
        }
    }
}
