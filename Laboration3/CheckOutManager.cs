using System.Collections.Generic;

namespace Laboration3
{
    public class CheckOutManager
    {
        public List<ShoppingCartItem> ShoppingCart { get; set; } = new List<ShoppingCartItem>();
        public double OrderTotal { get; set; }
        private readonly IReceiptPrinter _receiptPrinter;

        public CheckOutManager(IReceiptPrinter receiptPrinter = null)
        {
            _receiptPrinter = receiptPrinter ?? new ReceiptPrinter(ShoppingCart);
        }

        public void AddProductToShoppingCart(Product product, int amount)
        {
            ShoppingCart.Add(CreateShoppingCartItemFromProduct(product, amount));
            CalculateOrderTotal();
        }

        private ShoppingCartItem CreateShoppingCartItemFromProduct(Product product, int amount)
        {
            ShoppingCartItem newShoppingCartItem = new ShoppingCartItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Amount = amount,
                TotalPrice = product.Price * amount,
                NumberInStock = product.NumberInStock
            };
            return newShoppingCartItem;
        }

        private void CalculateOrderTotal()
        {
            double totalAmount = 0;
            foreach (ShoppingCartItem item in ShoppingCart)
                totalAmount += item.TotalPrice;
            OrderTotal = totalAmount;
        }

        public void IncreaseAmountOfItem(ShoppingCartItem shoppingCartItem)
        {
            shoppingCartItem.Amount++;
            shoppingCartItem.TotalPrice += shoppingCartItem.Price;
            CalculateOrderTotal();
        }

        public void DecreaseAmountOfItem(ShoppingCartItem shoppingCartItem)
        {
            shoppingCartItem.Amount--;
            shoppingCartItem.TotalPrice -= shoppingCartItem.Price;
            CalculateOrderTotal();
        }

        public void RemoveItem(ShoppingCartItem shoppingCartItem)
        {
            ShoppingCart.Remove(shoppingCartItem);
            CalculateOrderTotal();
        }

        public void PrintReceipt()
        {
            _receiptPrinter.PrintReceipt(OrderTotal);
        }

        public void FinishOrder()
        {
            ShoppingCart.Clear();
            OrderTotal = 0;
        }
    }
}
