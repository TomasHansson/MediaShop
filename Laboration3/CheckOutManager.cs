using System.Collections.Generic;

namespace Laboration3
{
    public class CheckOutManager
    {
        public List<ShoppingCartItem> ShoppingCart { get; set; } = new List<ShoppingCartItem>();
        public double OrderTotal { get; set; }
        private readonly IReceiptPrinter _receiptPrinter;

        // CheckOutManager: Constructor.
        // Pre: -
        // Post: A type implementing IReceiptPriner has been created and _receiptPrinter
        // has been set to it.
        public CheckOutManager(IReceiptPrinter receiptPrinter = null)
        {
            _receiptPrinter = receiptPrinter ?? new ReceiptPrinter(ShoppingCart);
        }

        // AddProductToShoppingCart: Adds the given product to the ShoppingCart.
        // Pre: Product != null. 1 <= amount <= product.NumberInStock.
        // Post: A ShoppingCartItem representing the given product has been added to the ShoppingCart.
        // The OrderTotal has been recalculated based on the new content of the ShoppingCart.
        public void AddProductToShoppingCart(Product product, int amount)
        {
            ShoppingCart.Add(CreateShoppingCartItemFromProduct(product, amount));
            CalculateOrderTotal();
        }

        // CreateShoppingCartFromProduct: Creates a ShoppingCartItem based on the given product and amount.
        // Pre: Product != null. 1 <= amount <= product.NumberInStock.
        // Post: A ShoppingCartItem based on the given product and amount has been returned to caller.
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

        // CalculateOrderTotal: Calculates the total cost of all items on the ShoppingCart.
        // Pre: -
        // Post: OrderTotal is equal to the total cost of all items in the ShoppingCart.
        private void CalculateOrderTotal()
        {
            OrderTotal = 0;
            foreach (ShoppingCartItem item in ShoppingCart)
                OrderTotal += item.TotalPrice;
        }

        // IncreaseAmountOfItem: Increased the Amount of given ShoppingCartItem by one.
        // Pre: shoppingCartItem != null.
        // Post: Amount of given shoppingCartItem has increased by one, its TotalPrice 
        // increased by its Price and the OrderTotal has been recalculated.
        public void IncreaseAmountOfItem(ShoppingCartItem shoppingCartItem)
        {
            shoppingCartItem.Amount++;
            shoppingCartItem.TotalPrice += shoppingCartItem.Price;
            CalculateOrderTotal();
        }

        // DecreaseAmountOfItem: Decrease the Amount of given ShoppingCartItem by one.
        // Pre: shoppingCartItem != null. shoppingCartItem.Amount > 1. 
        // Post: Amount of given shoppingCartItem has decreased by one, its TotalPrice 
        // decreased by its Price and the OrderTotal has been recalculated.
        public void DecreaseAmountOfItem(ShoppingCartItem shoppingCartItem)
        {
            shoppingCartItem.Amount--;
            shoppingCartItem.TotalPrice -= shoppingCartItem.Price;
            CalculateOrderTotal();
        }

        // RemoveItem: Removes the given ShoppingCartItem from the ShoppingCart.
        // Pre: -
        // Post: shoppingCartItem has been removed from the ShoppingCart and the OrderTotal
        // has been recalculated.
        public void RemoveItem(ShoppingCartItem shoppingCartItem)
        {
            ShoppingCart.Remove(shoppingCartItem);
            CalculateOrderTotal();
        }

        // PrintReciept: Calls the PrintReceipt-functions of the _receiptPrinter.
        // Pre: The ShoppingCart is not empty.
        // Post: The receipt has been printed by way of the _receiptPrinter.
        public void PrintReceipt()
        {
            _receiptPrinter.PrintReceipt(OrderTotal);
        }

        // ClearShoppingCart: Removes all items from the ShoppingCart.
        // Pre: -
        // Post: The ShoppingCart has been emptied and the OrderTotal
        // has been set to 0.
        public void ClearShoppingCart()
        {
            ShoppingCart.Clear();
            OrderTotal = 0;
        }
    }
}
