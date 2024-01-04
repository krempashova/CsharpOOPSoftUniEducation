namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq.Expressions;

    [TestFixture]
    public class DatabaseTests
    {

        private Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database();

        }
        [TearDown]
        public void TearDown()
        {
            database = null;
        }

        [Test]
        public void AddedElementProperly()
        {
            database = new Database();
            database.Add(1);
            int[] result = database.Fetch();
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        public void ShouldThrowExeption()
        {
            database = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16);
            InvalidOperationException expetion = Assert.Throws<InvalidOperationException>(() => database.Add(12));
            Assert.That(expetion.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));




        }
        [Test]
        public void CreatedElemt10()

        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10);
            Assert.AreEqual(10, database.Count);

        }
        [Test]
        public void RemoveEmptydata()
        {

            database = new Database();
            InvalidOperationException exeption = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.That(exeption.Message, Is.EqualTo("The collection is empty!"));

        }
        [Test]
        public void RemovedProperly()
        {
            database = new Database(5,6);
           database.Remove();
            var result = database.Fetch();
            Assert.AreEqual(5, result[0]);
            Assert.AreEqual(1,database.Count);
            Assert.AreEqual(1, result.Length);
        }
        [Test]
        public void FetchDataFromDatabase()
        {
            database = new Database(1, 2, 3);
            var result = database.Fetch();

            Assert.That(new int[] { 1, 2, 3 }, Is.EquivalentTo(result));
        }





    }
}
