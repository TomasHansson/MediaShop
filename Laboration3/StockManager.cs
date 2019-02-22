using System;
using System.Collections.Generic;

namespace Laboration3
{
    public class StockManager
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(int id, string name, double price, string type, string creator, string publisher)
        {
            if (id <= 0)
                throw new ArgumentException("Id must be a positive number.");

            if (Products.Exists(p => p.Id == id))
                throw new ArgumentException("Id must be unique.");

            if (price <= 0)
                throw new ArgumentException("Price must be a positive number.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Type cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(creator))
                throw new ArgumentException("Creator cannot be null or whitespace.");

            if (string.IsNullOrWhiteSpace(publisher))
                throw new ArgumentException("Publisher cannot be null or whitespace.");

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
            if (product == null)
                throw new ArgumentNullException("Product cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be a positive number.");

            product.NumberInStock += amount;
        }

        public void ReturnOfProduct(Product product, int amount, DateTime sellDate)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be a positive number.");

            if (sellDate > DateTime.Today)
                throw new ArgumentException("The selldate cannot be a future date.");

            if (!product.SellRecords.ContainsKey(sellDate))
                throw new ArgumentException("No sales of the product were made on given date.");

            if (product.SellRecords[sellDate] < amount)
                throw new ArgumentException("Amount cannot be larger than amount sold on given date.");

            product.NumberInStock += amount;
            product.AmountSold -= amount;
            if (product.SellRecords[sellDate] - amount == 0)
                product.SellRecords.Remove(sellDate);
            else
                product.SellRecords[sellDate] -= amount;
        }

        public void SaleOfProduct(Product product, int amount)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null.");

            if (amount <= 0)
                throw new ArgumentException("Amount must be a positive number.");

            if (amount > product.NumberInStock)
                throw new ArgumentException("Amount must be equal to or less than the products NumberInStock.");

            product.NumberInStock -= amount;
            product.AmountSold += amount;
            if (product.SellRecords.ContainsKey(DateTime.Today))
                product.SellRecords[DateTime.Today] += amount;
            else
                product.SellRecords.Add(DateTime.Today, amount);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product cannot be null.");

            Products.Remove(product);
        }
    }
}
