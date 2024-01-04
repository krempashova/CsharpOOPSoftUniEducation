namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp() 
        {

            arena = new Arena();
        }
        [TearDown]
        public void TearDown() 
        
        {
            arena = null;        
        }

        [Test]
        public void AddWariorrsToListProperly()
        {
            arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }
        [Test]
        public void EnrollShouldAddWarrior()
        {
            arena.Enroll(new Warrior("Venom", 5, 12));

            Assert.AreEqual(1, arena.Count);
        }
        [Test]
        public void EnrollShouldThrowIfWarriorNameIsNotUnique()
        {
            arena.Enroll(new Warrior("Venom", 5, 12));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Venom", 5, 12)));
            Assert.That(exeption.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }
        [Test]
        public void FightShouldThrowIfDefenderIsMissing()
        {
            arena.Enroll(new Warrior("Venom", 5, 12));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("Venom", "RedVenom"));
            Assert.That(exeption.Message, Is.EqualTo("There is no fighter with name RedVenom enrolled for the fights!"));
        }
        [Test]
        public void FightShouldThrowIfAttackerIsMissing()
        {
            arena.Enroll(new Warrior("Venom", 5, 12));

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => arena.Fight("RedVenom", "Venom"));
            Assert.That(exeption.Message, Is.EqualTo("There is no fighter with name RedVenom enrolled for the fights!"));
        }
        [Test]
        public void TestingFigth()
        {
            var attacker = new Warrior("Venom", 15, 35);
            var defender = new Warrior("RedVenom", 15, 45);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(20, attacker.HP);
            Assert.AreEqual(30, defender.HP);
        }

    }
}
