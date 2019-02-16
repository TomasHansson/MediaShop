using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Laboration3
{
    public partial class MediaShop : Form
    {
        public CheckOutManager CheckOut { get; set; } = new CheckOutManager();
        public StockManager Stock { get; set; } = new StockManager();
        public QueryManager Query { get; set; } = new QueryManager();
        public ShoppingCartItem SelectedShoppingCartItem { get; set; }
        public Product SelectedProduct { get; set; }

        private const string productsFile = "Products.csv";
        private const string sellRecordsFile = "SellRecords.csv";

        public MediaShop()
        {
            InitializeComponent();
            LoadProductsOnStart();
            SetupDataSources();
            searchFilterComboBox.SelectedIndex = 1; // The preset value for the searchfilter is "Namn".
            timePeriodComboBox.SelectedIndex = 0; // The preset value for the time period in statistics is "Total försäljning".
        }

        private void LoadProductsOnStart()
        {
            if (File.Exists(productsFile))
            {
                Stock.Products = FileManager.LoadProductsFromFile(productsFile);
                if (File.Exists(sellRecordsFile))
                    FileManager.LoadSellRecordsFromFile(Stock.Products, sellRecordsFile);
            }
        }

        private void SetupDataSources()
        {
            productsListBindingSource.DataSource = Stock.Products;
            productListDataGridView.DataSource = productsListBindingSource;
            productsListBox.DataSource = productsListBindingSource;
            availableProductsListBox.DataSource = productsListBindingSource;
            shoppingCartBindingSource.DataSource = CheckOut.ShoppingCart;
            shoppingCartDataGridView.DataSource = shoppingCartBindingSource;
            statisticsListBox.DataSource = productsListBindingSource;
            statisticsBindingSource.DataSource = Query.StatisticsResult;
            statisticsDataGridView.DataSource = statisticsBindingSource;
        }

        // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
        private void RefreshProductsDataGridVew()
        {
            productsListBindingSource.DataSource = null;
            productsListBindingSource.DataSource = Stock.Products;
        }

        // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
        private void RefreshShoppingCartDataGridView()
        {
            shoppingCartBindingSource.DataSource = null;
            shoppingCartBindingSource.DataSource = CheckOut.ShoppingCart;
        }

        private void AddProductToCartButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct) 
                || Validation.ProductAlreadyInShoppingCart(CheckOut.ShoppingCart, SelectedProduct))
                return;

            int amountToAdd = (int)amountToAddToCart.Value;

            if (Validation.AmountToAddIsZero(amountToAdd) || Validation.AmountIsLargerThanStockOfProduct(SelectedProduct, amountToAdd))
                return;

            CheckOut.AddProductToShoppingCart(SelectedProduct, amountToAdd);
            RefreshShoppingCartDataGridView();
            ShowOrderTotal();
        }

        private void ShowOrderTotal()
        {
            totalPriceTextBox.Text = CheckOut.OrderTotal.ToString();
        }

        private void IncreaseAmountOfItemButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart) || Validation.AllCopiesAlreadyAddedToShoppingCart(SelectedShoppingCartItem))
                return;

            CheckOut.IncreaseAmountOfItem(SelectedShoppingCartItem);
            shoppingCartDataGridView.Refresh();
            ShowOrderTotal();
        }

        private void DecreaseAmountOfItemButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart))
                return;

            if (SelectedShoppingCartItem.Amount - 1 == 0) // If there's only one copy of the item in the ShoppingCart, the item is removed enterily.
            {
                CheckOut.RemoveItem(SelectedShoppingCartItem);
                RefreshShoppingCartDataGridView();
            }
            else
            {
                CheckOut.DecreaseAmountOfItem(SelectedShoppingCartItem);
                shoppingCartDataGridView.Refresh();
            }
            ShowOrderTotal();
        }

        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart))
                return;

            CheckOut.RemoveItem(SelectedShoppingCartItem);
            RefreshShoppingCartDataGridView();
            ShowOrderTotal();
        }

        private void FinishOrderButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart))
                return;

            foreach (ShoppingCartItem item in CheckOut.ShoppingCart)
                Stock.SaleOfProduct(Stock.Products.First(x => x.Id == item.Id), item.Amount, DateTime.Now);
            CheckOut.FinishOrder();
            RefreshShoppingCartDataGridView();
            productListDataGridView.Refresh();
            ShowOrderTotal();
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            if (NewProductInputsAreInvalid())
                return;

            Stock.AddProduct(Convert.ToInt32(idTextBox.Text), nameTextBox.Text.Trim(), Convert.ToDouble(priceTextBox.Text), 
                                        typeTextBox.Text.Trim(), creatorTextBox.Text.Trim(), publisherTextBox.Text.Trim());
            RefreshProductsDataGridVew();
            resetSearchFilterButton.PerformClick();
        }

        // The users input is validated both upon leaving focus of each entry field as well as all togheter when clicking the AddProductButton.
        private bool NewProductInputsAreInvalid()
        {
            return IdInputIsInvalid(idTextBox.Text) 
                    || Validation.NameInputIsEmpty(nameTextBox.Text) 
                    || Validation.PriceInputIsNotAPositiveNumber(priceTextBox.Text) 
                    || Validation.TypeInputIsEmpty(typeTextBox.Text) 
                    || Validation.CreatorInputIsEmpty(creatorTextBox.Text) 
                    || Validation.PublisherInputIsEmpty(publisherTextBox.Text);
        }

        private bool IdInputIsInvalid(string input)
        {
            return Validation.IdInputIsNotAPositiveNumber(input) || Validation.IdInputIsAlreadyUsed(Convert.ToInt32(input), Stock.Products);
        }

        private void IdTextBox_Leave(object sender, EventArgs e)
        {
            IdInputIsInvalid((sender as TextBox).Text);
        }

        private void NameTextBox_Leave(object sender, EventArgs e)
        {
            Validation.NameInputIsEmpty((sender as TextBox).Text);
        }

        private void PriceTextBox_Leave(object sender, EventArgs e)
        {
            Validation.PriceInputIsNotAPositiveNumber((sender as TextBox).Text);
        }

        private void TypeTextBox_Leave(object sender, EventArgs e)
        {
            Validation.TypeInputIsEmpty((sender as TextBox).Text);
        }

        private void CreatorTextBox_Leave(object sender, EventArgs e)
        {
            Validation.CreatorInputIsEmpty((sender as TextBox).Text);
        }

        private void PublisherTextBox_Leave(object sender, EventArgs e)
        {
            Validation.PublisherInputIsEmpty((sender as TextBox).Text);
        }

        private void SaveDeliveryButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct)
                || Validation.AmountToDeliverIsZero((int)amountDelivered.Value))
                return;

            Stock.DeliveryOfProduct(SelectedProduct, (int)amountDelivered.Value);
            productListDataGridView.Refresh();
        }

        private void SaveReturnButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct)
                || Validation.AmountToReturnIsZero((int)amountReturned.Value) || Validation.NoSellsOfProductAtGivenDate(SelectedProduct, sellDateCalendar.SelectionRange.Start.Date)
                || Validation.AmountToReturnIsGreaterThanAmountSoldOnGivenDate(SelectedProduct, (int)amountReturned.Value, sellDateCalendar.SelectionRange.Start.Date))
                return;

            Stock.ReturnOfProduct(SelectedProduct, (int)amountReturned.Value, sellDateCalendar.SelectionRange.Start.Date);
            productListDataGridView.Refresh();
        }

        private void RemoveProductButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct)
                || Validation.ProductToRemoveIsInShoppingCart(SelectedProduct, CheckOut.ShoppingCart))
                return;

            if (SelectedProduct.NumberInStock > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Det finns exemplar av varan kvar i lagret. Är du säker på att du vill ta bort produkten ur systemet?",
                                "Varning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Cancel)
                    return;
            }

            Stock.RemoveProduct(SelectedProduct);
            RefreshProductsDataGridVew();
            resetSearchFilterButton.PerformClick();
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            FileManager.SaveProductsToFile(Stock.Products, productsFile);
            FileManager.SaveSellRecordsToFile(Stock.Products, sellRecordsFile);
        }

        private void ProductsListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedProduct = productsListBindingSource.Current as Product;
        }

        private void ShoppingCartBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedShoppingCartItem = shoppingCartBindingSource.Current as ShoppingCartItem;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            string searchFilter = searchFilterComboBox.Text;
            string searchTerm = searchTermTextBox.Text.Trim().ToLower();
            string minValue = searchAtLeastTextBox.Text;
            string maxValue = searchAtMostTextBox.Text;

            Query.CreateSearchResult(Stock.Products, searchFilter, searchTerm, minValue, maxValue);
            productsListBindingSource.DataSource = Query.SearchResult;
        }

        private void ResetSearchFilterButton_Click(object sender, EventArgs e)
        {
            productsListBindingSource.DataSource = Stock.Products;
            searchFilterComboBox.SelectedIndex = 1;
            searchTermTextBox.Text = "";
            searchTermTextBox.Enabled = true;
            searchAtMostTextBox.Text = "";
            searchAtMostTextBox.Enabled = false;
            searchAtLeastTextBox.Text = "";
            searchAtLeastTextBox.Enabled = false;
        }

        private void SearchFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchFilterComboBox.Text == "Varunummer" || searchFilterComboBox.Text == "Pris" || searchFilterComboBox.Text == "Lager" || searchFilterComboBox.Text == "Antal sålda")
            {
                searchTermTextBox.Enabled = false;
                searchAtMostTextBox.Enabled = true;
                searchAtLeastTextBox.Enabled = true;
            }
            else
            {
                searchTermTextBox.Enabled = true;
                searchAtMostTextBox.Enabled = false;
                searchAtLeastTextBox.Enabled = false;
            }
        }

        private void ShowItemStatisticsButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct))
                return;

            Query.CreateSingleItemResult(SelectedProduct);
            // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
            statisticsBindingSource.DataSource = null;
            statisticsBindingSource.DataSource = Query.StatisticsResult;
        }

        private void ShowTopSellersButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            Query.CreateTopSellersResult(Stock.Products, timePeriodComboBox.Text);
            // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
            statisticsBindingSource.DataSource = null;
            statisticsBindingSource.DataSource = Query.StatisticsResult;
        }

        private void ExportProductsButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            const string exportProductsFile = @"..\..\..\..\Laboration4\Laboration4\bin\Debug\frMediaShop\Products.csv";
            FileManager.SaveProductsToFile(Stock.Products, exportProductsFile);
        }

        private void ImportProductsButton_Click(object sender, EventArgs e)
        {
            const string importProductsFile = @"..\..\..\..\Laboration4\Laboration4\bin\Debug\tillMediaShop\Products.csv";

            if (Validation.NoImportFileFound(importProductsFile))
                return;

            Stock.Products = FileManager.LoadProductsFromFile(importProductsFile);
            RefreshProductsDataGridVew();
        }
    }
}