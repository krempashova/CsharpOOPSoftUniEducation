using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace FootballTeam.Tests
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CorectlyCfreatedFoorballTeam()
        {
            FootballTeam team = new FootballTeam("Barcelona", 21);
            Assert.IsNotNull(team);
            Assert.AreEqual("Barcelona", team.Name);
            Assert.AreEqual(21, team.Capacity);

            Type te = team.Players.GetType();
            Assert.AreEqual(te, typeof(List<FootballPlayer>));
        }
        [Test]
       public void ShpildTrhowExeptionWhenNameisInvalid()
        {
            FootballTeam footballTeam;
            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("", 15));
        }
        [Test]
        public void ThrowWhen_CapacityIsInvalid()
        {
            FootballTeam footballTeam;

            Assert.Throws<ArgumentException>(() => footballTeam = new FootballTeam("Barcelona", 13));
        }

  
        [TestCase(null)]
        [TestCase("")]
        

        public void InvalidPlayers(string name)
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(()=> player = new FootballPlayer(name, 2, "Goalkeeper"));


        }
        [TestCase(0)]
        [TestCase(24)]
        public void InvalidPlayerNumber(int playerNumber)
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer("Messi", playerNumber, "Goalkeeper"));
        }
        [Test]
        public void invalidPosition()
        {
            FootballPlayer player;
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer("Ronaldo", 5, "govnio"));
        }
        [Test]
        public void CreateingValidPlayer()
        {

            FootballPlayer player = new FootballPlayer("Mbape", 15, "Midfielder");
            FootballTeam team = new FootballTeam("PSJ", 20);
            var actualOutput = team.AddNewPlayer(player);
            var expectedOutput = "Added player Mbape in position Midfielder with number 15";
            Assert.AreEqual(expectedOutput, actualOutput);

        }
        [Test]
        public void AddPlayerinFullCapacity()
        {
            FootballTeam team = new FootballTeam("CSKA", 16);
            FootballPlayer player = new FootballPlayer("Jekov", 1, "Goalkeeper");
            FootballPlayer player1 = new FootballPlayer("Mihov", 2, "Goalkeeper");
            FootballPlayer player2 = new FootballPlayer("Govnio", 3, "Goalkeeper");
            FootballPlayer player3 = new FootballPlayer("Tapak", 4, "Goalkeeper");
            FootballPlayer player4 = new FootballPlayer("Oligofren", 5, "Goalkeeper");
            FootballPlayer player5 = new FootballPlayer("maloumnik", 6, "Goalkeeper");
            FootballPlayer player6 = new FootballPlayer("slaboumen", 7, "Midfielder");
            FootballPlayer player7 = new FootballPlayer("blabla", 8, "Midfielder");
            FootballPlayer player8 = new FootballPlayer("kraa", 9, "Forward");
            FootballPlayer player9 = new FootballPlayer("dra", 10, "Midfielder");
            FootballPlayer player10= new FootballPlayer("fra", 11, "Forward");
            FootballPlayer player11 = new FootballPlayer("drun", 12, "Midfielder");
            FootballPlayer player12= new FootballPlayer("kuku", 13, "Forward");
            FootballPlayer player13= new FootballPlayer("messi", 14, "Midfielder");
            FootballPlayer player14 = new FootballPlayer("kofti", 15, "Forward");
            FootballPlayer player15 = new FootballPlayer("neimar", 16, "Forward");
            FootballPlayer player16 = new FootballPlayer("ronaldo", 17, "Forward");

            team.AddNewPlayer(player);
            team.AddNewPlayer(player1);
            team.AddNewPlayer(player2);
            team.AddNewPlayer(player3);
            team.AddNewPlayer(player4);
            team.AddNewPlayer(player5);
            team.AddNewPlayer(player6);
            team.AddNewPlayer(player7);
            team.AddNewPlayer(player8);
            team.AddNewPlayer(player9);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player10);
            team.AddNewPlayer(player11);
            team.AddNewPlayer(player12);
            team.AddNewPlayer(player13);
            team.AddNewPlayer(player14);
            var actualresult = team.AddNewPlayer(player15);
            var expectedresult= "No more positions available!";
            Assert.AreEqual(expectedresult, actualresult);


            
            



        }
        [Test]
        public void PickPlayervalidname()
        {
            FootballPlayer player = new FootballPlayer("messi", 8, "Forward");
            FootballPlayer player2 = new FootballPlayer("Ronalso", 8, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 20);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);

            var expectedPlayer = team.PickPlayer("messi");


            Assert.AreSame(expectedPlayer, player);
        }
        [Test]
        public void PlayerScorevalid()
        {
            FootballPlayer player = new FootballPlayer("messi", 8, "Forward");
            FootballPlayer player2 = new FootballPlayer("Ronalso", 12, "Forward");
            FootballTeam team = new FootballTeam("Chocago Fire", 20);
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            var actualresult = team.PlayerScore(12);
            var expectedresuylt= "Ronalso scored and now has 1 for this season!";
            Assert.AreEqual(expectedresuylt, actualresult);
        }
    }
}