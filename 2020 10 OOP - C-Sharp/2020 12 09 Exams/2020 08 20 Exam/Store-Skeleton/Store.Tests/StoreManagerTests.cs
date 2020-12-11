using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        Product product;
        private string name = "Mega";
        private int quantity = 100;
        private decimal price = 6.6m;
        private List<Product> products;
        private StoreManager manager;

        [SetUp]
        public void Setup()
        {
            this.product = new Product(name, quantity, price);
            this.products = new List<Product>();
            this.products.Add(product);
            this.manager = new StoreManager();
        }

        [TestCase("Omen", 2, 1800)]
        public void ProductConstructorShouldWorkCorrectly
            (string expectedName, int expectedQuantity, decimal expectedPrice)
        {
            //Arrange
            Product computer = new Product("Omen", 2, 1800m);

            //Act  --  Assert
            string actualName = computer.Name;
            int actualQuantity = computer.Quantity;
            decimal actualPrice = computer.Price;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedQuantity, actualQuantity);
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestCase("Mega")]
        public void ProductNameShouldWorkCorrectly(string expectedName)
        {
            //Act  --  Assert
            string actualName = this.product.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(100)]
        public void ProductQuantityShouldWorkCorrectly(int expectedQuantity)
        {
            //Act  --  Assert
            int actualQuantity = this.product.Quantity;
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [TestCase(7)]
        public void ProductQuantitySeterShouldWorkCorrectly(int expectedQuantity)
        {
            //Act  
            this.product.Quantity = 7;
            //Assert
            int actualQuantity = this.product.Quantity;
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [TestCase(6.6)]
        public void ProductPriceShouldWorkCorrectly(decimal expectedPrice)
        {
            //Act  --  Assert
            decimal actualPrice = this.product.Price;
            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestCase(1)]
        public void ProductsCollectionShouldWorkCorrectly(int expectedResult)
        {
            //Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 1, 10m);
            currentManager.AddProduct(milk);

            //Assert
            var actualResult = currentManager.Products;
            int actualResultCount = actualResult.Count;
            Assert.AreEqual(expectedResult, actualResultCount);
        }

        [TestCase(2)]
        public void CountShouldWorkCorrectly(int expectedResult)
        {
            //Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 1, 10m);
            Product olive = new Product("Olive", 100, 3m);
            currentManager.AddProduct(milk);
            currentManager.AddProduct(olive);

            //Assert
            int actualResult = currentManager.Count;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void AddToStoreNullProductShouldThrowException()
        {
            //Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = null;

            //Assert
            Assert.Throws<ArgumentNullException>
                (() => currentManager.AddProduct(milk));
        }

        [TestCase(0)]
        [TestCase(-3)]
        public void AddToStoreZeroOrNegativeQuantityOfProductShouldThrowException(int quantity)
        {
            ///Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", quantity, 3m);

            //Assert
            Assert.Throws<ArgumentException>(() =>
               {
                   currentManager.AddProduct(milk);
               }, "Product count can't be below or equal to zero.");
        }

        [TestCase(1)]
        public void AddProductsShouldWorkCorrectly(int expectedResult)
        {
            //Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 1, 10m);
            currentManager.AddProduct(milk);

            //Assert
            var actualResult = currentManager.Products;
            int actualResultCount = actualResult.Count;
            Assert.AreEqual(expectedResult, actualResultCount);
        }

        [Test]
        public void BuyNullProductShouldThrowException()
        {
            //Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 1, 10m);
            Product olive = new Product("Olive", 100, 3m);

            //Act
            currentManager.AddProduct(milk);

            //Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                currentManager.BuyProduct("Olive", 1);
            }, nameof(olive), "There is no such product.");
        }

        [TestCase(9)]
        public void TryingToBuyMoreQuantityOfProductShouldThrowException(int quantity)
        {
            ///Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", quantity, 3m);

            //Act
            currentManager.AddProduct(milk);

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                currentManager.BuyProduct("Milk", 10);
            }, "There is not enough quantity of this product.");
        }

        [TestCase(30)]
        public void BuyingProductShouldWorkCorrectly(decimal expectedFinalPrice)
        {
            ///Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 100, 3m);

            //Act
            currentManager.AddProduct(milk);

            //Assert
            decimal actualFinalPrice = currentManager.BuyProduct("Milk", 10);
            Assert.AreEqual(expectedFinalPrice, actualFinalPrice);
        }

        [TestCase(90)]
        public void BuyingProductShouldDecreaseQuantity(int expectedQuantity)
        {
            ///Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 100, 3m);

            //Act
            currentManager.AddProduct(milk);
            currentManager.BuyProduct("Milk", 10);

            //Assert
            int actualQuantity = milk.Quantity;
            Assert.AreEqual(expectedQuantity, actualQuantity);
        }

        [Test]
        public void GetTheMostExpensiveProductShouldWorkCorrectly()
        {
            ///Arrange
            StoreManager currentManager = new StoreManager();
            Product milk = new Product("Milk", 100, 3m);
            Product olive = new Product("Olive", 100, 10m);
            Product car = new Product("BMW", 1, 70000m);

            //Act
            currentManager.AddProduct(milk);
            currentManager.AddProduct(olive);
            currentManager.AddProduct(car);

            //Assert
            Product actualProduct = currentManager.GetTheMostExpensiveProduct();
            Assert.AreEqual(car, actualProduct);
        }
    }
}