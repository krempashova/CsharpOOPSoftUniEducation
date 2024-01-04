using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private int health;
        private int experience;
        private Dummy dummy;
        private Dummy deadDummy;
        [SetUp]
        public void Setup()
        {
            health = 10;

            experience = 20;
             dummy = new Dummy(health, experience);
            deadDummy = new Dummy(health, experience);
            deadDummy.TakeAttack(health + 20);

        }
        [Test]
        public void Test_DummyConstructorSetsDataVALUEProperly()
        {
            Assert.AreEqual(health, dummy.Health);
           
        }
    
    [Test]
    public void Test_DummyLoosesHealthWhenAttacked()
    {
        dummy.TakeAttack(5);
        Assert.AreEqual(health - 5, dummy.Health);
    }

    [Test]
    public void Test_DummyShouldThrowExceptionWhenAttackedAndHealthIsZero()
    {
        dummy.TakeAttack(health);

        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.TakeAttack(1);
        });
    }

    [Test]
    public void Test_DummyShouldThrowExceptionWhenAttackedAndHealthBelowZero()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            deadDummy.TakeAttack(1);
        });
    }

    [Test]
    public void Test_DummyShouldGiveExperienceWhenIsDead()
    {
        var dummyExperience = deadDummy.GiveExperience();

        Assert.AreEqual(experience, dummyExperience);
    }

    [Test]
    public void Test_DummyGiveExperienceShouldThrowException_WhenDummyIsAlive()
    {
        Assert.Throws<InvalidOperationException>(() =>
        {
            dummy.GiveExperience();
        });
    }
}

}  


