using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IService
    {
        void Add<T>(T obj) where T : class;
        T Get<T>(int Id) where T : class;
        List<T> GetAll<T>() where T : class;
        void Update<T>(T obj) where T : class;
        void UpdateRange<T>(List<T> obj) where T : class;
    }
}
