using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Core
{
    class EmployeeService : IEmployeeService
    {
        private IRepository Repository { get; set; }
        private Employee employee;
        private WorkingPeriod WorkingTime;

        public EmployeeService(IRepository repository)
        {
            Repository = repository;
        }
        public void MakeOrder(Order order)
        {
            order.DeliveryTime = DateTime.Now;
            Repository.SaveOrderInfo(order);
        }

        public void MakeIngredientsOrder(Dictionary<int, int> order)
        {
            var newTransaction = new Transaction { Time = DateTime.Now, Amount = 0 };
            foreach (var o in order)
            {
                var ingredient = Repository.GetIngredient(o.Key);
                ingredient.QuantityInStorage += o.Value;
                newTransaction.Amount += Convert.ToDecimal(ingredient.Price * o.Value);
                Repository.SaveIngredientInfo(ingredient);
            }
            Repository.AddTransaction(newTransaction);
        }

        public bool SignIn(string phone, string password, out string errorMessage, out Employee employee)
        {
            var allEmployees = Repository.GetAllEmployees();
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
    }
}
