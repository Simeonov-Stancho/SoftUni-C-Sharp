using System;

using _01.VehiclesKristiyanIvanov.Common.Exceptions;
using _01.VehiclesKristiyanIvanov.Contracts;

namespace _01.VehiclesKristiyanIvanov.Models
{
    public abstract class Vehicle : IDriveable, IRefuelable
    {
        private const string SUCC_DRIVED_MSG = "{0} travelled {1} km";

        public double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }

                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; private set; }

        public virtual string Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;

            if (neededFuel > this.FuelQuantity)
            {
                throw new InvalidOperationException(string.Format(Exceptions.NOT_ENOUGH_FUEL_EXC_MSG, this.GetType().Name));
            }

            this.FuelQuantity -= neededFuel;
            return String.Format(SUCC_DRIVED_MSG, this.GetType().Name, distance);
        }

        public virtual string DriveEmpty(double distance)
        {
            return this.Drive(distance);
        }

        public virtual void Refuel(double liters)
        {
            if (this.TankCapacity < (liters + this.FuelQuantity))
            {
                throw new InvalidOperationException(string.Format(Exceptions.NOT_ENOUGHT_TANK_CAPACITY_EXC_MSG, liters));
            }

            if (liters <= 0)
            {
                throw new InvalidOperationException(Exceptions.FUEL_CANT_BE_NEGATIVE);
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}