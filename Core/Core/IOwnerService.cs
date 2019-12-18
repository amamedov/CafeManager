using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IOwnerService
    {
        List<Transaction> GetProfitStatistics();
        List<Transaction> GetProfitStatisticsPerPeriod(DateTime startDate, DateTime endDate);
        List<Employee> GetTopOfEmployees();
        decimal GetTotalProfit(out List<Transaction> transactions);
        decimal GetProfitPerPeriod(DateTime startDate, DateTime endDate, out List<Transaction> transactions);
        bool SignUpEmployee(string name, string Phone, string Password, string Position, out string errorMessage, out Employee employee);
        List<Transaction> GetIncomePerPeriod(DateTime startDate, DateTime endDate);
        List<Transaction> GetOutcomePerperiod(DateTime startDate, DateTime endDate);
        List<FeedBack> GetAllFeedBacks();
        List<FeedBack> GetUnreadFeedBacks();
        List<Ingredient> GetIngredientInfo();
    }
}
