using NUnit.Framework;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
            this.item = new Item("Biana", "1712");
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellDoesNotExists()
        {
            Assert.That(() => this.bankVault.AddItem("B25", item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellIsAlreadyTaken()
        {
            this.bankVault.AddItem("B3", item);            

            Assert.That(() => this.bankVault.AddItem("B3", item), Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void AddItem_ThrowsException_WhenItemIsAlreadyInCell()
        {
            this.bankVault.AddItem("C4", item);

            Assert.That(() => this.bankVault.AddItem("A1", item), Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void AddItem_AddsItem_WhenAddIsValidOperation()
        {
            Assert.That(this.bankVault.AddItem("A4", item), Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
        }

        [Test]
        public void AddItem_AddsItem_ShouldReturnsItem()
        {
            this.bankVault.AddItem("C2", item);

            Assert.That(this.bankVault.VaultCells["C2"], Is.EqualTo(item));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenCellDoesNotExists()
        {
            Assert.That(() => this.bankVault.RemoveItem("B25", item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void RemoveItem_ThrowsException_WhenItemInThatCellDoesNotExists()
        {
            Assert.That(() => this.bankVault.RemoveItem("B1", item), Throws.ArgumentException.With.Message.EqualTo("Item in that cell doesn't exists!"));
        }

        [Test]
        public void RemoveItem_RemovesItem_WhenRemoveIsValidOperation()
        {
            this.bankVault.AddItem("C2", item);
            
            Assert.That(this.bankVault.RemoveItem("C2", item), Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
        }

        [Test]
        public void RemoveItem_RemovesItem_ShouldReturnsNull()
        {
            this.bankVault.AddItem("C2", item);
            this.bankVault.RemoveItem("C2", item);

            Assert.That(this.bankVault.VaultCells["C2"], Is.EqualTo(null));
        }
    }
}