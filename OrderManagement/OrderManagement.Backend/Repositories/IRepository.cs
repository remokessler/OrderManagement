using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Backend.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> where);
        T Get(string id);
        T Update(T newObject);
        void Delete(string id);
        string GetTableName() => nameof(T);
        int Count() => Get().Count();
        int Count(Func<T, bool> where) => Get(where).Count();
    }
}
