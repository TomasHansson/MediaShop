using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboration3
{
    public class QueryManager
    {
        public List<Product> SearchResult { get; set; } = new List<Product>();
        public List<StatisticsItem> StatisticsResult { get; set; } = new List<StatisticsItem>();

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

        public void CreateSingleItemStatisticsResult(Product product)
        {
            StatisticsResult.Clear();
            StatisticsResult.Add(CreateStatisticsItemFromProduct(product));
        }

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
