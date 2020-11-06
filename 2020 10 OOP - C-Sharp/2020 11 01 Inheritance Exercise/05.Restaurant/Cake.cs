using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double DefaultCakeGrams = 250;
        private const double DefaultCakeCalories = 1000;
        private const decimal DefaultCakePrice= 5m;

        public Cake(string name)
            : base(name, DefaultCakePrice, DefaultCakeGrams, DefaultCakeCalories)
        {
        }
    }
}
