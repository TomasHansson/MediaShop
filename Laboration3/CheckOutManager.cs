using System.Collections.Generic;
using System.Windows.Forms;

namespace Laboration3
{
    public class CheckOutManager
    {
        public List<ShoppingCartItem> ShoppingCart { get; set; } = new List<ShoppingCartItem>();
        public double OrderTotal { get; set; }
        private readonly ReceiptPrinter receiptPrinter;

        public CheckOutManager()
        {
            receiptPrinter = new ReceiptPrinter(ShoppingCart);
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

        public void FinishOrder()
        {
            AskToWriteReceipt();
            ShoppingCart.Clear();
            OrderTotal = 0;
        }

        private void AskToWriteReceipt()
        {
            DialogResult dialogResult = MessageBox.Show("Vill du skriva ut ett kvitto för köpet?",
                            "Kvitto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
                return;
            receiptPrinter.PrintReceipt(OrderTotal);
        }
    }
}
