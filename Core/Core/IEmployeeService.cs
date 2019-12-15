using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IEmployeeService
    {
        bool SignIn(string phone, string password, out Employee employee);
        bool MakeOrder();
        List<string> GetStatistics();
    }
}
