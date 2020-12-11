using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private const string ExistingDriver = "Driver {0} is already added.";
        private const string DriverInvalid = "Driver cannot be null.";
        private const string DriverAdded = "Driver {0} added in race.";
        private const int MinParticipants = 2;
        private const string RaceInvalid = "The race cannot start with less than {0} participants.";


        string model = "BMW";
        int horsePOwer = 306;
        double cubicCentimeters = 3500.6;
        UnitCar car;
        UnitDriver driver;
        string driverName = "Shumi";

        private Dictionary<string, UnitDriver> driverEntry;
        private RaceEntry raceOne;

        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar(model, horsePOwer, cubicCentimeters);
            this.driver = new UnitDriver(driverName, this.car);
            this.raceOne = new RaceEntry();
            this.raceOne.AddDriver(driver);

        }

        [TestCase("BMW")]
        public void CarConstructorShouldWorkCorrectly(string expectedResult)
        {
            //Arrange
            UnitCar bmw = new UnitCar(model, horsePOwer, cubicCentimeters);

            //Assert
            Assert.AreEqual(expectedResult, bmw.Model);
        }

        [TestCase("BMW")]
        public void CarNameGetShouldWorkCorrectly(string expectedResult)
        {
            //Assert

            Assert.AreEqual(expectedResult, this.car.Model);
        }

        [TestCase(306)]
        public void CarHorsePowerGetShouldWorkCorrectly(int expectedResult)
        {
            //Assert
            Assert.AreEqual(expectedResult, this.car.HorsePower);
        }

        [TestCase(3500.6)]
        public void CarCubicCentimetersGetShouldWorkCorrectly(double expectedResult)
        {
            //Assert
            Assert.AreEqual(expectedResult, this.car.CubicCentimeters);
        }


        [TestCase("Shumi")]
        public void DriverConstructorShouldWorkCorrectly(string expectedResult)
        {
            //Arrange
            UnitDriver otherDriver = new UnitDriver(driverName, this.car);

            //Assert
            Assert.AreEqual(expectedResult, otherDriver.Name);
        }

        [TestCase("Shumi")]
        public void DriverNameGetShouldWorkCorrectly(string expectedResult)
        {
            //Assert
            Assert.AreEqual(expectedResult, this.driver.Name);
        }

        [Test]
        public void DriverNameNullShouldThrowException()
        {
            string nullName = null;

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                new UnitDriver(nullName, this.car);
            }, nullName, "Name cannot be null!");
        }

        [Test]
        public void DriverCarGetShouldWorkCorrectly()
        {
            //Arrange
            string expectedCarModel = this.car.Model;

            //Assert
            string actualCarModel = this.driver.Car.Model;
            Assert.AreEqual(expectedCarModel, actualCarModel);
        }

        [Test]
        public void ReceConstructorShouldWorkCorrectly()
        {
            //Arrange
            RaceEntry newRace = new RaceEntry();

            //Act -- Assert
            int actualResult = newRace.Counter;
            Assert.AreEqual(0, actualResult);
        }

        [TestCase(1)]
        public void ReceCounterShouldWorkCorrectly(int expectedResult)
        {
            //Act -- Asseert
            int actualResult = this.raceOne.Counter;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReceAddShouldWorkCorrectly()
        {
            //Arrange
            RaceEntry newRace = new RaceEntry();

            //Assert
            string expectedResult = $"Driver {this.driver.Name} added in race.";
            string actualResult = newRace.AddDriver(this.driver);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ReceAddNullDriverShouldThrowException()
        {
            //Arrange
            RaceEntry newRace = new RaceEntry();
            UnitDriver nullDriver = null;

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                newRace.AddDriver(nullDriver);
            }, DriverInvalid);
        }

        [Test]
        public void TryToAddExistingDriverShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceOne.AddDriver(this.driver);
            }, string.Format(ExistingDriver, driver.Name));
        }

        [Test]
        public void TryToCalculateAverageHorsePowerOfOneDriverShouldThrowException()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.raceOne.CalculateAverageHorsePower();
            }, string.Format(RaceInvalid, MinParticipants));
        }

        [TestCase(275.5)]
        public void TryToCalculateAverageHorsePowerWork(double expectedResult)
        {
            //Arrange
            UnitCar secondCar = new UnitCar("BMWx5", 245, 3000);
            UnitDriver secondDriver = new UnitDriver("GoshoByrzoto", secondCar);

            //Act
            this.raceOne.AddDriver(secondDriver);
            //Assert
            double actualResult = this.raceOne.CalculateAverageHorsePower();
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}