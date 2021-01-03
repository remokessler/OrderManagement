﻿using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(OrderManagementDbContext dbContext) : base(dbContext) { }

        public void Delete(int id)
        {
            var product = DbContext.Products.First(p => p.Id == id);
            DbContext.Remove(product);
            DbContext.SaveChanges();
        }

        public IEnumerable<Product> Get()
        {
            return DbContext.Products.Where(p => true);
        }

        public IEnumerable<Product> Get(Func<Product, bool> where)
        {
            return DbContext.Products.Where(where);
        }

        public Product Get(int id)
        {
            return DbContext.Products.First(p => p.Id == id);
        }

        public Product Update(Product newObject)
        {
            var oldProduct = DbContext.Products.First(p => p.Id == newObject.Id);
            oldProduct.Name = newObject.Name;
            oldProduct.ParentId = newObject.ParentId;
            oldProduct.Parent = DbContext.ProductGroups.First(p => p.Id == newObject.ParentId);
            oldProduct.Price = newObject.Price;
            DbContext.Update(oldProduct);
            DbContext.SaveChanges();
            return oldProduct;
        }
    }
}