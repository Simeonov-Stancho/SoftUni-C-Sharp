using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private static double CONSUMPTION_INCR = 1.6;
        private static double TANK_CAPACITY = 0.95;

        public Truck(double fuelQuantity, double fuelConsumation)
            : base(fuelQuantity, fuelConsumation)
        {

        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption; }
            protected set { base.FuelConsumption = value + CONSUMPTION_INCR; }
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TANK_CAPACITY);
        }
    }
}
