using System;
using NUnit.Framework;
//using CarManager;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            this.car = new Car("Nissan", "Rogue", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "Model", -3, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -7)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make,model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            Assert.That(car.Make, Is.EqualTo("Nissan"));
            Assert.That(car.Model, Is.EqualTo("Rogue"));
            Assert.That(car.FuelConsumption, Is.EqualTo(10));
            Assert.That(car.FuelCapacity, Is.EqualTo(100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-17)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => this.car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreasesFuelAmount_WhenFuelIsValid()
        {
            double refuelAmount = this.car.FuelCapacity / 2;
            this.car.Refuel(refuelAmount);

            Assert.That(this.car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmountToFuelCapacity_WhenCapacityIsExceeded()
        {
            this.car.Refuel(this.car.FuelCapacity * 1.2);

            Assert.That(this.car.FuelAmount, Is.EqualTo(this.car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenFuelIsNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(100));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDriveIsValidOperation()
        {
            double initialFuel = this.car.FuelCapacity;
            this.car.Refuel(initialFuel);
            this.car.Drive(100);

            Assert.That(this.car.FuelAmount, Is.LessThan(initialFuel));
        }

        [Test]
        public void Drive_DecreasesFuelAmountToZero_WhenNeededFuelIsEqualToFuelAmount()
        {
            this.car.Refuel(this.car.FuelCapacity);
            double distance = this.car.FuelCapacity * this.car.FuelConsumption;
            this.car.Drive(distance);

            Assert.That(this.car.FuelAmount, Is.EqualTo(0));
        }
    }
}
