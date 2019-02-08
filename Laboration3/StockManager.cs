using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laboration3
{
    public class StockManager
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public StockManager()
        {
            LoadProductsFromFile();
            LoadSellRecordsFromFile();
        }

        private const string productsFile = "Products.csv";
        private void LoadProductsFromFile()
        {
            if (File.Exists(productsFile))
            {
                using (StreamReader streamReader = new StreamReader(productsFile))
                {
                    string line;
                    string[] lineData;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineData = line.Split(';');
                        Product product = new Product
                        {
                            Id = Convert.ToInt32(lineData[0]),
                            Name = lineData[1],
                            Price = Convert.ToDouble(lineData[2]),
                            Type = lineData[3],
                            Creator = lineData[4],
                            Publisher = lineData[5],
                            NumberInStock = Convert.ToInt32(lineData[6]),
                            SellRecords = new Dictionary<DateTime, int>(),
                            AmountSold = Convert.ToInt32(lineData[7])
                        };
                        Products.Add(product);
                    }
                }
            }
        }

        private const string sellRecordsFile = "SellRecords.csv";
        private void LoadSellRecordsFromFile()
        {
            if (File.Exists(productsFile) && File.Exists(sellRecordsFile))
            {
                using (StreamReader streamReader = new StreamReader(sellRecordsFile))
                {
                    string line;
                    string[] lineData;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        lineData = line.Split(';');
                        int id = Convert.ToInt32(lineData[0]);
                        DateTime date = Convert.ToDateTime(lineData[1]).Date;
                        int amount = Convert.ToInt32(lineData[2]);
                        Product product = Products.First(x => x.Id == id);
                        if (product.SellRecords.ContainsKey(date))
                            product.SellRecords[date] += amount;
                        else
                            product.SellRecords.Add(date, amount);
                    }
                }
            }
        }

        public void SaveProductsToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(productsFile))
            {
                foreach (Product product in Products)
                {
                    string line = product.Id.ToString() + ';';
                    line += product.Name + ';';
                    line += product.Price.ToString() + ';';
                    line += product.Type + ';';
                    line += product.Creator + ';';
                    line += product.Publisher + ';';
                    line += product.NumberInStock.ToString() + ';';
                    line += product.AmountSold.ToString();
                    streamWriter.WriteLine(line);
                }
            }
        }

        public void SaveSellRecordsToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(sellRecordsFile))
            {
                foreach (Product product in Products)
                {
                    foreach (var sellRecord in product.SellRecords)
                    {
                        string line = product.Id.ToString() + ';';
                        line += sellRecord.Key.ToShortDateString() + ';';
                        line += sellRecord.Value.ToString();
                        streamWriter.WriteLine(line);
                    }
                }
            }
        }

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
