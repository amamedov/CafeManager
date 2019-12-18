using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public decimal Amount { get; set; }
    }
}
