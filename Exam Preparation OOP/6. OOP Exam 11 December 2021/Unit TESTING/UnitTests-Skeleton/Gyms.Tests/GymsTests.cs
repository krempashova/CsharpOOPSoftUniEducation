using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {

        [Test]
        public void Constuctor_Test()
        {
            Athlete athlete = new Athlete("kremena");
            Gym gym = new Gym("Pulse", 5);
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
            Assert.AreEqual("kremena", athlete.FullName);
            Assert.AreEqual("Pulse", gym.Name);
            Assert.AreEqual(5, gym.Capacity);
         
        }
        [TestCase(null)]
        [TestCase("")]
        public void NameGYMisinvalid(string name)
        {
            Gym gym ;
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 5), $"{name} Invalid gym name.");
           
        }
        [TestCase(-5)]
        [TestCase(-16)]
        public void CapacityISiNVALID(int size)
        {
            Gym gym;
            Assert.Throws<ArgumentException>(() => new Gym("JK", size), $"Invalid gym capacity.");
        }
        [TestCase(10)]
        public void SetsPROPERLYCAPACITY(int size)
        {
            Gym gym = new Gym("Pulse", size);
            Assert.AreEqual(10, gym.Capacity);
        }
        [Test]
        public void AddingNOcAPACITY()
        {
            Gym gym = new Gym("JK", 2);
            Athlete athlete = new Athlete("kremena");
            Athlete athlete1 = new Athlete("monster");
            Athlete athlete2 = new Athlete("debelak");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);


            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete2), $"The gym is full.");

        }
        [Test]
        public void AddingAthlete()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            Athlete athlete1 = new Athlete("monster");
            Athlete athlete2 = new Athlete("debelak");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);

            Assert.AreEqual(3, gym.Count);
            Assert.AreEqual("kremena", athlete.FullName);
            Assert.AreEqual("monster", athlete1.FullName);
            Assert.AreEqual("debelak", athlete2.FullName);

        }
        [Test]
        public void REMOVE_nameisnotexist()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            Athlete athlete1 = new Athlete("monster");
            Athlete athlete2 = new Athlete("debelak");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("debelak"), $"The athlete debelak doesn't exist.");

        }
        [Test]
        public void Remove_Test()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            Athlete athlete1 = new Athlete("monster");
            Athlete athlete2 = new Athlete("debelak");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            Assert.AreEqual(3, gym.Count);
            gym.RemoveAthlete("kremena");
            Assert.AreEqual(2, gym.Count);
            Assert.AreEqual("monster", athlete1.FullName);
            Assert.AreEqual("debelak", athlete2.FullName);
            
            
            
        }
        [Test]
        public void Test_AdjuredIsFalse()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            gym.AddAthlete(athlete);

            Assert.AreEqual(false, athlete.IsInjured);
        }
        [Test]
        public void Thows_TESTiNJURED()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            gym.AddAthlete(athlete);
            gym.InjureAthlete("kremena");
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("monster"), $"The athlete monster doesn't exist.");
            Assert.AreEqual(true, athlete.IsInjured);
        }
        [Test]
        public void Report_Tets()
        {
            //string athleteNames = string.Join(", ", this.athletes.Where(x => !x.IsInjured).Select(f => f.FullName));
            //string report = $"Active athletes at {this.Name}: {athleteNames}";
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            Athlete athlete1 = new Athlete("monster");
            Athlete athlete2 = new Athlete("debelak");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
            gym.InjureAthlete("kremena");
            gym.InjureAthlete("monster");
            gym.Report();
            var expectedresult = $"Active athletes at JK: debelak";
            Assert.AreEqual(expectedresult, gym.Report());
           
                
        }
        [Test]
        public void IsAjuredReturnsameAthelete()
        {
            Gym gym = new Gym("JK", 10);
            Athlete athlete = new Athlete("kremena");
            gym.AddAthlete(athlete);
            Assert.AreEqual(athlete, gym.InjureAthlete("kremena"));

        }
    }
}
