using System;
using System.Collections.Generic;
using System.Linq;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MIN_RACE_NAME_SYMBOLS_LENGTH = 5;
        private const int MIN_RACE_LAPS = 1;

        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if ((string.IsNullOrEmpty(value) ||
                    (value.Length < MIN_RACE_NAME_SYMBOLS_LENGTH)))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, MIN_RACE_NAME_SYMBOLS_LENGTH));
                }

                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }

            private set
            {
                if (value < MIN_RACE_LAPS)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_RACE_LAPS));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers
        {
            get { return this.drivers.ToList().AsReadOnly(); }
        }

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Any(d => d.Name == driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
