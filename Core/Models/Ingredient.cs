using System;
using System.Collections.Generic;


namespace Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
        public float QuantityInStorage { get; set; }
        public string Measurement { get; set; }
    }
}
