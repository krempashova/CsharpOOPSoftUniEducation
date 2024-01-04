using NUnit.Framework;
using System;
using System.Numerics;
using System.Reflection;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Constructor_Smartphone_Testing()
        {
            Shop shop = new Shop(20);
            Smartphone smartphone = new Smartphone("nokia", 100);
            Assert.AreEqual("nokia", smartphone.ModelName);
            Assert.AreEqual(100, smartphone.MaximumBatteryCharge);
            Assert.AreEqual(100, smartphone.CurrentBateryCharge);
        }

        [TestCase(-2)]
        public void ShouldTrhow_CapacityISZERO(int capacity)
        {
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(capacity), $"Invalid capacity.");
        }
        [Test]
        public void Testing_Capacity()
        {
            Shop shop = new Shop(10);
            Assert.AreEqual(10, shop.Capacity);
        }
        [Test]
        public void Trhows_phoneISexist()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("samsung", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            //Assert.AreEqual(1, shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone), $"The phone model nokia already exist.");

        }
        [Test]
        public void Throws_sHOPiSfULL()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("samsung", 100);
            Shop shop = new Shop(1);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone1), $"The shop is full.");
        }
        [Test]
        public void Addingpropwrly()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("samsung", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.Add(smartphone1);
            Assert.AreEqual(2, shop.Count);
        }
        [Test]
        public void Throw_PhoneNotExist()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("samsung", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("samsung"), $"The phone model samsung doesn't exist.");

        }
        [Test]
        public void RemovedProperly()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("Iphone", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.Add(smartphone1);
            Assert.AreEqual(2, shop.Count);
            shop.Remove("Iphone");
            Assert.AreEqual(1, shop.Count);
            Assert.AreEqual("nokia", smartphone.ModelName);

        }
        [Test]
        public void TestingPhoneWhenISNULL()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("Iphone", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone", 100), "The phone model Iphone doesn't exist.");

        }
        [Test]
        public void TestingPhone_ISlOWoNBatery()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("Iphone", 80);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.Add(smartphone1);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Iphone", 100), $"The phone model Iphone is low on batery.");

        }
        [Test]
        public void TestingPhoneWorksProperly()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("Iphone", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.Add(smartphone1);
            shop.TestPhone("nokia", 20);
            Assert.AreEqual(80, smartphone.CurrentBateryCharge);
            shop.TestPhone("Iphone", 50);
            Assert.AreEqual(50, smartphone1.CurrentBateryCharge);

        }
        [Test]
        public void ChargingPhone_missing()
        {
            Smartphone smartphone = new Smartphone("nokia", 100);
            Smartphone smartphone1 = new Smartphone("Iphone", 100);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Iphone"), $"The phone model Iphone doesn't exist.");
        }
        [Test]
        public void ChargingPhoneProperly()
        {
            Smartphone smartphone = new Smartphone("nokia", 80);
            Smartphone smartphone1 = new Smartphone("Iphone", 50);
            Shop shop = new Shop(10);
            shop.Add(smartphone);
            shop.ChargePhone("nokia");
            Assert.AreEqual(80, smartphone.CurrentBateryCharge);
            shop.Add(smartphone1);
            shop.ChargePhone("Iphone");
            Assert.AreEqual(50, smartphone1.CurrentBateryCharge);
        }

    }
}