using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Laboration3.UnitTests
{
    [TestFixture]
    class CheckOutManagerTests
    {
        private CheckOutManager _checkOutManager;
        private Product _sampleProduct;
        private ShoppingCartItem _sampleShoppingCartItem;
        private Mock<IReceiptPrinter> _receiptPrinter;

        [SetUp]
        public void SetUp()
        {
            _receiptPrinter = new Mock<IReceiptPrinter>();
            _checkOutManager = new CheckOutManager(_receiptPrinter.Object);
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
            _sampleShoppingCartItem = new ShoppingCartItem
            {
                Id = 1,
                Name = "Name",
                Amount = 1,
                Price = 10,
                TotalPrice = 10,
                NumberInStock = 5
            };
        }

        [Test]
        public void AddProductToShoppingCart_ValidInputParameters_ProductAddedToShoppingCart()
        {
            _checkOutManager.AddProductToShoppingCart(_sampleProduct, 1);

            Assert.That(_checkOutManager.ShoppingCart.Exists(sci => sci.Id == 1));
        }

        [Test]
        public void AddProductToShoppingCart_ValidInputParameters_OrderTotalSetToProductsTotalPrice()
        {
            _checkOutManager.AddProductToShoppingCart(_sampleProduct, 1);

            Assert.That(_checkOutManager.OrderTotal, Is.EqualTo(_sampleProduct.Price));
        }

        [Test]
        public void IncreaseAmountOfItem_ValidInputParameters_AmountOfItemIncreasedByOne()
        {
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.IncreaseAmountOfItem(_sampleShoppingCartItem);

            Assert.That(_sampleShoppingCartItem.Amount, Is.EqualTo(2));
        }

        [Test]
        public void IncreaseAmountOfItem_ValidInputParameters_TotalPriceOfItemIncreasedByItemsPrice()
        {
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.IncreaseAmountOfItem(_sampleShoppingCartItem);

            Assert.That(_sampleShoppingCartItem.TotalPrice, Is.EqualTo(_sampleShoppingCartItem.Price * 2));
        }

        [Test]
        public void DecreaseAmountOfItem_ValidInputParameters_AmountOfItemDecreasedByOne()
        {
            _sampleShoppingCartItem.Amount = 2;
            _sampleShoppingCartItem.TotalPrice *= 2;
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.DecreaseAmountOfItem(_sampleShoppingCartItem);

            Assert.That(_sampleShoppingCartItem.Amount, Is.EqualTo(1));
        }

        [Test]
        public void DecreaseAmountOfItem_ValidInputParameters_TotalPriceOfItemDecreasedByItemsPrice()
        {
            _sampleShoppingCartItem.Amount = 2;
            _sampleShoppingCartItem.TotalPrice *= 2;
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.DecreaseAmountOfItem(_sampleShoppingCartItem);

            Assert.That(_sampleShoppingCartItem.Price, Is.EqualTo(_sampleShoppingCartItem.Price));
        }

        [Test]
        public void RemoveItem_ValidInputParameters_ItemRemovedFromShoppingCart()
        {
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.RemoveItem(_sampleShoppingCartItem);

            Assert.That(!_checkOutManager.ShoppingCart.Exists(sci => sci.Id == 1));
        }

        [Test]
        public void PrintReceipt_WhenCalled_CallsThePrintReceiptFunctionForTheReceiptPrinter()
        {
            _checkOutManager.PrintReceipt();

            _receiptPrinter.Verify(rp => rp.PrintReceipt(_checkOutManager.OrderTotal));
        }

        [Test]
        public void FinishOrder_WhenCalled_ShoppingCartCountIsZero()
        {
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.ClearShoppingCart();

            Assert.That(_checkOutManager.ShoppingCart.Count, Is.EqualTo(0));
        }

        [Test]
        public void FinishOrder_WhenCalled_OrderTotalIsZero()
        {
            _checkOutManager.ShoppingCart.Add(_sampleShoppingCartItem);

            _checkOutManager.ClearShoppingCart();

            Assert.That(_checkOutManager.OrderTotal, Is.EqualTo(0));
        }
    }
}
