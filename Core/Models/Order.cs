using System;
using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalSum { get; set; }
        public List<MenuPosition> MenuPositions {get;set;}
        public int? UserId { get; set; }
        public DateTime DeliveryTime { get; set; }
        public bool IsTakeAway { get; set; }
    }
}
