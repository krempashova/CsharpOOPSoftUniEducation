using FrontDeskApp;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BookigApp.Tests
{
    public class Tests
    {
       
     
        
    
        [SetUp]
        public void Setup()
        {
            
        }
       

        [Test]
        public void ConcstructorWorksProperly()
        {
            Hotel hotel = new Hotel("Mariot", 5);
            
            Assert.AreEqual(5,hotel.Category);
            Assert.AreEqual("Mariot",hotel.FullName);
            Assert.AreEqual(0, hotel.Turnover);
            Assert.AreEqual(0, hotel.Rooms.Count);
           
        }
        [TestCase(null)]
        [TestCase("")]

        public void Test_InvalidFullName(string name)
        {
            Hotel hotel;
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel(name, 5));

        }

        [TestCase(0)]
        [TestCase(6)]
       

        public void Invalid_Category(int category)
        {
            Hotel hotel;
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("mariot", category));

        }
        [TestCase(0)]
        [TestCase(-5)]
        public void AddingRoom_InvalidbadCapacity(int bedCapacity)
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room;
            Assert.Throws<ArgumentException>(() => new Room(bedCapacity, 200));
        }
        [Test]
        public void Test_addingROOMSucsesseful()
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);
            Assert.AreEqual(0, hotel.Rooms.Count);
            hotel.AddRoom(room);
            Assert.AreEqual(1, hotel.Rooms.Count);
            hotel.AddRoom(room1);
            Assert.AreEqual(2, hotel.Rooms.Count);

        }
        [TestCase(0)]
        [TestCase(-5)]
        public void InvalidBookingAdult(int adults)
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 4, 3, 2000));

        }
        [TestCase(-1)]
        [TestCase(-5)]
        public void InvalidBookingChildren(int children)
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(4, children, 3, 2000));

        }
        [TestCase(0)]
        [TestCase(-5)]
        public void InvalidBookingResidence(int residenceDuration)
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(4,2, residenceDuration, 2000));

        }

        [Test]

        public void AddingRooms()
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);
            Assert.AreEqual(0, hotel.Rooms.Count);
            hotel.AddRoom(room);
            hotel.AddRoom(room1);
            Assert.AreEqual(2, hotel.Rooms.Count);

        }
        [TestCase(0)]
        [TestCase(-5)]
        public void InvalidpricePerNight( int pricePerNight)
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room;
           
            Assert.Throws<ArgumentException>(() => new Room(4, pricePerNight));
        }
        [Test]
        public void Test_AddingCorectly()
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);
            hotel.AddRoom(room);
            var expectingresult = room.PricePerNight;
            Room addedromm = hotel.Rooms.FirstOrDefault(r => r.PricePerNight == 200);
            Assert.IsNotNull(addedromm);
            Assert.AreEqual(200, addedromm.PricePerNight);
          Assert.AreEqual(1, hotel.Rooms.Count);



        }
        [Test]
        public void Booking_Test()
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);
            hotel.AddRoom(room);
          
            hotel.BookRoom(2, 2, 3, 2000);
            Assert.AreEqual(1, hotel.Bookings.Count);


        }
        [Test]
        public void Booking_Test2()
        {
            Hotel hotel = new Hotel("mariot", 5);
            Room room = new Room(4, 200);
            Room room1 = new Room(6, 300);
            hotel.AddRoom(room);
            hotel.BookRoom(2, 2, 5, 5000);
            //bednneded=4
            // this.turnover += residenceDuration * room.PricePerNight;
            Assert.AreEqual(1000, hotel.Turnover);


        }


    }
}