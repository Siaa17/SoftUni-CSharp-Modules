namespace Presents.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
            this.present = new Present("KenDoll", 17.5);
        }

        [Test]
        public void Ctor_InitializesCollectionOfPresents()
        {
            Assert.That(this.bag, Is.Not.Null);
        }

        [Test]
        public void Create_ThrowsException_WhenPresentIsNull()
        {
            present = null;

            Assert.Throws<ArgumentNullException>(() => this.bag.Create(present));
        }

        [Test]
        public void Create_ThrowsException_WhenPresentIsAlreadyExists()
        {
            this.bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present));
        }

        [Test]
        public void Create_AddsPresentToTheBag_WhenCreateIsValidOperation()
        {
            this.bag.Create(present);

            Assert.That(present, Is.EqualTo(this.bag.GetPresent(present.Name))); 
        }

        [Test]
        public void Create_ReturnsSuccesfullyAddedMessage()
        {
            Assert.That(this.bag.Create(present), Is.EqualTo($"Successfully added present {present.Name}."));
        }

        [Test]
        public void Remove_RemovesPresent_WhenBooleanReturnsTrue()
        {
            this.bag.Create(present);

            Assert.That(this.bag.Remove(present), Is.True);
        }

        [Test]
        public void Remove_RemovesPresent_WhenBooleanReturnsFalse()
        {
            Assert.That(this.bag.Remove(present), Is.False);
        }

        [Test]
        public void GetPresentWithLeastMagic_ReturnsPresentWithLeastMagic()
        {
            Present leastMagicPresent = new Present("BarbieDoll", 3.5);

            this.bag.Create(present);
            this.bag.Create(leastMagicPresent);

            Assert.AreEqual(leastMagicPresent, this.bag.GetPresentWithLeastMagic());
        }

        [Test]
        public void GetPresent_ReturnsPresentWithTheGivenName()
        {
            this.bag.Create(present);

            Assert.AreEqual(present, this.bag.GetPresent(present.Name));
        }

        [Test]
        public void GetPresents_ReturnsBagAsReadonlyCollection()
        {
            Assert.That(this.bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        }
    }
}
