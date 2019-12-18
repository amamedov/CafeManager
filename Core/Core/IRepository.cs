using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IRepository
    {
        void AddOrder(Order order);
        void AddUser(User user);
        void AddEmployee(Employee employee);
        List<Order> GetAllOrders();
        List<User> GetAllUsers();
        List<Employee> GetAllEmployees();
        List<Order> GetAllOrdersForUser(User user);
        List<Order> GetAllOrdersPerPeriod(DateTime startDate, DateTime endDate);
        void SaveUserInfo(User user);
        void SaveEmployeeInfo(Employee employee);
        void SaveOrderInfo(Order order);
        Ingredient GetIngredient(int Id);
        void SaveIngredientInfo(Ingredient ingredient);
        void AddTransaction(Transaction transaction);
        List<MenuPosition> GetAllMenuPositions();
        List<Transaction> GetAllTransactions();
        List<Transaction> GetTransactionsPerPeriod(DateTime startDate, DateTime endDate);
        void AddFeedBack(FeedBack feedBack);
        List<FeedBack> GetAllFeedBacks();
        void UpdateFeedBacks(List<FeedBack> feedBacks);
        List<Ingredient> GetAllIngredients();
    }
}
