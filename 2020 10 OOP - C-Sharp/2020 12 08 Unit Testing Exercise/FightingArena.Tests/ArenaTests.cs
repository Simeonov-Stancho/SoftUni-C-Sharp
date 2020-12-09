
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private List<Warrior> warriors;
        private Arena dungeon;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warriors = new List<Warrior>();
            dungeon = new Arena();
            warrior = new Warrior("A", 100, 100);
        }

        [TestCase(0)]
        public void ArenaConstructorShouldWorkCorrectly(int expectedResult)
        {
            //Act
            Arena arenaTest = new Arena();

            //Assert
            int actualResult = arenaTest.Warriors.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        public void GetterWarriorsProperty(int expectedResult)
        {
            //Arrange
            IReadOnlyCollection<Warrior> actualResult = this.dungeon.Warriors;

            //Act--Assert
            Assert.AreEqual(expectedResult, actualResult.Count);
        }

        [TestCase(1)]
        public void CountProperty(int expectedResult)
        {
            //Arrange
            this.dungeon.Enroll(warrior);

            //Act--Assert
            int actualResult = this.dungeon.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1)]
        public void EnrollShouldWorkCOrrectly(int expectedResult)
        {
            //Arrange
            Warrior knight = new Warrior("Knight", 50, 70);

            //Act 
            dungeon.Enroll(knight);

            //Assert
            int actualResult = dungeon.Warriors.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EnrollExistingWarriorShouldThrowException()
        {
            //Arrange
            Warrior knight = new Warrior("Knight", 50, 50);
            Warrior existingknight = new Warrior("Knight", 70, 90);

            //Act 
            this.dungeon.Enroll(knight);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                dungeon.Enroll(existingknight);
            }, "Warrior is already enrolled for the fights!");
        }

        [TestCase(10)]
        public void FightShouldWorkProperly(int expectedResult)
        {
            //Arrange
            Warrior attacker = new Warrior("Attacker", 60, 50);
            Warrior defender = new Warrior("Defender", 50, 70);

            //Act 
            this.dungeon.Enroll(attacker);
            this.dungeon.Enroll(defender);
            this.dungeon.Fight("Attacker", "Defender");

            //Assert
            int actualResult = defender.HP;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FightWithNotAddedAttacker()
        {
            //Arrange
            Warrior attacker2 = new Warrior("NoSuchWarrior", 60, 50); ;
            Warrior defender2 = new Warrior("Defender", 50, 70);

            //Act 
            this.warriors.Add(defender2);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dungeon.Fight(attacker2.Name, defender2.Name);
            }, $"There is no fighter with name {attacker2.Name} enrolled for the fights!");
        }

        [Test]
        public void FightWithNotAddedDefender()
        {
            //Arrange
            Warrior attacker3 = new Warrior("Attacker", 60, 50); ;
            Warrior defender3 = new Warrior("NoSuchWarrior", 50, 70);

            //Act 
            this.warriors.Add(attacker3);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.dungeon.Fight(attacker3.Name, defender3.Name);
            }, $"There is no fighter with name {defender3.Name} enrolled for the fights!");
        }
    }
}
