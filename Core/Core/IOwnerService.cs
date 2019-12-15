using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    interface IOwnerService
    {
        List<string> GetStatistics();
        List<Employee> GetTopOfEmployees();
        decimal GetTotalProfit(out List<string> statistics);
        bool SignUpEmployee(out Employee employee);
    }
}
