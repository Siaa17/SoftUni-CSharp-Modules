using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
            this.computer = new Computer("Lenovo", "ThinkPad", 999);
        }

        [Test]
        public void Ctor_InitializesCollectionOfComputersCorrectly()
        {
            Assert.That(this.computerManager, Is.Not.Null);
        }

        [Test]
        public void Prop_ReturnsCollectionAsReadOnly()
        {
            Assert.That(this.computerManager.Computers, Is.InstanceOf<IReadOnlyCollection<Computer>>());
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerIsNull()
        {
            Computer computer = null;

            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerIsAlreadyExists()
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_AddsComputer_WhenAddIsValidOperation()
        {
            this.computerManager.AddComputer(this.computer);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.computerManager.Count);
        }

        [Test]
        [TestCase(null, null)]
        public void RemoveComputer_ThrowsException_WhenManufacturerAndModelAreNull(string manufacturer, string model)
        {
            this.computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputer_RemovesComputer_WhenRemoveIsValidOperation()
        {
            this.computerManager.AddComputer(this.computer);

            var expectedResult = this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(this.computer, Is.SameAs(expectedResult));
        }

        [Test]
        [TestCase(null, null)]
        public void GetComputer_ThrowsException_WhenManufacturerAndModelAreNull(string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(manufacturer, model));
        }

        [Test]
        public void GetComputer_ThrowsException_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("HP", "ProBook"));
        }

        [Test]
        public void GetComputer_ReturnsComputer_WhenGetComputerIsValidOperation()
        {
            this.computerManager.AddComputer(this.computer);

            var expectetResult = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(this.computer, Is.EqualTo(expectetResult));
        }        

        [Test]
        public void GetComputersByManufacturer_ThrowsException_WhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsComputers_WhenIsValidOperation()
        {
            this.computerManager.AddComputer(this.computer);
            this.computerManager.AddComputer(new Computer("HP", "ProBook", 1005));

            var actualResult = this.computerManager.GetComputersByManufacturer("HP");

            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}
