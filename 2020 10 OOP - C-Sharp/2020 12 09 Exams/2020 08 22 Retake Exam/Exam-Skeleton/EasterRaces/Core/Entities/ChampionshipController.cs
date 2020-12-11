using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;
        private const int PARTICIPANTS_FOR_START = 3;

        private CarRepository cars;
        private DriverRepository drivers;
        private RaceRepository races;


        public ChampionshipController()
        {
            this.cars = new CarRepository();
            this.drivers = new DriverRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (!this.cars.GetAll().Any(c => c.Model == carModel))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            ICar currrentCar = this.cars.GetAll().FirstOrDefault(c => c.Model == carModel);
            IDriver currentDriver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            currentDriver.AddCar(currrentCar);

            return string.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (!this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            IDriver currentDriver = this.drivers.GetAll().FirstOrDefault(d => d.Name == driverName);
            IRace currentRace = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);
            currentRace.AddDriver(currentDriver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetAll().Any(c => c.Model == model))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            ICar currentCar = null;

            if (type == "Muscle")
            {
                currentCar = new MuscleCar(model, horsePower);
            }

            else if (type == "Sports")
            {
                currentCar = new SportsCar(model, horsePower);
            }

            this.cars.Add(currentCar);
            return string.Format(OutputMessages.CarCreated, currentCar.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetAll().Any(d => d.Name == driverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            Driver currentDriver = new Driver(driverName);
            this.drivers.Add(currentDriver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetAll().Any(r => r.Name == name))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            IRace currentRace = new Race(name, laps);
            this.races.Add(currentRace);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (!this.races.GetAll().Any(r => r.Name == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IRace race = this.races.GetAll().FirstOrDefault(r => r.Name == raceName);

            if (race.Drivers.Count < MIN_PARTICIPANTS)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
            }

            List<IDriver> firstThreeDrivers = race.Drivers
                .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                .Take(PARTICIPANTS_FOR_START)
                .ToList();

            StringBuilder resultOfRace = new StringBuilder();
            IDriver firstDriver = firstThreeDrivers.First();
            IDriver secondDriver = firstThreeDrivers.Skip(1).First();
            IDriver thirdDriver = firstThreeDrivers.Skip(2).First();

            resultOfRace.AppendLine(string.Format(OutputMessages.DriverFirstPosition, firstDriver.Name, race.Name));
            resultOfRace.AppendLine(string.Format(OutputMessages.DriverSecondPosition, secondDriver.Name, race.Name));
            resultOfRace.AppendLine(string.Format(OutputMessages.DriverThirdPosition, thirdDriver.Name, race.Name));

            this.races.Remove(race);
            return resultOfRace.ToString().Trim();

        }
    }
}
