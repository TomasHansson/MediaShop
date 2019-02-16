using System;
using System.Collections.Generic;

namespace Laboration3
{
    public class StockManager
    {
        public List<Product> Products { get; set; } = new List<Product>();

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

        public void DeliveryOfProduct(Product product, int amount)
        {
            product.NumberInStock += amount;
        }

        public void ReturnOfProduct(Product product, int amount, DateTime sellDate)
        {
            product.NumberInStock += amount;
            product.AmountSold -= amount;
            if (product.SellRecords[sellDate] - amount == 0)
                product.SellRecords.Remove(sellDate);
            else
                product.SellRecords[sellDate] -= amount;
        }

        public void SaleOfProduct(Product product, int amount, DateTime sellDate)
        {
            product.NumberInStock -= amount;
            product.AmountSold += amount;
            if (product.SellRecords.ContainsKey(sellDate.Date))
                product.SellRecords[sellDate.Date] += amount;
            else
                product.SellRecords.Add(sellDate.Date, amount);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}
