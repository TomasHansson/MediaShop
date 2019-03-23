using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboration3
{
    public class QueryManager
    {
        public List<Product> SearchResult { get; set; } = new List<Product>();
        public List<StatisticsItem> StatisticsResult { get; set; } = new List<StatisticsItem>();

        // CreateTopSellersStatisticsResult: Creates a list of the top-ten selling products in the given list 
        // of products over the given timePeriod.
        // Pre: The list of products is not empty. timePeriod is either "Total försäljning" (Total Sales),
        // "Senaste året" (Last Year) or "Senaste månaden" (Last Month).
        // Post: The list StatisticsResult contains the top-ten selling items from the given timePeriod.
        public void CreateTopSellersStatisticsResult(List<Product> products, string timePeriod)
        {
            StatisticsResult.Clear();
            foreach (Product product in products)
                StatisticsResult.Add(CreateStatisticsItemFromProduct(product));
            if (timePeriod == "Total försäljning")
                StatisticsResult = StatisticsResult.OrderByDescending(x => x.AmountSold).Take(10).ToList();
            else if (timePeriod == "Senaste året")
                StatisticsResult = StatisticsResult.OrderByDescending(x => x.AmountSoldLastYear).Take(10).ToList();
            else if (timePeriod == "Senaste månaden")
                StatisticsResult = StatisticsResult.OrderByDescending(x => x.AmountSoldLastMonth).Take(10).ToList();
        }

        // CreateSingleItemStatisticsResult: Calculates statistics for a single product.
        // Pre: product != null.
        // Post: The list StatisticsResult contains the statistics of the given product.
        public void CreateSingleItemStatisticsResult(Product product)
        {
            StatisticsResult.Clear();
            StatisticsResult.Add(CreateStatisticsItemFromProduct(product));
        }

        // CreateStatisticsItemFromProduct: Calculates the statistics of a product and returns it as a StatisticsItem.
        // Pre: product != null.
        // Post: A StatisticsItem containing the statistics of the given products has been returned to the caller.
        private StatisticsItem CreateStatisticsItemFromProduct(Product product)
        {
            StatisticsItem statisticsItem = new StatisticsItem()
            {
                Id = product.Id,
                Name = product.Name,
                AmountSoldLastMonth = 0,
                AmountSoldLastYear = 0,
                AmountSold = product.AmountSold
            };
            foreach (var sellRecord in product.SellRecords)
            {
                if (sellRecord.Key >= DateTime.Today.AddMonths(-1))
                    statisticsItem.AmountSoldLastMonth += sellRecord.Value;
                if (sellRecord.Key >= DateTime.Today.AddYears(-1))
                    statisticsItem.AmountSoldLastYear += sellRecord.Value;
            }
            return statisticsItem;
        }

        // CreateSearchResult: Creates a list of products that fits the criteria of the given search-criteria.
        // Pre: products is a non-empty list of products. searchTerm is a non-empty string. minValue and maxValue are both >= 0.
        // searchFilter is one of the following: "Varunummer" (Id), "Namn" (Name), "Pris" (Price), "Varutyp" (Type), "Skapare" (Creator),
        // "Utgivare" (Publisher), "Lager" (NumberInStock) or "Antal sålda" (AmountSold).
        // Post: The list SearchResult contains all products that fits the given search-critera.
        public void CreateSearchResult(List<Product> products, string searchFilter, string searchTerm, double minValue, double maxValue)
        {
            switch (searchFilter)
            {
                case "Varunummer": SearchResult = products.Where(x => x.Id >= minValue && x.Id <= maxValue).ToList(); break;
                case "Namn": SearchResult = products.Where(x => x.Name.ToLower().Contains(searchTerm)).ToList(); break;
                case "Pris": SearchResult = products.Where(x => x.Price >= minValue && x.Price <= maxValue).ToList(); break;
                case "Varutyp": SearchResult = products.Where(x => x.Type.ToLower().Contains(searchTerm)).ToList(); break;
                case "Skapare": SearchResult = products.Where(x => x.Creator.ToLower().Contains(searchTerm)).ToList(); break;
                case "Utgivare": SearchResult = products.Where(x => x.Publisher.ToLower().Contains(searchTerm)).ToList(); break;
                case "Lager": SearchResult = products.Where(x => x.NumberInStock >= minValue && x.NumberInStock <= maxValue).ToList(); break;
                case "Antal sålda": SearchResult = products.Where(x => x.AmountSold >= minValue && x.AmountSold <= maxValue).ToList(); break;
            }
        }
    }
}