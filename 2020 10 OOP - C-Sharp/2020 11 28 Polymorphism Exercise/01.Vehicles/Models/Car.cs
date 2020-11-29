using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : Vehicle
    {
        private const double CONSUMATION_INCR = 0.9;

        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {

        }

        public override double FuelConsumption 
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + CONSUMATION_INCR; }
        }
    }
}
