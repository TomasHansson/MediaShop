using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Laboration3.UnitTests
{
    [TestFixture]
    class QueryManagerTests
    {
        private QueryManager _queryManager;
        private Product _sampleProductOne;
        private Product _sampleProductTwo;
        private List<Product> _sampleProducts;

        [SetUp]
        public void SetUp()
        {
            _queryManager = new QueryManager();
            _sampleProductOne = new Product()
            {
                Id = 1,
                Name = "A",
                Price = 1,
                Type = "A",
                Creator = "A",
                Publisher = "A",
                NumberInStock = 1,
                SellRecords = new Dictionary<DateTime, int>(),
                AmountSold = 1
            };
            _sampleProductTwo = new Product()
            {
                Id = 2,
                Name = "B",
                Price = 2,
                Type = "B",
                Creator = "B",
                Publisher = "B",
                NumberInStock = 2,
                SellRecords = new Dictionary<DateTime, int>(),
                AmountSold = 2
            };
            _sampleProducts = new List<Product>();
        }

        [Test]
        public void CreateTopSellersStatisticsResult_TimePeriodIsTotalSales_AllTimeTopSellingProductOnTop()
        {
            _sampleProductOne.SellRecords.Add(DateTime.Now, 1);
            _sampleProducts.Add(_sampleProductOne);
            _sampleProductTwo.SellRecords.Add(DateTime.Now, 2);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateTopSellersStatisticsResult(_sampleProducts, "Total försäljning");

            Assert.That(_queryManager.StatisticsResult[0].Id, Is.EqualTo(_sampleProductTwo.Id));
        }

        [Test]
        public void CreateTopSellersStatisticsResult_TimePeriodIsLastYear_LastYearsTopSellingProductOnTop()
        {
            _sampleProductOne.AmountSold = 1;
            _sampleProductOne.SellRecords.Add(DateTime.Now.AddYears(-2), 1);
            _sampleProducts.Add(_sampleProductOne);
            _sampleProductTwo.AmountSold = 1;
            _sampleProductTwo.SellRecords.Add(DateTime.Now, 1);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateTopSellersStatisticsResult(_sampleProducts, "Senaste året");

            Assert.That(_queryManager.StatisticsResult[0].Id, Is.EqualTo(_sampleProductTwo.Id));
        }

        [Test]
        public void CreateTopSellersStatisticsResult_TimePeriodIsLastMonth_LastMonthsTopSellingProductOnTop()
        {
            _sampleProductOne.AmountSold = 1;
            _sampleProductOne.SellRecords.Add(DateTime.Now.AddMonths(-2), 1);
            _sampleProducts.Add(_sampleProductOne);
            _sampleProductTwo.AmountSold = 1;
            _sampleProductTwo.SellRecords.Add(DateTime.Now, 1);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateTopSellersStatisticsResult(_sampleProducts, "Senaste månaden");

            Assert.That(_queryManager.StatisticsResult[0].Id, Is.EqualTo(_sampleProductTwo.Id));
        }

        [Test]
        public void CreateSingleItemStatisticsResult_WhenCalled_StatisticsResultListContainsTheGivenProductAsStatisticsItem()
        {
            _queryManager.CreateSingleItemStatisticsResult(_sampleProductOne);

            Assert.That(_queryManager.StatisticsResult.Exists(si => si.Id == _sampleProductOne.Id));
        }

        [Test]
        [TestCase("Namn", "a", 1)]
        [TestCase("Namn", "b", 2)]
        [TestCase("Varutyp", "a", 1)]
        [TestCase("Varutyp", "b", 2)]
        [TestCase("Skapare", "a", 1)]
        [TestCase("Skapare", "b", 2)]
        [TestCase("Utgivare", "a", 1)]
        [TestCase("Utgivare", "b", 2)]
        public void CreateSearchResult_SearchingStringValues_SearchResultListContainsMatchingProducts(string searchFilter, string searchTerm, int expectedResultId)
        {
            _sampleProducts.Add(_sampleProductOne);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateSearchResult(_sampleProducts, searchFilter, searchTerm, 0, 0);

            Assert.That(_queryManager.SearchResult.Exists(p => p.Id == expectedResultId));
        }

        [Test]
        [TestCase("Namn")]
        [TestCase("Varutyp")]
        [TestCase("Skapare")]
        [TestCase("Utgivare")]
        public void CreateSearchResult_SearchNonMatchingStringValues_SearchResultsListIsEmpty(string searchFilter)
        {
            _sampleProducts.Add(_sampleProductOne);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateSearchResult(_sampleProducts, searchFilter, "c", 0, 0);

            Assert.That(_queryManager.SearchResult.Count, Is.EqualTo(0));
        }

        [Test]
        [TestCase("Varunummer", 1, 1, 1)]
        [TestCase("Varunummer", 2, 2, 2)]
        [TestCase("Pris", 1, 1, 1)]
        [TestCase("Pris", 2, 2, 2)]
        [TestCase("Lager", 1, 1, 1)]
        [TestCase("Lager", 2, 2, 2)]
        [TestCase("Antal sålda", 1, 1, 1)]
        [TestCase("Antal sålda", 2, 2, 2)]
        public void CreateSearchResult_SearchingNumericValues_SearchResultListContainsMatchingProducts(string searchFilter, double minValue, double maxValue, int expectedResultId)
        {
            _sampleProducts.Add(_sampleProductOne);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateSearchResult(_sampleProducts, searchFilter, string.Empty, minValue, maxValue);

            Assert.That(_queryManager.SearchResult.Exists(p => p.Id == expectedResultId));
        }

        [Test]
        [TestCase("Varunummer")]
        [TestCase("Pris")]
        [TestCase("Lager")]
        [TestCase("Antal sålda")]
        public void CreateSearchResult_SearchNonMatchingNumericValues_SearchResultsListIsEmpty(string searchFilter)
        {
            _sampleProducts.Add(_sampleProductOne);
            _sampleProducts.Add(_sampleProductTwo);

            _queryManager.CreateSearchResult(_sampleProducts, searchFilter, string.Empty, 3, 3);

            Assert.That(_queryManager.SearchResult.Count, Is.EqualTo(0));
        }
    }
}
