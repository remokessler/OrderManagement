﻿using System;
using System.Collections.Generic;

namespace OrderManagement.Backend.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Func<T, bool> where);
        T Get(int id);
        T Update(T newObject);
        void Delete(int id);
    }
}
