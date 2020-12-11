using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {
        string manufacturer = "HP";
        string model = "Omen";
        decimal price = 2600.6m;
        Computer firstPC;
        private List<Computer> computers;
        ComputerManager cm;

        [SetUp]
        public void Setup()
        {
            this.firstPC = new Computer(manufacturer, model, price);
            this.computers = new List<Computer>();
            this.computers.Add(firstPC);
            this.cm = new ComputerManager();
        }

        [TestCase("Sony", "Vaio", 200.3)]
        public void ComputerConstructorShouldWork(string expectedManufacturer,
                                                   string expectedModel,
                                                   decimal expectedPrice)
        {
            //Arrange -- Act
            Computer pcTest = new Computer("Sony", "Vaio", 200.3m);

            //Assert
            string actualManufacturer = pcTest.Manufacturer;
            string actualModel = pcTest.Model;
            decimal actualPrice = pcTest.Price;
            Assert.AreEqual(expectedManufacturer, actualManufacturer);
            Assert.AreEqual(expectedModel, actualModel);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestCase("Omen")]
        public void ComputerModelrShouldWork(string expectedModel)
        {
            //Assert
            string actualModel = this.firstPC.Model;
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase("2600.6")]
        public void ComputerPriceShouldWork(decimal expectedPrice)
        {
            //Assert
            decimal actualPrice = this.firstPC.Price;
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            this.cm = new ComputerManager();
            Assert.AreEqual(0, cm.Count);
            Assert.IsEmpty(this.cm.Computers);
        }

        [TestCase(0)]
        public void ComputerManagerCountShouldWork(int expectedResult)
        {
            //Arrange
            ComputerManager current = new ComputerManager();

            int actualCount = cm.Count;
            Assert.AreEqual(expectedResult, actualCount);
        }

        [TestCase(1)]
        public void ComputerManagerAddShouldWork(int expectedResult)
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            currentCM.AddComputer(currentPC);

            //Assert
            int actualCount = currentCM.Count;
            Assert.AreEqual(expectedResult, actualCount);
            Assert.AreEqual("Sony", currentCM.GetComputer(currentPC.Manufacturer, currentPC.Model).Manufacturer);
            Assert.AreEqual("Vaio", currentCM.GetComputer(currentPC.Manufacturer, currentPC.Model).Model);
            Assert.AreEqual(1000, currentCM.GetComputer(currentPC.Manufacturer, currentPC.Model).Price);
        }

        [Test]
        public void ComputerManagerAddNullShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { currentCM.AddComputer(null); }
            , "Can not be null!");
        }



        [Test]
        public void ComputerManagerAddSamePCShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            Computer sameManufacturesPC = new Computer("Sony", "Vaio", 20);

            currentCM.AddComputer(currentPC);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            { currentCM.AddComputer(sameManufacturesPC); }
            , "This computer already exists.");
        }

        [TestCase(1)]
        public void ComputerManagerRemoveShouldWork(int expectedResult)
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            Computer sameManufacturesPC = new Computer("Sony", "777", 20);
            currentCM.AddComputer(currentPC);
            currentCM.AddComputer(sameManufacturesPC);
            currentCM.RemoveComputer("Sony", "Vaio");

            //Assert
            int actualCount = currentCM.Count;
            Assert.AreEqual(expectedResult, actualCount);
        }

        [Test]
        public void ComputerManagerRemoveShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            Computer sameManufacturesPC = new Computer("Sony", "777", 20);

            currentCM.AddComputer(currentPC);
            currentCM.AddComputer(sameManufacturesPC);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            { currentCM.RemoveComputer("HP", "Omen"); }
            , "There is no computer with this manufacturer and model.");
        }


        [Test]
        public void ComputerManagerRemoveNullModelShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { currentCM.RemoveComputer("Sony", null); }
            , "Can not be null!");
        }

        [Test]
        public void ComputerManagerRemoveNullManufacturesShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            { currentCM.RemoveComputer(null, "Vaio"); }
            , "Can not be null!");
        }

        [Test]
        public void ComputerManagerGetComputerShouldWork()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            currentCM.AddComputer(currentPC);


            //Assert
            Computer actualComputer = currentCM.GetComputer("Sony", "Vaio");
            Assert.AreEqual(currentPC, actualComputer);
        }

        [Test]
        public void ComputerManagerGetComputerShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);

            currentCM.AddComputer(currentPC);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            { currentCM.GetComputer("BG", "PC"); }
            , "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void ComputerManagerGetComputerByManufacturesShouldWork()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            currentCM.AddComputer(currentPC);

            //Assert
            ICollection<Computer> computers = currentCM.GetComputersByManufacturer("Sony");
            Assert.AreEqual(currentCM.Computers, computers);
        }

        [Test]
        public void ComputerManagerGetComputerByManufacturesShouldThrowException()
        {
            //Arrange
            ComputerManager currentCM = new ComputerManager();
            Computer currentPC = new Computer("Sony", "Vaio", 1000);
            currentCM.AddComputer(currentPC);

            ICollection<Computer> actualCollection = currentCM.GetComputersByManufacturer("BG");
            int actualResult = actualCollection.Count;

            Assert.AreEqual(0, actualResult);
        }

    }
}