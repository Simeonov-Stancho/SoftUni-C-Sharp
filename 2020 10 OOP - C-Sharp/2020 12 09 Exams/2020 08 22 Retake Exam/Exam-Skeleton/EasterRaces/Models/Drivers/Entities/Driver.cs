using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MIN_CAR_NAME_SYMBOLS_LENGTH = 5;
        private const bool DEFAULT_CAN_PARTICIPATE = false;

        private string name;
        private bool canParticipate;


        public Driver(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if ((string.IsNullOrEmpty(value) ||
                    (value.Length < MIN_CAR_NAME_SYMBOLS_LENGTH)))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_CAR_NAME_SYMBOLS_LENGTH));
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate
        {
            get { return this.canParticipate; }

            private set
            {
                if (this.Car == null)
                {
                    this.canParticipate = DEFAULT_CAN_PARTICIPATE;
                }

                else
                {
                    this.canParticipate = true;
                }
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
