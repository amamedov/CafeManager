using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace Core
{
    public class MyClassComparer : IComparer<Employee>
    {
        int IComparer<Employee>.Compare(Employee e1, Employee e2)
        {
            TimeSpan timeSum1 = new TimeSpan();
            TimeSpan timeSum2 = new TimeSpan();
            foreach (var t in e1.WorkingPeriods)
            {
                timeSum1 += t.EndDt - t.StartDt;
            }
            foreach (var t in e2.WorkingPeriods)
            {
                timeSum2 += t.EndDt - t.StartDt;
            }
            return timeSum1 == timeSum2 ? 0 : (timeSum1 <= timeSum2) ? -1 : 1;
        }
    }
    public class OwnerService : IService
    {
        dbRepository Repository { get; set; }
        public OwnerService(dbRepository repository)
        {
            Repository = repository;
        }
        public List<Transaction> GetIncomePerPeriod(DateTime startDate, DateTime endDate) => GetProfitStatisticsPerPeriod(startDate, endDate).Where(t => t.Amount > 0M).ToList();

        public List<Transaction> GetOutcomePerperiod(DateTime startDate, DateTime endDate) => GetProfitStatisticsPerPeriod(startDate, endDate).Where(t => t.Amount < 0M).ToList();

        public decimal GetProfitPerPeriod(DateTime startDate, DateTime endDate, out List<Transaction> transactions)
        {
            transactions = GetProfitStatistics().Where(t => t.Time >= startDate && t.Time <= endDate).ToList();
            return transactions.Select(t => t.Amount).Sum();
        }

        public List<Transaction> GetProfitStatistics() => Repository.GetAllTransactions();

        public List<Transaction> GetProfitStatisticsPerPeriod(DateTime startDate, DateTime endDate) => Repository.GetAllTransactions(startDate, endDate);

        public List<Employee> GetTopOfEmployees() 
        {
            var list = Repository.GetAll<Employee>();
            list.Sort(new MyClassComparer());
            return list;
        }

        public decimal GetTotalProfit(out List<Transaction> transactions)
        {
            transactions = GetProfitStatistics();
            return transactions.Select(t => t.Amount).Sum();
        }

        public bool SignUpEmployee(string name, string phone, string password, string position, out string errorMessage, out Employee employee)
        {
            var allEmployees = Repository.GetAll<Employee>();
            if (allEmployees.Exists(u => u.Phone == phone))
            {
                if (password != "")
                {
                    if (position != "")
                    {
                        employee = new Employee { Name = name, Phone = phone, Password = password, Position = position };
                        Add(employee);
                        errorMessage = "";
                    }
                    else
                    {
                        employee = null;
                        errorMessage = "Please enter employee's position";
                    }
                }
                else
                {
                    employee = null;
                    errorMessage = "Password field can't be whitespace";
                }
            }
            else
            {
                employee = null;
                errorMessage = "This phone already exists, please try again or sign in using this phone!";
            }
            return employee != null;
        }

        public List<FeedBack> GetAllFeedBacks() => Repository.GetAll<FeedBack>();
        public List<FeedBack> GetUnreadFeedBacks()
        {
            var feedBacks = GetAllFeedBacks().Where(f => f.Seen == false).ToList();
            foreach (var f in feedBacks)
            {
                f.Seen = true;
            }
            Update(feedBacks);
            return feedBacks;
        }

        public List<Ingredient> GetIngredientInfo() => Repository.GetAll<Ingredient>();

        public void Add<T>(T obj) where T : class
        {
            Repository.Add<T>(obj);
        }

        public T Get<T>(int Id) where T : class
        {
            return Repository.Get<T>(Id);
        }

        public List<T> GetAll<T>() where T : class
        {
            return Repository.GetAll<T>();
        }

        public void Update<T>(T obj) where T : class
        {
            Repository.Update(obj);
        }

        public void UpdateRange<T>(List<T> obj) where T : class
        {
            Repository.UpdateRange(obj);
        }
    }
}
