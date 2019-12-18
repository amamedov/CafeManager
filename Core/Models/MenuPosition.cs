﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class MenuPosition
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Dictionary<int, int> IngredientQuantity { get; set; }
    }
}
