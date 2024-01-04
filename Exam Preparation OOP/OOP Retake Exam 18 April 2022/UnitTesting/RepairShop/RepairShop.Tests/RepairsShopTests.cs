using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;

namespace RepairShop.Tests
{
    public class Tests
    {
        [TestFixture]
        public class RepairsShopTests
        {



            [Test]
            public void Constructor_Test()
            {
                Garage garage = new Garage("race", 10);
                Car car = new Car("toyota", 2);
                Assert.AreEqual("race", garage.Name);
                Assert.AreEqual(10, garage.MechanicsAvailable);
                Assert.AreEqual("toyota", car.CarModel);
                Assert.AreEqual(2, car.NumberOfIssues);

            }
            [Test]
            public void AddingcartoCollectionOfCars()
            {
                Car car = new Car("TOYOTA", 2);
                Car car1 = new Car("MERCEDES", 1);
                Garage garage = new Garage("race", 10);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [TestCase(null)]
            [TestCase("")]
            public void TestgarageNamewhenISnULLOReMPRY(string name)
            {
                Garage garage;
                Assert.Throws<ArgumentNullException>(() => new Garage(name, 10), "Invalid garage name.");
            }
            [TestCase(0)]
            [TestCase(-5)]
            public void ThrowwhenMehanicsAreNotAvailable(int mechanicsAvailable)
            {
                Garage garage;
                Assert.Throws<ArgumentException>(() => new Garage("RACE", mechanicsAvailable), $"At least one mechanic must work in the garage.");
            }
            [Test]
            public void ThrowsWhenTrereIsNomoreAvailableMechanicals()
            {
                Garage garage = new Garage("RACE", 2);
                Car car = new Car("TOYOTA", 1);
                Car car1 = new Car("bmw", 5);
                Car car2 = new Car("TESLA", 1);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car2), "No mechanic available.");
                Assert.AreEqual(2, garage.CarsInGarage);
            }
            [Test]
            public void FixCaR_Testing()
            {
                Garage garage = new Garage("RACE", 20);
                Car car = new Car("toyota", 5);
                Car car1 = new Car("CAR2", 5);
                Car car2 = new Car("car 3", 5);
                garage.AddCar(car);
                garage.AddCar(car1);
                Car cartofix = garage.FixCar("toyota");
                Assert.AreEqual(0, cartofix.NumberOfIssues);

            }
            [Test]
            public void FixCarWhenIsnoSuchOne()
            {
                Garage garage = new Garage("RACE", 20);
                Car car = new Car("toyota", 5);
                Car car1 = new Car("CAR2", 5);
                Car car2 = new Car("car 3", 5);
                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(()=>garage.FixCar("CAR2"), $"The car {"CAR2"} doesn't exist.");


            }
            [Test]
            public void RemoveworksGood()
            {
                Garage garage = new Garage("RACE", 20);
                Car car = new Car("toyota", 5);
                Car car1 = new Car("CAR2", 5);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("toyota");
                garage.RemoveFixedCar();
                Assert.AreEqual(true, car.IsFixed);
            }


            [Test]
            public void ThrowexeptionWhenThereIsnOcarTOremoved()
            {
                Garage garage = new Garage("RACE", 20);
                Car car = new Car("toyota", 5);
                Car car1 = new Car("CAR2", 5);
                garage.AddCar(car);
                garage.AddCar(car1);
                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }
            [Test]
            public void TestingREPORTcar()
            {
                Garage garage = new Garage("RACE", 20);
                Car car = new Car("toyota", 5);
                Car car1 = new Car("CAR2", 5);
                garage.AddCar(car);
                garage.AddCar(car1);
                garage.FixCar("toyota");
                garage.RemoveFixedCar();
                var expectedreport = $"There are 1 which are not fixed: {"CAR2"}.";
                Assert.AreEqual(expectedreport, garage.Report());

            }

        }
    }
}