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
                Type = "Book",
                Creator = "Creator",
                Publisher = "Publisher",
                NumberInStock = 1,
                SellRecords = new Dictionary<DateTime, int>(),
                AmountSold = 0
            };
        }

        [Test]
        public void AddProduct_WhenCalled_ProductAddedToProductsList()
        {
            _stockManager.AddProduct(id: 1, name: "Name", price: 50, type: "Book", creator: "Creator", publisher: "Publisher");

            Assert.That(_stockManager.Products.Count, Is.EqualTo(1));
        }

        [Test]
        public void DeliveryOfProduct_WhenCalled_ProductsNumberInStockIncreasedByGivenAmount()
        {
            _stockManager.DeliveryOfProduct(_sampleProduct, 1);

            Assert.That(_sampleProduct.NumberInStock, Is.EqualTo(2));
        }

        [Test]
        public void RemoveProduct_WhenCalled_ProductRemovedFromProductsList()
        {
            _stockManager.Products = new List<Product> { _sampleProduct };

            _stockManager.RemoveProduct(_sampleProduct);

            Assert.That(_stockManager.Products.Count, Is.EqualTo(0));
        }

        [Test]
        public void SaleOfProduct_WhenCalled_SellDateAddedToProductsSellRecords()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1, DateTime.Today);

            Assert.That(_sampleProduct.SellRecords.ContainsKey(DateTime.Today));
        }

        [Test]
        public void SaleOfProduct_WhenCalled_AmountSoldOfProductIncreasedByGivenAmount()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1, DateTime.Today);

            Assert.That(_sampleProduct.AmountSold, Is.EqualTo(1));
        }

        [Test]
        public void SaleOfProduct_WhenCalled_NumberInStockOfProductDecreasedByGivenAmount()
        {
            _stockManager.SaleOfProduct(_sampleProduct, 1, DateTime.Today);

            Assert.That(_sampleProduct.NumberInStock, Is.EqualTo(0));
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
    }
}
