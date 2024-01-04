using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [SetUp] 
            public void SetUp() 
            { 
            
            }
            [Test] 
            public void SetsConstructorPlanetvaluesproperty() 
            
            {
                Planet planet = new Planet("mars", 250);
                Assert.AreEqual("mars", planet.Name);
                Assert.AreEqual(250, planet.Budget);
                
            
            
            }
            [Test]
            public void  ConstructorWeaponSET()
            {
                Weapon weapon = new Weapon("makarov", 500, 5);
                Assert.AreEqual("makarov", weapon.Name);
                Assert.AreEqual(500, weapon.Price);
                Assert.AreEqual(5, weapon.DestructionLevel);
            }
            
            [TestCase(-8)]
            public void Throw_whenWeapoonPriceisnegative(double price)
            {
                Assert.Throws<ArgumentException>(() => new Weapon("makarov", price, 5), "Price cannot be negative.");

            }
            [Test]
            public void IncreaseDictructionLevel()
            {
                Weapon weapon = new Weapon("kaval", 250, 10);
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(11, weapon.DestructionLevel);
            }
            [Test]
            public void IsNuclear()
            {
                var weaponNuclear = new Weapon("Nuclear", 1500, 11);
                var weaponGun = new Weapon("Gun", 20, 2);
                Assert.That(weaponNuclear.IsNuclear, Is.EqualTo(true));
                Assert.That(weaponGun.IsNuclear, Is.EqualTo(false));
            }

            [TestCase(null)]
            
            public void PlanetNamecannotBeNullOrEmpty(string name)
            {
                Assert.Throws<ArgumentException>(() => new Planet(name, 300), "Invalid planet Name");
            }
            [Test]
            public void Throw_BudgetCannotDropBELOWzERO()
            {
                Assert.Throws<ArgumentException>(() => new Planet("blabla", -2), "Budget cannot drop below Zero!");
            }
            [Test]
            public void AddsWepons()
            {
                
                Planet planet = new Planet("MARS", 1000);
                Weapon weapon = new Weapon("weapon", 500, 5);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count); 
            }
            [Test]
            public void SetsMilitaryPOWERatio()
            {
                Planet planet = new Planet("venus", 500);
                Weapon weapon=new Weapon("weapon",200,5);
                Weapon weapon1 = new Weapon("weapon1", 100, 2);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon1);
                var actualresult = planet.MilitaryPowerRatio;
                var expectedresult = 7;
                Assert.AreEqual(expectedresult, actualresult);
            }
            [Test]
            public void ProfitWorksProperly()
            {
                Planet planet = new Planet("venus", 200);
                planet.Profit(100);
                Assert.AreEqual(300, planet.Budget);
            }
            [Test]
            public void SpendFunds_Test()
            {
                Planet planet = new Planet("venus", 200);
                planet.SpendFunds(50);
                Assert.AreEqual(150, planet.Budget);

            }
            [Test]
            public void Throws_SpendFundsIsLess()
            {
                Planet planet = new Planet("venus", 200);
               
                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(300), "Not enough funds to finalize the deal.");

            }
            [Test]
            public void Throw_WhenWeaponAlreadyEXEIST()
            {
                Planet planet = new Planet("VENUS", 500);
                Weapon weapon = new Weapon("weapon", 200, 5);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon), $"There is already a {weapon.Name} weapon.");
            }
            [Test]
            public void RemoveWeapon_Test()
            {
                Planet planet = new Planet("VENUS", 500);
                Weapon weapon = new Weapon("weapon", 200, 5);
                planet.RemoveWeapon(weapon.Name);
                var removedplanet = weapon.Name;
                Assert.AreEqual(0, planet.Weapons.Count);
                var expectedresult = "weapon";
                var actualreslut = removedplanet;
                Assert.AreEqual(expectedresult, actualreslut);
            }
            [Test]
            public void UpgradeWeapon_WhenisnotExist()
            {
                Planet planet = new Planet("VENUS", 500);
                Weapon weapon = new Weapon("weapon", 200, 5);
                planet.AddWeapon(weapon);
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("kaval"), $"kaval does not exist in the weapon repository of {planet.Name}");
            }
            [Test]
            public void UpgradeWeaponsProperly()
            {
                Planet planet = new Planet("VENUS", 500);
                Weapon weapon = new Weapon("weapon", 200, 5);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon(weapon.Name);
              
                Assert.AreEqual(6, weapon.DestructionLevel);
                

            }
            [Test]
            public void Destructoponent_ThrowsExeption()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);
                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 2);
                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);
                Assert.Throws<InvalidOperationException>(() => planetOne.DestructOpponent(planetTwo),
                   $"{planetTwo.Name} is too strong to declare war to!");
            }
            [Test]
            public void DestructOpponent_WorksProperly()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);

                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 4);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);

                var expectedResult = "PlanetTwo is destructed!";

                Assert.That(planetOne.DestructOpponent(planetTwo), Is.EqualTo(expectedResult));
            }
        }
    }
}
