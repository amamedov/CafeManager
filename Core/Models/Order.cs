using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public float TotalSum { get; set; }
        public List<MenuPosition> MenuPositions {get;set;}
        public int? UserID { get; set; }
        public bool IsTakeAway { get; set; }
    }
}
