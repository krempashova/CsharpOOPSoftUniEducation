namespace CarManager.Tests
{
    using NUnit.Framework;
    using NUnit.Framework.Internal;
    using System;
    using System.Diagnostics.Contracts;
    using System.Reflection.PortableExecutable;
    using System.Xml.Serialization;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car
            ;
        [SetUp]
        public void SetUp()
        {
            car = new Car("BMW", "X5", 5, 25);
        }
        [TearDown]
        public void TearDown()
        {
            car = null;
        }
        [Test]
        public void CreatedCar()
        {

            car = new Car("BMW", "X5", 5, 25);
            Assert.AreEqual("X5", car.Model);
            Assert.AreEqual(5, car.FuelConsumption);
            Assert.AreEqual(25, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ShouldTrhrowexeptionWhenMakeIsNullOrEmpty(string make)
        {
            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => new Car(make, "X5", 5, 45));
            Assert.That(exeption.Message, Is.EqualTo("Make cannot be null or empty!"));
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ShouldTrhrowexeptionWhenModelisNullOrEmpty(string model)
        {
            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => new Car("BMW", model, 5, 25));
            Assert.That(exeption.Message, Is.EqualTo("Model cannot be null or empty!"));
        }
        [Test]
        public void ShouldTrhowExeptionWhenFuelConsumptionIsNegative()
        {
            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => new Car("BMW", "x5", -8, 45));
            Assert.That(exeption.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
        }
        [Test]
        
        public void ShouldTrhowExeptionWhenFuelCapacityIslessThenZero()
        {
            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => new Car("BMW", "x5",5, -5));
            Assert.That(exeption.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-8)]
        public void ShouldTrhrowWhenFuelToRefuleIsNegativeOrZero(double fuelToRefuel)
        {

            ArgumentException exeption = Assert
               .Throws<ArgumentException>(() => car.Refuel(fuelToRefuel));
            Assert.That(exeption.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void CorectedRefuel()
        {
            car = new Car("BMW", "X5", 5, 25);
            car.Refuel(5);
            Assert.AreEqual(5, car.FuelAmount);
        }
        [Test]
        public void CorectedRefuelIfAmountmoreThenCapacity()
        {
            car = new Car("BMW", "X5", 5, 25);
            car.Refuel(30);
            Assert.AreEqual(25, car.FuelAmount);
        }
        [Test]
        public void ShouldThrowFuelNeddedIslessThanFuelAmount()
        {
            InvalidOperationException exeption = Assert
              .Throws<InvalidOperationException>(() => car.Drive(1));
            Assert.That(exeption.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }

        [Test]
        public void DriveShouldLeaveFuel()
        {
            car.Refuel(10);
            car.Drive(100);

            Assert.AreEqual(5, car.FuelAmount);
        }
    }
}