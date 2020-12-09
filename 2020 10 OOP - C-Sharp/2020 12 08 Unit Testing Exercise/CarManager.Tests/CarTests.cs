
using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        private readonly string make = "BMW";
        private readonly string model = "335d";
        private readonly double fuelConsumption = 10.5;
        private readonly double fuelCapacity = 60.66;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [TestCase(0)]
        public void BaseCarConstructorShouldWorkCorrectly(double expectedResult)
        {
            //Act -- Assert
            double actualResult = this.car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("BMW", "335d", 10.5, 60.66)]
        public void ChildCarConstructorShouldWorkCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Act -- Assert
            string actualMake = this.car.Make;
            string actualModel = this.car.Model;
            double actualfuelConsumption = this.car.FuelConsumption;
            double actualfuelCapacity = this.car.FuelCapacity;
            Assert.AreEqual(make, actualMake);
            Assert.AreEqual(model, actualModel);
            Assert.AreEqual(fuelConsumption, actualfuelConsumption);
            Assert.AreEqual(fuelCapacity, actualfuelCapacity);
        }

        [TestCase("BMW")]
        public void MakeGeterShouldWorkCorrectly(string expectedResult)
        {
            //Act -- Assert
            string actualResult = this.car.Make;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeSeterShouldReturnArgumentExceptionIfMakeIsNullOrEmpty(string currentMake)
        {
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(currentMake, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }

        [TestCase("335d")]
        public void ModelGeterShouldWorkCorrectly(string expectedResult)
        {
            //Act -- Assert
            string actualResult = this.car.Model;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelSeterShouldReturnArgumentExceptionIfMakeIsNullOrEmpty(string currentModel)
        {
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, currentModel, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [TestCase(10.5)]
        public void FuelConsumptionGeterShouldWorkCorrectly(double expectedResult)
        {
            //Act -- Assert
            double actualResult = this.car.FuelConsumption;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        [TestCase(-10.99)]
        public void FuelConsumptionSeterShouldReturnArgumentExceptionIfMakeIsNullOrNegative(double currentFuelConsumption)
        {
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, model, currentFuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase(60.66)]
        public void FuelCapacityGeterShouldWorkCorrectly(double expectedResult)
        {
            //Act -- Assert
            double actualResult = this.car.FuelCapacity;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void FuelCapacitySeterShouldReturnArgumentExceptionIfMakeIsNullOrNegative(double currentFuelCapacity)
        {
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Car(make, model, fuelConsumption, currentFuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(0)]
        [TestCase(-30.3)]
        public void RefuelShouldReturnArgumentExceptionIfMakeItWithNullOrNegative(double fuelToRefuel)
        {
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.car.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(30.66, 30.66)]
        public void RefuelShouldWorkCorrectly(double fuelToRefuel, double expectedResult)
        {
            //Act 
            this.car.Refuel(fuelToRefuel);

            //Assert
            double actualResult = this.car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(666.88, 60.66)]
        public void RefuelShouldWorkCorrectlyWithRefuelingAmount(double fuelToRefuel, double expectedResult)
        {
            //Act
            this.car.Refuel(fuelToRefuel);

            // Assert
            double actualResult = this.car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(10)]
        public void DriveShouldWorkCorrectly(double distance)
        {
            //Act
            this.car.Refuel(100);
            this.car.Drive(distance);

            //Assert
            double expectedResult = 59.61;
            double actualResult = this.car.FuelAmount;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1000.1)]
        public void DriveShouldThrowExceptionIfNotEnoughtFuel(double distance)
        {
            //Act -- Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.car.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }

    }
}