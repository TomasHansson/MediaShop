using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laboration3
{
    public static class FileManager
    {
        // LoadProductsFromFile: Loads a stored list of Products.
        // Pre: A file containing a list of Products exists at the given filepath.
        // Post: A list of the Products in the file with the given filepath has been returned
        // to the caller.
        public static List<Product> LoadProductsFromFile(string filepath)
        {
            List<Product> products = new List<Product>();
            using (StreamReader streamReader = new StreamReader(filepath))
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
                    products.Add(product);
                }
            }
            return products;
        }

        // LoadSellRecordsFromFile: Loads a stored list of SellRecords and applies them to the corresponding products.
        // Pre: A .csv-file containing a list of SellRecords exists at the given filepath. The given list of products 
        // contains all the products whose SellRecords are found within this file.
        // Post: The SellRecords recorded in the given file has been applied to the related products in the given list
        // of products.
        public static void LoadSellRecordsFromFile(List<Product> products, string filepath)
        {
            using (StreamReader streamReader = new StreamReader(filepath))
            {
                string line;
                string[] lineData;
                while ((line = streamReader.ReadLine()) != null)
                {
                    lineData = line.Split(';');
                    int id = Convert.ToInt32(lineData[0]);
                    DateTime date = Convert.ToDateTime(lineData[1]).Date;
                    int amount = Convert.ToInt32(lineData[2]);
                    Product product = products.First(x => x.Id == id);
                    if (product.SellRecords.ContainsKey(date))
                        product.SellRecords[date] += amount;
                    else
                        product.SellRecords.Add(date, amount);
                }
            }
        }

        // SaveProductsToFile: Stores the given list of products to a file at the given filepath.
        // Pre: The given list of products is not empty.
        // Post: All products in the given list has been recorded in a file at the given filepath.
        public static void SaveProductsToFile(List<Product> products, string filepath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filepath))
            {
                foreach (Product product in products)
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

        // SaveSellRecordsToFile: Stores the SellRecords for the products in the given list to a file at the given filepath.
        // Pre: The given list of products is not empty.
        // Post: All SellRecords for the products in the given list has been recorded in a file at the given filepath.
        public static void SaveSellRecordsToFile(List<Product> products, string filepath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filepath))
            {
                foreach (Product product in products)
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
    }
}
