﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EinsteinHacking.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByID(int i);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T enitiy);
    }
}
