using System;
using System.Collections.Generic;

namespace Models
{
    public class MenuPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<MenuIngredient> MenuIngredient { get; set; }
    }
}
