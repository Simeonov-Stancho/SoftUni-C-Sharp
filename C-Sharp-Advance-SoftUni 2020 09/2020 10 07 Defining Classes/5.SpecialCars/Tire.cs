using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialCars
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.TireYear = year;
            this.Pressure = pressure;
        }

        public int TireYear { get; set; }
        public double Pressure { get; set; }
    }
}