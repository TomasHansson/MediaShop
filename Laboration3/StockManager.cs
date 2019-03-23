using System;
using System.Collections.Generic;

namespace Laboration3
{
    public class StockManager
    {
        public List<Product> Products { get; set; } = new List<Product>();

        // AddProducts: Adds a new Product to the list Products based on the input.
        // Pre: id is > 0 and no other product in the list shares the given id. Name, type, creator and publisher are
        // non-empty strings. price is > 0.
        // Post: A new product has been added to the list Products with the values equal to the given values.
        public void AddProduct(int id, string name, double price, string type, string creator, string publisher)
        {
            Product newProduct = new Product()
            {
                Id = id,
                Name = name,
                Price = price,
                Type = type,
                Creator = creator,
                Publisher = publisher,
                NumberInStock = 0,
                SellRecords = new Dictionary<DateTime, int>(),
                AmountSold = 0
            };
            Products.Add(newProduct);
        }

        // DeliveryOfProduct: Increases the stock of the product that has been delivered.
        // Pre: product != null. amount > 0.
        // Post: The given products NumberInStock has been increased by the given amount.
        public void DeliveryOfProduct(Product product, int amount)
        {
            product.NumberInStock += amount;
        }

        // ReturnOfProduct: Returns a previously sold item.
        // Pre: product != null. The product SellRecords contains a record of a number of items 
        // being sold on the given sellDate, the number being less than or equal to the amount
        // returned.
        // Post: The products NumberInStock has been increased by the given amount while its
        // AmountSold has been decreased by the same amount. The previous SellRecords have been
        // deducted, or removed enterily if the amount sold on the given sellDate now equals to 0.
        public void ReturnOfProduct(Product product, int amount, DateTime sellDate)
        {
            product.NumberInStock += amount;
            product.AmountSold -= amount;
            if (product.SellRecords[sellDate] - amount == 0)
                product.SellRecords.Remove(sellDate);
            else
                product.SellRecords[sellDate] -= amount;
        }

        // SaleOfProduct: Records the sale of a product.
        // Pre: product != null. amount <= NumberInStock of the given product.
        // Post: The products NumberInStock has been decreased by the given amount whilte its
        // AmountSold has been increased by the same amount. A SellRecord have been added to the
        // product, for the current date and the amount given.
        public void SaleOfProduct(Product product, int amount)
        {
            product.NumberInStock -= amount;
            product.AmountSold += amount;
            if (product.SellRecords.ContainsKey(DateTime.Today))
                product.SellRecords[DateTime.Today] += amount;
            else
                product.SellRecords.Add(DateTime.Today, amount);
        }

        // RemoveProduct: Removes a product from the list of Products.
        // Pre: The given product exists in the list of Products.
        // Post: The given product have been removed from the list of Products.
        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}
