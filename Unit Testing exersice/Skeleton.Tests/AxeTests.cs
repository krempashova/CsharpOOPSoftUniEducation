using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private int attackPoints;
        private int durabilityPoints;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            attackPoints = 5;
            durabilityPoints = 10;
             axe = new Axe(attackPoints, durabilityPoints);
              dummy = new Dummy(25, 25);

        }
        [Test]
        public void Test_ConstructorAxesetsVALUE()
        {
            Assert.AreEqual(attackPoints,axe.AttackPoints);
            Assert.AreEqual(durabilityPoints,axe.DurabilityPoints);
        }
        [Test]
        public void Test_AxeLoosingDurabilityPoints()
        {
            for (int i = 0; i < 3; i++)
            {
                axe.Attack(dummy);
            }
            Assert.AreEqual(durabilityPoints - 3, axe.DurabilityPoints);
        }
        [Test]
        public void Test_AxeShouldTrhowAnExeptionWhenIs_Zero()
        {
            axe = new Axe(25, 0);

            Assert.Throws<InvalidOperationException>(() =>
                {
                    axe.Attack(dummy);
                });
        }
        [Test]
        public void Test_AxeShouldTrhowAnExeptionWhenIsNegative()
        {
            axe = new Axe(25, -6);

            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);
            });
        }


    }
}