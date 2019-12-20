using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class WorkingPeriod
    {
        public int Id { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
    }
}
