using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IRepository
    {
        User GetUserInfo(string phone, string password);
        Employee GetEmployeeInfo(string phone, string password);
        List<Order> GetAllOrders();
        List<Order> GetAllOrdersPerPeriod(DateTime startDate, DateTime endDate);
        void SaveUserInfo(User user);
        void SaveEmployeeInfo(Employee employee);
        void DeleteInfoAboutUser(User user);
        void DeleteInfoAboutEmployee(Employee employee);
    }
}
