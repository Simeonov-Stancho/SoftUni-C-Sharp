using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(100, 100, 20, 80)]
    public void HealthShoulsDecreaseIfAttacked(int health, int experience,
                                          int attackPoints, int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act
        dummy.TakeAttack(attackPoints);

        //Assert
        int actualResult = dummy.Health;
        Assert.AreEqual(actualResult, expectedResult);
    }

    [TestCase(0, 100, 20)]
    public void ThrowExceptionIfDummyIsDeadAndBeenAttacked(int health, int experience,
                                          int attackPoints)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act -- Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(attackPoints));
    }

    [TestCase(0, 100, 100)]
    public void ThrowExceptionIfDummyIsDeadAndTryToGiveExp(int health, int experience, 
                                                            int expectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act 
        int actualResult = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(actualResult, expectedResult);
    }

    [TestCase(5, 100)]
    public void ThrowExceptionIfDummyIsAliveAndTryToGiveExp(int health, int experience)
    {
        //Arrange
        Dummy dummy = new Dummy(health, experience);

        //Act -- Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
