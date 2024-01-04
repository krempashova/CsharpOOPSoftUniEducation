namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;
    using System.Xml.Linq;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void SetUp()
        {
           warrior = new Warrior("VENOM", 50, 100);

        }
        [TearDown]
        public void TearDown() 
        {

            warrior = null;
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]

        public void ShouldThrowWhenNameisNullOrWhitespace(string name)
        {
            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => new Warrior(name, 50, 100));
            Assert.That(exeption.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void ShouldThowDamageISZeroOrNegative(int damage)
        {
            ArgumentException exeption = Assert
              .Throws<ArgumentException>(() => new Warrior("venom", damage, 100));
            Assert.That(exeption.Message, Is.EqualTo("Damage value should be positive!"));
        }
        [Test]
       
        [TestCase(-5)]
        public void ShouldThowHPISNegative(int hp)
        {
            ArgumentException exeption = Assert
              .Throws<ArgumentException>(() => new Warrior("venom", 50, hp));
            Assert.That(exeption.Message, Is.EqualTo("HP should not be negative!"));
        }
        [Test]
        public void Constructor()
        {
           
            Assert.AreEqual("VENOM", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
            
        }
        [Test]
        public void ShouldThrowWhenHPattackerIsLessthen30()
        {
            var attaker = new Warrior("VENOM", 50, 20);

            InvalidOperationException exeption = Assert
              .Throws<InvalidOperationException>(() => attaker.Attack(warrior));
            Assert.That(exeption.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }
        [Test]
        public void ShouldThrowWhenHPadefenderIsLessthen30()
        {
            var defender = new Warrior("VENOM", 50, 20);

            InvalidOperationException exeption = Assert
               .Throws<InvalidOperationException>(() => warrior.Attack(defender));
            Assert.That(exeption.Message, Is.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }
        [Test]
        public void AttackShouldThrowIfEnemyIsStronger()
        {
            warrior = new Warrior("VENOM", 50, 32);
            var defender = new Warrior("VENOM", 70, 35);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => warrior.Attack(defender));
            Assert.That(exeption.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
        [Test]
        public void SucssesAttack()
        {
            var defender = new Warrior("VENOM", 15, 35);

            warrior.Attack(defender);

            Assert.AreEqual(85, warrior.HP);
            Assert.AreEqual(0, defender.HP);
        }
    }
}