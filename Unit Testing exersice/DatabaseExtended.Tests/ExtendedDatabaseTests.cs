namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
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
        public void AddPropetrlyPERSON()
        {
            database.Add(new Person(5, "Dimitrichko"));
            var result = database.FindById(5);
            Assert.AreEqual(1, database.Count);
            Assert.AreEqual(5, result.Id);
            Assert.AreEqual("Dimitrichko", result.UserName);

        }
        [Test]
        public void ShouldTrhowsExeptionsIfAddmore()
        {
            Person[] people = CreateFullArray();
            database = new Database(people);

            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(17, "Pesho")));
            Assert.That(exeption.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        private Person[] CreateFullArray()
        {
            Person[] persons = new Person[16];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, i.ToString());
            }

            return persons;
        }
        [Test]
        public void SholdTrhowExeptionWhenAlredyhaveID()
        {
            database = new Database(new Person(5, "Dimitrichko"));
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(5, "Gosho")));
            Assert.That(exeption.Message, Is.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void SholdTrhowExeptionWhenAlredyhaveSameUserNAME()
        {
            database = new Database(new Person(5, "Dimitrichko"));
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.Add(new Person(1, "Dimitrichko")));
            Assert.That(exeption.Message, Is.EqualTo("There is already user with this username!"));
        }
        [Test]
        public void Createdelemensts()
        {
            database = new Database(new Person(3, "Shosho"), new Person(9, "Gosho"));
            Assert.AreEqual(2, database.Count);
            Person fisrtPerson = database.FindById(3);
            Person secondPerson = database.FindById(9);
            Assert.AreEqual(3, fisrtPerson.Id);
            Assert.AreEqual(9, secondPerson.Id);
        }
        [Test]
        public void TryingToRemoveFromEmptyDaTA()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void RemoveFromDatabase()
        {
            database = new Database(new Person(3, "Shosho"), new Person(9, "Gosho"));
            database.Remove();
            Person first = database.FindById(3);

            Assert.AreEqual(1, database.Count);
            Assert.AreEqual("Shosho", first.UserName);
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
            Assert.That(exeption.Message, Is.EqualTo("No user is present by this username!"));
        }
        [Test]
        public void FindByUsernameShouldThrowIfUsernameNullOrEmpty()
        {
            ArgumentNullException exeption = Assert
                .Throws<ArgumentNullException>(() => database.FindByUsername(null));
            Assert.That(exeption.ParamName, Is.EqualTo("Username parameter is null!"));

            ArgumentNullException emptyEx = Assert
                .Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
            Assert.That(emptyEx.ParamName, Is.EqualTo("Username parameter is null!"));
        }
        [Test]
        public void FindByUsernameShouldThrowIfUsernameDoesNotExist()
        {
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
            Assert.That(exeption.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsernameReturnsCorrectUser()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindByUsername("Gosho");

            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }

        [Test]
        public void FindByIdShouldThrowIfIdIsLessThan0()
        {
            ArgumentOutOfRangeException exeption = Assert
                .Throws<ArgumentOutOfRangeException>(() => database.FindById(-2));
            Assert.That(exeption.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdShouldThrowIfIdDoesNotExist()
        {
            InvalidOperationException exeption = Assert
                .Throws<InvalidOperationException>(() => database.FindById(8));
            Assert.That(exeption.Message, Is.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void FindByIdReturnsCorrectUser()
        {
            database = new Database(new Person(1, "Pesho"), new Person(2, "Gosho"));
            Person person = database.FindById(2);

            Assert.AreEqual("Gosho", person.UserName);
            Assert.AreEqual(2, person.Id);
        }


    }
}