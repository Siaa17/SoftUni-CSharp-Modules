using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    [TestFixture]
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver unitDriver;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitDriver = new UnitDriver("Biana", new UnitCar("Tesla", 550, 80.0));
        }

        [Test]
        public void Ctor_InitializesCollectionCorrectly()
        {
            Assert.IsNotNull(this.raceEntry);
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsAlreadyExists()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(unitDriver));
        }

        [Test]
        public void AddDriver_AddsDriver_WhenAddIsValidOperation()
        {
            this.raceEntry.AddDriver(unitDriver);
            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.raceEntry.Counter);
        }

        [Test]
        public void AddDriver_ReturnsMessage_WhenAddIsValidOperation()
        {
            string expectedResult = $"Driver {this.unitDriver.Name} added in race.";

            Assert.That(this.raceEntry.AddDriver(unitDriver), Is.EqualTo(expectedResult));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenParticipantsAreLessThanMinimum()
        {
            this.raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsAverageHorsePower_WhenCalculateIsValidOperation()
        {
            UnitDriver unitDriverTwo = new UnitDriver("Vesi", new UnitCar("Tesla", 550, 80.0));

            this.raceEntry.AddDriver(unitDriver);
            this.raceEntry.AddDriver(unitDriverTwo);

            double expectedAverageResult = 550;

            Assert.AreEqual(expectedAverageResult, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}
