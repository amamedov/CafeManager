using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class dbRepository : Repository
    {
        private readonly Context DataBase;
        public dbRepository(Context dbContext)
        {
            DataBase = dbContext;
        }

        public override void Add<T>(T obj)
        {
            DataBase.Set<T>().Add(obj);
            DataBase.SaveChanges();
        }

        public override List<T> GetAll<T>() => DataBase.Set<T>().ToList();

        public override T Get<T>(int Id) => DataBase.Set<T>().ToList().ElementAt(Id - 1);
        public List<Order> GetAll(User user) => DataBase.Orders.Where(o => o.UserId == user.Id).ToList();
        public List<Order> GetAll(DateTime startDate, DateTime endDate) => DataBase.Orders.Where(o => o.DeliveryTime >= startDate && o.DeliveryTime <= endDate).ToList();
        public List<Transaction> GetAllTransactions(DateTime startDate, DateTime endDate) => DataBase.Transactions.Where(o => o.Time >= startDate && o.Time <= endDate).ToList();
        public List<Transaction> GetAllTransactions() => DataBase.Transactions.ToList();
        public override void Update<T>(T obj)
        {
            DataBase.Set<T>().Update(obj);
            DataBase.SaveChanges();
        }
        public override void UpdateRange<T>(List<T> obj)
        {
            DataBase.Set<T>().UpdateRange(obj);
            DataBase.SaveChanges();
        }

    }
}
