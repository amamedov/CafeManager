using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public abstract class Repository
    {
        abstract public void Add<T>(T obj) where T : class;
        abstract public List<T> GetAll<T>() where T : class;
        abstract public void Update<T>(T obj) where T : class;
        abstract public void UpdateRange<T>(List<T> obj) where T : class;
        abstract public T Get<T>(int Id) where T : class;
    }
}
