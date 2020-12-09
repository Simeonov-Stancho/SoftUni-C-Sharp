using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        private readonly int[] testData = Enumerable.Range(1, 10).ToArray();

        [SetUp]
        public void Setup()
        {
            this.database = new Database.Database(testData);
        }

        [Test]
        [TestCase(10)]
        public void TestConstructorWorkingCorrectly(int expectedResult)
        {
            //Arrange -- SetUp
            //Act -- Assert
            int actualResult = this.database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfMoreOf16Elements()
        {
            //Arrange
            int[] data = Enumerable.Range(1, 17).ToArray();

            //Act -- Assert
            Assert.Throws<InvalidOperationException>(
                () => this.database = new Database.Database(data));
        }

        [TestCase(11)]
        public void CheckAddElementAtTheNExtFreeCell(int expectedResult)
        {
            //Arrange -- SetUp

            //Act 
            this.database.Add(1);

            //Assert
            int actualResult = this.database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddMethodShouldThrowIOEIfTryToAddMoreOf16Element()
        {
            //Arrange
            int[] data = Enumerable.Range(1, 16).ToArray();
            database = new Database.Database(data);

            //Act -- Assert
            Assert.Throws<InvalidOperationException>(
                () => this.database.Add(1));
        }

        [TestCase(9)]
        public void CheckRemoveElementAtTheLastIndex(int expectedResult)
        {
            //Arrange -- SetUp

            //Act 
            this.database.Remove();

            //Assert
            int actualResult = this.database.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfTryToRemoveFromEmptyDatabase()
        {
            //Arrange
            int[] data = new int[0];
            database = new Database.Database(data);

            //Act -- Assert
            Assert.Throws<InvalidOperationException>(
                () => this.database.Remove());
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void CheckFetchMethod(int[] expectedData)
        {
            //Arrange -- SetUp

            //Act -- Assert
            int[] actualResult = this.database.Fetch();
            Assert.AreEqual(expectedData, actualResult);
        }
    }
}