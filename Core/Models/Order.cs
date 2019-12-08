using System;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public float TotalSum { get; set; }
        public int NumberOfPositions { get; set; }
        public int? UserID { get; set; }
        public bool IsTakeAway { get; set; }
    }
}
