using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MIN_CAR_MODEL_SYMBOLS_LENGTH = 4;

        private string model;
        private int horsePower;
        private readonly double cubicCentimeters;
        private readonly int minHorsePower;
        private readonly int maxHorsePower;

        public Car(string model, int horsePower, double cubicCentimeters, 
                   int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.Model = model;
            this.HorsePower = horsePower;
        }

        public string Model
        {
            get { return this.model; }

            private set
            {
                if ((string.IsNullOrWhiteSpace(value)) ||
                    (value.Length < MIN_CAR_MODEL_SYMBOLS_LENGTH) ||
                    (value == null))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, MIN_CAR_MODEL_SYMBOLS_LENGTH));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsePower; }

            private set
            {
                if (value < this.minHorsePower || value > this.maxHorsePower)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = this.CubicCentimeters / this.horsePower * laps;
            return racePoints;
        }
    }
}
