using System;
using System.Collections.Generic;

namespace Models
{
    public class Employee
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public int Position { get; set; }
        public  List<WorkingPeriod> WorkingPeriods { get; set; }
    }
}
