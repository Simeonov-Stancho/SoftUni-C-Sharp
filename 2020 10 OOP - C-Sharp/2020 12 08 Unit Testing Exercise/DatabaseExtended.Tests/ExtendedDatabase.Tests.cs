using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Person person;
        private ExtendedDatabase.ExtendedDatabase extendedDatabase;
        private readonly Person[] persons = new Person[]
        {
            new Person(6666,"Gosho"),
            new Person(7777, "Tosho")
        };

        [SetUp]
        public void Setup()
        {
            this.person = new Person(6666, "Dimitrichko");
            this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);
        }

        [Test]
        [TestCase(6666)]
        public void PersonConstructorIDShoulWorkCorrectly(long expectedResult)
        {
            //Act - Assert
            long actualResult = this.person.Id;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("Dimitrichko")]
        public void PersonConstructorNameShoulWorkCorrectly(string expectedResult)
        {
            //Act - Assert
            string actualResult = this.person.UserName;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2)]
        public void ExtendedDatabaseConstructorShoulWorkCorrectly(int expectedResult)
        {
            //Arrange
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(persons);

            //Act - Assert
            long actualResult = this.extendedDatabase.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExtendedDatabaseConstructorShoulThrowExceptionWithBiggerCollection()
        {
            //Arrange
            Person[] personsCountOf17 = new Person[]
        {
            new Person(1111,"Aosho"),
            new Person(2222, "Bosho"),
            new Person(3333, "Cosho"),
            new Person(4444, "Dosho"),
            new Person(5555, "Eosho"),
            new Person(6666, "Fosho"),
            new Person(7777, "Gosho0"),
            new Person(8888, "Hosho"),
            new Person(9999, "Iosho"),
            new Person(10, "Gosho"),
            new Person(11, "Kosho"),
            new Person(12, "Losho"),
            new Person(13, "Mosho"),
            new Person(14, "Nosho"),
            new Person(15, "Oosho"),
            new Person(16, "Posho"),
            new Person(17, "Qosho")
        };
            //Act -- Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.extendedDatabase = new ExtendedDatabase.ExtendedDatabase(personsCountOf17);
            }, "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void ExtendedDatabaseAddShoulThrowExceptionWithBiggerCollection()
        {
            //Arrange
            Person[] personsCountOf16 = new Person[]
        {
            new Person(1111,"Aosho"),
            new Person(2222, "Bosho"),
            new Person(3333, "Cosho"),
            new Person(4444, "Dosho"),
            new Person(5555, "Eosho"),
            new Person(6666, "Fosho"),
            new Person(7777, "Gosho0"),
            new Person(8888, "Hosho"),
            new Person(9999, "Iosho"),
            new Person(10, "Gosho"),
            new Person(11, "Kosho"),
            new Person(12, "Losho"),
            new Person(13, "Mosho"),
            new Person(14, "Nosho"),
            new Person(15, "Oosho"),
            new Person(16, "Posho")
        };
            extendedDatabase = new ExtendedDatabase.ExtendedDatabase(personsCountOf16);

            //Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(new Person(17, "OutOf"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void ExtendedDatabaseAddShoulThrowExceptionWithExistingUserName()
        {
            //Arrange
            Person existingPerson = new Person(1, "Gosho");

            //Act -- Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(existingPerson);
            }, "There is already user with this username!");
        }

        [Test]
        public void ExtendedDatabaseAddShoulThrowExceptionWithExistingUserId()
        {
            //Arrange
            Person existingPerson = new Person(6666, "Nema");

            //Act -- Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.Add(existingPerson);
            }, "There is already user with this Id!");
        }

        [Test]
        public void ExtendedDatabaseRemoveShoulThrowExceptionWhenCountIsZero()
        {
            //Arrange
            extendedDatabase.Remove();
            extendedDatabase.Remove();

            //Act -- Assert

            Assert.Throws<InvalidOperationException>(
                () => extendedDatabase.Remove()
            );
        }

        [TestCase(1)]
        public void ExtendedDatabaseRemoveShouldDecreaseCount(int expectedResult)
        {
            //Arrange
            extendedDatabase.Remove();

            //Act -- Assert
            int actualResult = extendedDatabase.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ExtendedDatabaseFindByUsernameShoulThrowExceptionWithNoName()
        {
            //Arrange
            string noName = String.Empty;

            //Act -- Assert

            Assert.Throws<ArgumentNullException>(() =>
            {
                extendedDatabase.FindByUsername(noName);
            }, "Username parameter is null!");
        }

        [Test]
        public void ExtendedDatabaseFindByUsernameShoulThrowExceptionWithNotExistingUser()
        {
            //Arrange
            string notExistingUserName =  "NoSuchUser";

            //Act -- Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindByUsername(notExistingUserName);
            }, "No user is present by this username!");
        }

        [Test]
        public void ExtendedDatabaseFindByUsernameShoulWorkCorrectly()
        {
            //Arrange
            Person personExists = new Person(6666, "Gosho");

            //Act -- Assert
            Person existingPerson = extendedDatabase.FindByUsername(personExists.UserName);

            Assert.AreEqual(personExists.UserName, existingPerson.UserName);
        }


        [Test]
        public void ExtendedDatabaseFindByIdShoulThrowExceptionWithNegativeId()
        {
            //Arrange
            long negativeID = -100;

            //Act -- Assert

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                extendedDatabase.FindById(negativeID);
            }, "Id should be a positive number!");
        }

        [Test]
        public void ExtendedDatabaseFindByIdShoulThrowExceptionfsdWithNotExistingId()
        {
            //Arrange
            long notExistingId = 123;

            //Act -- Assert

            Assert.Throws<InvalidOperationException>(() =>
            {
                extendedDatabase.FindById(notExistingId);
            }, "No user is present by this ID!");
        }

        [Test]
        public void ExtendedDatabaseFindByIdShoulWorkCorrectly()
        {
            //Arrange
            Person personExists = new Person(6666, "Gosho");

            //Act -- Assert
            Person existingPerson = extendedDatabase.FindById(personExists.Id);

            Assert.AreEqual(personExists.Id, existingPerson.Id);
        }
    }
}
