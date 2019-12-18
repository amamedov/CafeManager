using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IEmployeeService
    {
        bool SignIn(string phone, string password, out string errorMessage, out Employee employee);
        void MakeOrder(Order order);
        void MakeIngredientsOrder(Dictionary<int, int> order);
        void StartWorking();
        void EndWorking();
    }
}
