using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(500, 10, 510, 100, 9)]
    [TestCase(500, 1, 510, 100, 0)]
    public void WeaponShouldLoseDurabilityAfterAttack(int attack, int durability,
                                                      int health, int experience,
                                                      int expectedResult)
    {
        //Arange
        Axe testAxe = new Axe(attack, durability);
        Dummy testDummy = new Dummy(health, experience);

        //Act
        testAxe.Attack(testDummy);

        //Assert
        var actualResult = testAxe.DurabilityPoints;
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestCase(10, 0, 10, 10)]
    [TestCase(10, -100, 10, 10)]
    public void AttackShouldThrowInvalidOperationExceptionWhenAttackWithBrokenWeapon
        (int attack, int durability,
         int health, int experience)
    {
        //Arange
        Axe testAxe = new Axe(attack, durability);
        Dummy testDummy = new Dummy(health, experience);

        //Act  -- Assert
        Assert.Throws<InvalidOperationException>(() => testAxe.Attack(testDummy));
    }
}