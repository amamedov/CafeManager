using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Core
{
    class Repository : IRepository
    {
        private readonly Context DataBase;
        public Repository(Context dbContext)
        {
            DataBase = dbContext;
        }
        public void AddEmployee(Employee employee)
        {
            DataBase.Employees.Add(employee);
            DataBase.SaveChanges();
        }

        public void AddOrder(Order order)
        {
            DataBase.Orders.Add(order);
            DataBase.SaveChanges();
        }

        public void AddUser(User user)
        {
            DataBase.Users.Add(user);
            DataBase.SaveChanges();
        }

        public List<Employee> GetAllEmployees() => DataBase.Employees.ToList();

        public List<Order> GetAllOrders() => DataBase.Orders.ToList();

        public List<Order> GetAllOrdersForUser(User user) => DataBase.Orders.Where(o => o.UserId == user.Id).ToList();

        public List<Order> GetAllOrdersPerPeriod(DateTime startDate, DateTime endDate) => DataBase.Orders.Where(o => o.DeliveryTime >= startDate && o.DeliveryTime <= endDate).ToList();

        public List<User> GetAllUsers() => DataBase.Users.ToList();

        public void SaveEmployeeInfo(Employee employee)
        {
            var dataBaseEmployee = DataBase.Employees.First(e => e.Id == employee.Id);
            dataBaseEmployee = employee;
            DataBase.SaveChanges();
        }

        public void SaveUserInfo(User user)
        {
            var dataBaseUser = DataBase.Users.First(u => u.Id == user.Id);
            dataBaseUser = user;
            DataBase.SaveChanges();
        }

        public void SaveOrderInfo(Order order)
        {
            var dataBaseOrder = DataBase.Orders.First(o => o.Id == order.Id);
            dataBaseOrder = order;
            DataBase.SaveChanges();
        }

        public Ingredient GetIngredient(int Id) => DataBase.Ingredients.First(i => i.Id == Id);

        public void SaveIngredientInfo(Ingredient ingredient)
        {
            var dataBaseIngredient = DataBase.Ingredients.First(i => i.Id == ingredient.Id);
            dataBaseIngredient = ingredient;
            DataBase.SaveChanges();
        }

        public List<MenuPosition> GetAllMenuPositions() => DataBase.MenuPositions.ToList();

        public List<Transaction> GetAllTransactions() => DataBase.Transactions.ToList();

        public List<Transaction> GetTransactionsPerPeriod(DateTime startDate, DateTime endDate) => DataBase.Transactions.Where(o => o.Time >= startDate && o.Time <= endDate).ToList();

        public void AddFeedBack(FeedBack feedBack)
        {
            DataBase.FeedBacks.Add(feedBack);
            DataBase.SaveChanges();
        }

        public List<FeedBack> GetAllFeedBacks() => DataBase.FeedBacks.ToList();

        public void UpdateFeedBacks(List<FeedBack> feedBacks)
        {
            DataBase.UpdateRange(feedBacks);
        }

        public void AddTransaction(Transaction transaction)
        {
            DataBase.Transactions.Add(transaction);
        }

        public List<Ingredient> GetAllIngredients() => DataBase.Ingredients.ToList();
    }
}
