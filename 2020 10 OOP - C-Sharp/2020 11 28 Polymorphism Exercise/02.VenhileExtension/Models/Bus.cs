using _01.VehiclesKristiyanIvanov.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.VehiclesKristiyanIvanov.Models
{
    public class Bus : Vehicle
    {
        private const double FUEL_INC_AIRCONDITIONER_ON = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }

        public override string Drive(double distance)
        {
            double fuelNeeded = distance * (this.FuelConsumption + FUEL_INC_AIRCONDITIONER_ON);

            if (this.FuelQuantity < fuelNeeded)
            {
                string excMsg = string.Format(Exceptions.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override string DriveEmpty(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption;

            if (this.FuelQuantity < fuelNeeded)
            {
                string excMsg = string.Format(Exceptions.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
