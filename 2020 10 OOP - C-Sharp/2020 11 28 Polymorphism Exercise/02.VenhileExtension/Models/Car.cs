using System;
using System.Collections.Generic;
using System.Text;

namespace _01.VehiclesKristiyanIvanov.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONS_INC = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override double FuelConsumption
        {
            get { return base.FuelConsumption + FUEL_CONS_INC; }
        }
    }
}