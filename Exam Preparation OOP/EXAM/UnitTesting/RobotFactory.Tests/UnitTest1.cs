using Microsoft.VisualBasic;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotFactory.Tests;
    
public class Tests
  
    {
       
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_test()
        {
            Robot robot = new Robot("model", 500, 5);
            Assert.AreEqual("model", robot.Model);
            Assert.AreEqual(500, robot.Price);
            Assert.AreEqual(5, robot.InterfaceStandard);
          

        }
        [Test]
        public void ConstructorFactoryTest()
        {
            Factory factory = new Factory("factory", 3);
            Assert.AreEqual("factory", factory.Name);
            Assert.AreEqual(3, factory.Capacity);
        }

        [Test]
        public void AddingRobotsToLIST()
        {
           
            Factory factory = new Factory("factory", 5);
            Robot robot = new Robot("robot", 200, 5);
            Robot robot1 = new Robot("robot1", 300, 6);
            Robot robot2 = new Robot("robot2", 400, 7);
             Assert.AreEqual(0, factory.Robots.Count);

               factory.Robots.Add(robot);
               factory.Robots.Add(robot1);
               factory.Robots.Add(robot2);

              Assert.AreEqual(3, factory.Robots.Count);


        }
        [Test]
        public void ProduseRobot_TEST()
        {
           
            Factory factory = new Factory("factory", 5);
            Robot robot = new Robot("robot", 200, 5);
           
           
            var actualreasult = factory.ProduceRobot("robot", 200, 5);
            var expectedresult= $"Produced --> {robot}";
           
            Assert.AreEqual(expectedresult, actualreasult);
        }
        [Test]
        public void TestWhenCapacityisFull()
        {
         
            Factory factory = new Factory("factory", 2);
            Robot robot = new Robot("robot", 200, 5);
            Robot robot1 = new Robot("robot1", 300, 6);
            Robot robot2 = new Robot("robot2", 400, 7);
            factory.ProduceRobot("robot", 200, 5);
            factory.ProduceRobot("robot1", 300, 6);

            var actualreasult = factory.ProduceRobot("robot2", 400, 7);
            var expectedresult = $"The factory is unable to produce more robots for this production day!";
            Assert.AreEqual(expectedresult, actualreasult);
        }
        [Test]
        public void ProduceSuplaimnet_Test()
        {

        Factory factory = new Factory("SpaceX", 2);

        string actualResult = factory.ProduceSupplement("SpecializedArm", 8);

        string expectedResult = "Supplement: SpecializedArm IS: 8";
        Assert.AreEqual(expectedResult, actualResult);


    }
    [Test]
    public void ProduceSupplement_CheckAdding()
    {
        Factory factory = new Factory("SpaceX", 10);

        int expectedCountBeforeProduce = 0;
        int actualCountBeforeProduce = factory.Supplements.Count;

        factory.ProduceSupplement("SpecializedArm", 8);

        int expectedCountAfterProduce = 1;
        int actualCountAfterProduce = factory.Supplements.Count;

        Assert.AreEqual(expectedCountBeforeProduce, actualCountBeforeProduce);
        Assert.AreEqual(expectedCountAfterProduce, actualCountAfterProduce);

    }
    [Test]
    public void UpgradeRobot_Successful()
    {
        Factory factory = new Factory("SpaceX", 10);

        factory.ProduceRobot("Robo-3", 2500, 22);
        factory.ProduceSupplement("SpecializedArm", 22);

        var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

        Assert.IsTrue(actualResult);

    }


    [Test]
        public void UpgradeRobots_DiferentStandarts()
    {
       
        Factory factory = new Factory("factory", 2);

        Supplement supplement = new Supplement("sup", 5);
     
        Robot robot = new Robot("robot", 200, 7);
        factory.ProduceRobot("robot", 200, 7);
        factory.ProduceSupplement("sup",5);
       

         var expectedresult=factory.UpgradeRobot(robot, supplement);
         var actualfresult = false;
        Assert.AreEqual(expectedresult, actualfresult);


    }
            [Test]
           public void UpgradeTesting()
            {

           
                  Factory factory = new Factory("factory", 2);

                  Supplement supplement = new Supplement("sup", 5);
                
                  Robot robot = new Robot("robot", 200, 5);


                 factory.ProduceSupplement("sup", 5);
                 factory.ProduceRobot("robot", 200, 5);
             
                var expectedresult = factory.UpgradeRobot(robot, supplement);
                var actualfresult = true;
    }

    [Test]
    public void UpgradeTesting_existingsuplaimnet()
    {
        Factory factory = new Factory("factory", 2);

        Supplement supplement = new Supplement("sup", 5);

        Robot robot = new Robot("robot", 200, 5);
            factory.UpgradeRobot(robot, supplement);
        var expectedresult = factory.UpgradeRobot(robot, supplement);
        var actualresult = false;
        Assert.AreEqual(expectedresult, actualresult);
    }
              [Test]
            public void SellRobot()
    {
        Factory factory = new Factory("factory", 5);
        Robot robot = new Robot("robot", 200, 5);
        Robot robot1 = new Robot("robot1", 500, 5);
         Supplement supplement = new Supplement("sup", 5);
        Supplement supplement2 = new Supplement("sup2", 6);
        factory.ProduceRobot("robot", 200, 5);
        factory.ProduceRobot("robot1", 500, 6);
        factory.ProduceSupplement("sup", 5);
        factory.ProduceSupplement("sup2", 6);
        factory.UpgradeRobot(robot, supplement);
        factory.UpgradeRobot(robot1, supplement2);
         factory.SellRobot(499);
        var expected = $"Robot model: robot IS: 5, Price: 200.00";
        var seledrobot = factory.Robots.FirstOrDefault(s => s.Price <= 499);
        var actual = seledrobot.ToString();
        Assert.AreEqual(expected, actual);
       
    }
    [Test]
    public void SellRobot_Successful()
    {
        Factory factory = new Factory("SpaceX", 10);

        factory.ProduceRobot("Robo-3", 2000, 22);
        factory.ProduceRobot("Robo-3", 2500, 22);
        factory.ProduceRobot("Robo-3", 30000, 22);

        Robot robot = factory.Robots.FirstOrDefault(r => r.Price == 2000);

        var robotSold = factory.SellRobot(2499);

        Assert.AreSame(robot, robotSold);

    }
}

