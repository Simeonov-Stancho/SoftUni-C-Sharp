using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0.00;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Calculate(Car car, double amountOfKm)
        {
            double neededFuel = amountOfKm * car.fuelConsumptionPerKilometer;
            if (car.fuelAmount >= neededFuel)
            {
                car.fuelAmount -= neededFuel;
                car.travelledDistance += amountOfKm;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}