using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private string owner = "Stancho";
        private string itemId = "Cash";

        private Dictionary<string, Item> vaultCells;

        [SetUp]
        public void Setup()
        {
            this.vaultCells = new Dictionary<string, Item>();
        }

        [Test]
        public void ItemConstructorShouldWorkCorrectly()
        {
            //Arrange
            Item currentItem = new Item(this.owner, this.itemId);

            //Assert
            string actualOwner = currentItem.Owner;
            string actualItemID = currentItem.ItemId;

            string expectedOwner = "Stancho";
            string expectedItemID = "Cash";
            Assert.AreEqual(expectedOwner, actualOwner);
            Assert.AreEqual(expectedItemID, actualItemID);
        }

        [Test]
        public void BankVaultConstructorShouldWorkCorrectly()
        {
            //Arrange
            Item currentItem = new Item(this.owner, this.itemId);
            BankVault currentBV = new BankVault();

            int expectedCount = 12;
            int actualCount = currentBV.VaultCells.Count;
            Assert.AreEqual(expectedCount, actualCount);
           
        }

        [Test]
        public void BankVaultAddItemThrowExceptionIfNotConteinsThisCell()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");

            Assert.Throws<ArgumentException>(() =>
            {
                currentBankVault.AddItem("NqmaTakava", currentItem);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void BankVaultAddItemThrowExceptionIfCellItsNotNull()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");
            Item secondItem = new Item("NEw", "SOME");

            currentBankVault.AddItem("A1", currentItem);

            Assert.Throws<ArgumentException>(() =>
            {
                currentBankVault.AddItem("A1", secondItem);
            }, "Cell is already taken!");
        }

        [Test]
        public void BankVaultAddItemThrowExceptionIfCellExists()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");

            currentBankVault.AddItem("A1", currentItem);

            Assert.Throws<InvalidOperationException>(() =>
            {
                currentBankVault.AddItem("A2", currentItem);
            }, "Item is already in cell!");
        }

        [Test]
        public void BankVaultAddItemShouldWorkCorrectly()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");

            string expectedResult = $"Item:{currentItem.ItemId} saved successfully!";
            string actualResult = currentBankVault.AddItem("A1", currentItem);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void BankVaultRemoveItemThrowExceptionIfNotConteinsItem()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");

            Assert.Throws<ArgumentException>(() =>
            {
                currentBankVault.RemoveItem("NqmaTakava", currentItem);
            }, "Cell doesn't exists!");
        }

        [Test]
        public void BankVaultRemoveItemThrowExceptionIfItemNotExist()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();

            Item currentItem = new Item("Az", "QWERTY");

            Assert.Throws<ArgumentException>(() =>
            {
                currentBankVault.RemoveItem("A1", currentItem);
            }, $"Item in that cell doesn't exists!");
        }


        [Test]
        public void BankVaultRemoveItemWork()
        {
            //Arrange
            BankVault currentBankVault = new BankVault();
            Item currentItem = new Item("Az", "QWERTY");
            currentBankVault.AddItem("B1", currentItem);

            string expectedResult = $"Remove item:{currentItem.ItemId} successfully!";
            string actualResult = currentBankVault.RemoveItem("B1", currentItem);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}