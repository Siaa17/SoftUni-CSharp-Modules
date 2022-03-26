using System;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase();
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCountIsExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username: {i}");
            }

            Assert.That(() => this.extendedDatabase = new ExtendedDatabase(arguments), Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void Ctor_AddsPeopleToDatabase()
        {
            Person[] people = new Person[6];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, $"Username: {i}");
            }

            this.extendedDatabase = new ExtendedDatabase(people);

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(people.Length));
        }

        [Test]
        public void Add_ThrowsException_WhenDatabaseCountIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username: {i}"));
            }

            Assert.That(() => this.extendedDatabase.Add(new Person(16, "InvalidUsername")), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameIsAlreadyExists()
        {
            string username = "Biana";

            this.extendedDatabase.Add(new Person(1, username));

            Assert.That(() => this.extendedDatabase.Add(new Person(2, username)), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void Add_ThrowsException_WhenIdIsAlreadyExists()
        {
            long id = 951217;

            this.extendedDatabase.Add(new Person(id, "Biana"));

            Assert.That(() => this.extendedDatabase.Add(new Person(id, "Ivan")), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void Add_IncreasesCounter_WhenUserIsValid()
        {
            this.extendedDatabase.Add(new Person(1712, "Biana"));
            this.extendedDatabase.Add(new Person(2311, "Peter"));
            this.extendedDatabase.Add(new Person(3008, "Vesi"));

            int expectedCount = 3;

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            int n = 7;

            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username: {i}"));
            }

            this.extendedDatabase.Remove();

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(n - 1));

            Assert.That(() => this.extendedDatabase.FindById(n - 1), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsException_WhenUsernameIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(username));
        }

        [Test]
        public void FindByUsername_ThrowsException_WhenUsernameDoesNotExist()
        {
            Assert.That(() => this.extendedDatabase.FindByUsername("Bianka"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindByUsername_ReturnsExpectedUser_WhenUserExists()
        {
            Person person = new Person(1995, "Bianka");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindByUsername(person.UserName);

            Assert.AreEqual(dbPerson, person);
        }

        [Test]
        [TestCase(-17)]
        [TestCase(-25)]
        public void FindById_ThrowsException_WhenIdIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(id));
        }

        [Test]
        public void FindById_ThrowsException_WhenUserWithIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(195));
        }

        [Test]
        public void FindById_ReturnsExpectedId_WhenUserExists()
        {
            Person person = new Person(1995, "Bianka");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindById(person.Id);

            Assert.AreEqual(dbPerson, person);
        }         
    }
}