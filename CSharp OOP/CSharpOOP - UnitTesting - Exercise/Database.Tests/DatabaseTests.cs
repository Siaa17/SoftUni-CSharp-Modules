using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private Database databse;

        [SetUp]
        public void Setup()
        {
            this.databse = new Database();
        }

        [Test]
        public void Ctor_ThrowsException_WhenDatabaseCountIsExseeded()
        {
            Assert.Throws<InvalidOperationException>(() => this.databse = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddsElementsToDataBase()
        {
            int[] elements = new[] { 8, 13, 26 };

            this.databse = new Database(elements);

            Assert.That(this.databse.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void Add_ThrowsException_WhenDatabaseCountIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.databse.Add(i);
            }

            Assert.That(() => this.databse.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Add_IncreaseDatabaseCount_WhenAddIsValidOperation()
        {
            int n = 6;

            for (int i = 0; i < n; i++)
            {
                this.databse.Add(i);
            }

            Assert.That(this.databse.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_AddsElementToDatabase()
        {
            int element = 17;

            this.databse.Add(element);

            int[] elements = this.databse.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.That(() => this.databse.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void Remove_DecreaseDatabaseCount_WhenRemoveIsValidOperation()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                this.databse.Add(i);
            }

            this.databse.Remove();

            Assert.That(this.databse.Count, Is.EqualTo(n - 1));
        }

        [Test]
        public void Remove_RemoveElementFromDatabase()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                this.databse.Add(i);
            }

            this.databse.Remove();

            int[] elements = this.databse.Fetch();

            elements.TakeLast(n);

            Assert.IsFalse(elements.Contains(n));
        }

        [Test]
        public void Fetch_ReturnsDatabaseCopyInsteadOfReference()
        {
            this.databse.Add(3);
            this.databse.Add(7);

            int[] firstCopy = this.databse.Fetch();

            this.databse.Add(12);

            int[] secondCopy = this.databse.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }

        [Test]
        public void Count_ReturnsZero_WhenDatabaseIsEmpty()
        {
            Assert.That(this.databse.Count, Is.EqualTo(0));
        }
    }
}