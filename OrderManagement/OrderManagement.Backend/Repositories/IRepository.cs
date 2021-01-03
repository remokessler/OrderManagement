using OrderManagement.Backend.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Backend.Repositories
{
    public interface IRepository<T>
    {

        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> where);
        T Get(int id);
        T Update(T newObject);
        void Delete(int id);
    }
}
