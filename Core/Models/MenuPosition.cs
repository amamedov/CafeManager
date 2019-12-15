﻿using System;
using System.Collections.Generic;

namespace Models
{
    public class MenuPosition
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public List<Ingredient> Ingridients { get; set; }
        public List<int> NumOfEachIngredient { get; set; }
    }
}
