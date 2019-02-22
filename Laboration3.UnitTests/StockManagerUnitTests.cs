using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Laboration3.UnitTests
{
    [TestFixture]
    class StockManagerUnitTests
    {
        private StockManager _stockManager;
        private Product _sampleProduct;

        [SetUp]
        public void Setup()
        {
            _stockManager = new StockManager();
            _sampleProduct = new Product
            {
                Id = 1,
                Name = "Name",
                Price = 10,
                Type = "Type",
                Creator = "Creator",
                Publisher = "Publisher",
                NumberInStock = 1,
                SellRecords = new Dictionary<DateTime, int>(),
                AmountSold = 0
            };
        }

        [Test]
        public void AddProduct_ValidInputParameters_ProductAddedToProductsList()
        {
            _stockManager.AddProduct(id: 1, name: "Name", price: 50, type: "Type", creator: "Creator", publisher: "Publisher");

            Assert.That(_stockManager.Products.Count, Is.EqualTo(1));
        }

        [Test]
        [TestCase(0, "Name", 50, "Type", "Creator", "Publisher")] // Id is not a positive number.
        [TestCase(2, "Name", 50, "Type", "Creator", "Publisher")] // Id is already used (_sampleProduct with Id: 2 already added).
        [TestCase(1, null, 50, "Type", "Creator", "Publisher")] // Name is null.
        [TestCase(1, "", 50, "Type", "Creator", "Publisher")] // Name is empty.
        [TestCase(1, " ", 50, "Type", "Creator", "Publisher")] // Name is whitespace.
        [TestCase(1, "Name", 0, "Type", "Creator", "Publisher")] // Price is not a positive number.
        [TestCase(1, "Name", 50, null, "Creator", "Publisher")] // Type is null.
        [TestCase(1, "Name", 50, "", "Creator", "Publisher")] // Type is empty.
        [TestCase(1, "Name", 50, " ", "Creator", "Publisher")] // Type is whitespace.
        [TestCase(1, "Name", 50, "Type", null, "Publisher")] // Creator is null.
        [TestCase(1, "Name", 50, "Type", "", "Publisher")] // Creator is empty.
        [TestCase(1, "Name", 50, "Type", " ", "Publisher")] // Creator is whitespace.
        [TestCase(1, "Name", 50, "Type", "Creator", null)] // Publisher is null.
        [TestCase(1, "Name", 50, "Type", "Creator", "")] // Publisher is empty.
        [TestCase(1, "Name", 50, "Type", "Creator", " ")] // Publisher is whitespace.
        public void AddProduct_InvalidInputParameters_ThrowsArgumentException(int id, string name, double price, string type, string creator, string publisher)
        {
            _sampleProduct.Id = 2;
            _stockManager.Products.Add(_sampleProduct);

            Assert.Throws<ArgumentException>(() => _stockManager.AddProduct(id, name, price, type, creator, publisher));
        }

        [Test]
        public void DeliveryOfProduct_ValidInputParameters_ProductsNumberInStockIncreasedByGivenAmount()
        {
            _stockManager.DeliveryOfProduct(_sampleProduct, 1);

            Assert.That(_sampleProduct.NumberInStock, Is.EqualTo(2));
        }

        [Test]
        public void DeliveryOfProduct_ProductIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stockManager.DeliveryOfProduct(null, 1));
        }

        [Test]
        public void DeliveryOrProduct_AmountIsNotAPositiveNumber_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stockManager.DeliveryOfProduct(_sampleProduct, 0));
        }

        [Test]
        public void RemoveProduct_ValidInputParameters_ProductRemovedFromProductsList()
        {
            _stockManager.Products.Add(_sampleProduct);

            _stockManager.RemoveProduct(_sampleProduct);

            Assert.That(_stockManager.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveProduct_ProductIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stockManager.RemoveProduct(null));
        }

        [Test]
        public void SaleOfProduct_ValidInputParameters_TodaysDateAddedToProductsSellRecords()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1);

            Assert.That(_sampleProduct.SellRecords.ContainsKey(DateTime.Today));
        }

        [Test]
        public void SaleOfProduct_ValidInputParameters_AmountSoldOfProductIncreasedByGivenAmount()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1);

            Assert.That(_sampleProduct.AmountSold, Is.EqualTo(1));
        }

        [Test]
        public void SaleOfProduct_ValidInputParameters_NumberInStockOfProductDecreasedByGivenAmount()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1);

            Assert.That(_sampleProduct.NumberInStock, Is.EqualTo(0));
        }

        [Test]
        public void SaleOfProduct_ProductIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stockManager.SaleOfProduct(null, 0));
        }

        [Test]
        [TestCase(0)] // Amount is not a positive number.
        [TestCase(2)] // Amount is larger than NumberInStock of given product.
        public void SaleOfProduct_InvalidAmountParameter_ThrowArgumentException(int amount)
        {
            Assert.Throws<ArgumentException>(() => _stockManager.SaleOfProduct(_sampleProduct, amount));
        }

        [Test]
        public void ReturnOfProduct_AllItemsOnGivenDateReturned_SaleDateRemovedFromProductsSellRecords()
        {
            _sampleProduct.SellRecords.Add(DateTime.Today, 1);

            _stockManager.ReturnOfProduct(_sampleProduct, 1, DateTime.Today);

            Assert.That(!_sampleProduct.SellRecords.ContainsKey(DateTime.Today));
        }

        [Test]
        public void ReturnOfProduct_SubsetOfSoldItemsOnGivenDateReturned_ValueOfSaleDateReducedByAmountReturned()
        {
            _sampleProduct.SellRecords.Add(DateTime.Today, 2);

            _stockManager.ReturnOfProduct(_sampleProduct, 1, DateTime.Today);

            Assert.That(_sampleProduct.SellRecords[DateTime.Today], Is.EqualTo(1));
        }

        [Test]
        public void ReturnOfProduct_ProductIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stockManager.ReturnOfProduct(null, 0, DateTime.Today));
        }

        [Test]
        public void ReturnOfProduct_AmountIsNotAPositiveNumber_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stockManager.ReturnOfProduct(_sampleProduct, 0, DateTime.Today));
        }

        [Test]
        public void ReturnOfProduct_SellDateIsAFutureDate_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stockManager.ReturnOfProduct(_sampleProduct, 1, DateTime.Today.AddDays(1)));
        }

        [Test]
        public void ReturnOfProduct_NoSalesMadeOnGivenSellDate_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stockManager.ReturnOfProduct(_sampleProduct, 1, DateTime.Today));
        }

        [Test]
        public void ReturnOfProduct_AmountIsLargerThanAmountSoldOnGivenSellDate_ThrowArgumentException()
        {
            _sampleProduct.SellRecords.Add(DateTime.Today, 1);

            Assert.Throws<ArgumentException>(() => _stockManager.ReturnOfProduct(_sampleProduct, 2, DateTime.Today));
        }
    }
}
