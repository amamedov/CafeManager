using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MenuIngredient
    {
        public int Id { get; set; }
        public int MenuPositionId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }

    }
}
