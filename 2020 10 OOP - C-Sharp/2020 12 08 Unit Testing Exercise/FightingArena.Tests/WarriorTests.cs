
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        private readonly string name = "Diablo";
        private readonly int damage = 100;
        private readonly int hp = 100;
        private Warrior warrior;
        private Warrior attacker;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(name, damage, hp);
            this.attacker = new Warrior("Knight", 200, 200);
        }

        [TestCase("Diablo", 100, 100)]
        public void WarriorConstructorShouldWorkCorrectly(string expectedName,
                                                          int expectedDamage,
                                                          int expectedHP)
        {
            //Assert
            Assert.AreEqual(expectedName, this.warrior.Name);
            Assert.AreEqual(expectedDamage, this.warrior.Damage);
            Assert.AreEqual(expectedHP, this.warrior.HP);
        }

        [TestCase("Diablo")]
        public void WarriorNameShouldWorkCorrectly(string expectedName)
        {
            //Assert
            Assert.AreEqual(expectedName, this.warrior.Name);
        }

        [TestCase(null)]
        [TestCase("     ")]
        public void WarriorNameShouldThrowArgumentExceptionIfItIsNullOrWhiteSpace(string invalidName)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(invalidName, damage, hp);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(100)]
        public void WarriorDamageShouldWorkCorrectly(int expectedDamage)
        {
            //Assert
            int actualResult = this.warrior.Damage;
            Assert.AreEqual(expectedDamage, actualResult);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void WarriorDamageShouldThrowArgumentExceptionIfItIsNullOrNegative(int invalidDamage)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(name, invalidDamage, hp);
            }, "Damage value should be positive!");
        }

        [TestCase(100)]
        public void WarriorHpShouldWorkCorrectly(int expectedHp)
        {
            //Assert
            Assert.AreEqual(expectedHp, this.warrior.HP);
        }

        [TestCase(-10)]
        public void WarriorHpShouldThrowArgumentExceptionIfItHPIsNegative(int invalidHp)
        {
            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                new Warrior(name, damage, invalidHp);
            }, "HP should not be negative!");
        }


        [TestCase(25)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionIfHpOfAttackerIsLessOfConst(int currentHp)
        {
            //Arrange
            Warrior weakWarrior = new Warrior("Weak", 90, currentHp);
            Warrior someWarrior = new Warrior("Some", 20, 100);

            //Act -- Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                weakWarrior.Attack(someWarrior);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(27)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionIfHpOfVictimIsLessOfConst(int currentHp)
        {
            //Arrange
            Warrior weakWarrior = new Warrior("Weak", 90, currentHp);
            Warrior someWarrior = new Warrior("Some", 20, 100);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                someWarrior.Attack(weakWarrior);
            }, $"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [TestCase(199)]
        public void AttackShouldThrowExceptionIfHpIsLessOfWarriorDMG(int currentHp)
        {
            //Arrange
            Warrior weakWarrior = new Warrior("Weak", 90, currentHp);
            Warrior someWarrior = new Warrior("Some", 200, 100);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                weakWarrior.Attack(someWarrior);
            }, $"You are trying to attack too strong enemy");
        }

        [TestCase(90)]
        public void AttackWorkCorrectly(int expectedHP)
        {
            //Arrange
            Warrior attackerWarrior = new Warrior("Weak", 10, 100);

            //Act
            warrior.Attack(attackerWarrior);

            //Assert
            int actualHP = this.warrior.HP;
            Assert.AreEqual(expectedHP, actualHP);


        }

        [TestCase(0)]
        public void AttackWithMOreDamageOfWariorHp(int expectedWarriorHP)
        {
            //Arrange
            Warrior attackerWarrior = new Warrior("Weak", 90, 50);

            //Act
            warrior.Attack(attackerWarrior);

            //Assert
            int actualHP = attackerWarrior.HP;
            Assert.AreEqual(expectedWarriorHP, actualHP);
        }

        [TestCase(20)]
        public void AttackWarriorShouldWork(int expectedWarriorHP)
        {
            //Arrange
            Warrior attackedWarrior = new Warrior("Weak", 90, 120);

            //Act
            warrior.Attack(attackedWarrior);

            //Assert
            int actualHP = attackedWarrior.HP;
            Assert.AreEqual(expectedWarriorHP, actualHP);
        }
    }
}