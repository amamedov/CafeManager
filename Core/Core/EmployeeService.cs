using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Core
{
    class EmployeeService : IService
    {
        private dbRepository Repository { get; set; }
        private Employee employee;
        private WorkingPeriod WorkingTime;

        public EmployeeService(dbRepository repository)
        {
            Repository = repository;
        }
        public void MakeOrder(Order order)
        {
            order.DeliveryTime = DateTime.Now;
            Update(order);
        }

        public void MakeIngredientsOrder(Dictionary<int, int> order)
        {
            var newTransaction = new Transaction { Time = DateTime.Now, Amount = 0 };
            foreach (var o in order)
            {
                var ingredient = Get<Ingredient>(o.Key);
                ingredient.QuantityInStorage += o.Value;
                newTransaction.Amount += Convert.ToDecimal(ingredient.Price * o.Value);
                Update(ingredient);
            }
            Add(newTransaction);
        }

        public bool SignIn(string phone, string password, out string errorMessage, out Employee employee)
        {
            var allEmployees = Repository.GetAll<Employee>();
            if (allEmployees.Exists(u => u.Phone == phone))
                if (allEmployees.Exists(u => u.Phone == phone && u.Password == password))
                {
                    errorMessage = "";
                    employee = allEmployees.Find(u => u.Phone == phone && u.Password == password);
                }
                else
                {
                    errorMessage = "Password is incorrect, try again!";
                    employee = null;
                }
            else
            {
                errorMessage = "This phone does not exist, try again or sign up!";
                employee = null;
            }
            return employee != null;
        }

        public void StartWorking()
        {
            WorkingTime.StartDt = DateTime.Now;
        }
        public void EndWorking()
        {
            WorkingTime.EndDt = DateTime.Now;
            employee.WorkingPeriods.Add(WorkingTime);
        }

        public void Add<T>(T obj) where T : class
        {
            Repository.Add(obj);
        }

        public T Get<T>(int Id) where T : class => Repository.Get<T>(Id);

        public List<T> GetAll<T>() where T : class => Repository.GetAll<T>();

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
