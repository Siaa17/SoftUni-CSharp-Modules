namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            this.aquarium = new Aquarium("SeaWorld", 6);
            this.fish = new Fish("Dori");
        }

        [Test]
        public void Ctor_CheckIfAllArgumentsAreInitializeCorrectly()
        {
            string expectedName = "SeaWorld";
            int expectedCapacity = 6;

            Assert.That(this.aquarium.Name, Is.EqualTo(expectedName));
            Assert.That(this.aquarium.Capacity, Is.EqualTo(expectedCapacity));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void PropertyValidation_ThrowsException_WhenNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, this.aquarium.Capacity));
        }

        [Test]
        public void PropertyValidation_ThrowsException_WhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium(this.aquarium.Name, -3));
        }

        [Test]
        public void Add_AddsFishToAquarium_WhenAddIsValidOperation()
        {
            this.aquarium.Add(fish);
            int expectedCount = 1;

            Assert.That(this.aquarium.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Add_ThrowsException_WhenFishCountIsEqualToCapacity()
        {
            int fishCount = 6;

            for (int i = 0; i < fishCount; i++)
            {
                this.aquarium.Add(fish);
            }

            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(fish));
        }

        [Test]
        public void RemoveFish_RemovesFishFromAquarium_WhenRemoveIsValidOperation()
        {
            this.aquarium.Add(fish);
            this.aquarium.RemoveFish("Dori");

            Assert.That(this.aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveFish_ThrowsException_WhenFishNameDoesNotExists()
        {                     
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Nemo"));
        }

        [Test]
        public void SellFish_SetsAvaliablePropertyToFalse_WhenFishNameIsNotAvaliable()
        {
            this.aquarium.Add(fish);
            this.aquarium.SellFish("Dori");

            Assert.That(this.fish.Available, Is.False);
        }

        [Test]
        public void SellFish_ThrowsException_WhenFishNameDoesNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("GoldenFish"));
        }

        [Test]
        public void SellFish_SellsFishFromAquarium_WhenSellFishIsValidOperation()
        {
            this.aquarium.Add(fish);

            Assert.That(fish, Is.EqualTo(this.aquarium.SellFish("Dori")));
        }

        [Test]
        public void Report_CheckIfReportMethodReturnsMessageCorrectly()
        {
            this.aquarium.Add(fish);
            Fish secondFish = new Fish("Nemo");
            this.aquarium.Add(secondFish);

            Assert.That(this.aquarium.Report(), Is.EqualTo("Fish available at SeaWorld: Dori, Nemo"));
        }
    }
}
