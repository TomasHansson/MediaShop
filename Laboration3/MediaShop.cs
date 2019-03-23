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

        private const string _productsFile = "Products.csv";
        private const string _sellRecordsFile = "SellRecords.csv";

        // These are used together with another project, a MediaIntegrator.
        private const string _exportProductsFile = @"..\..\..\..\Laboration4\Laboration4\bin\Debug\frMediaShop\Products.csv"; 
        private const string _importProductsFile = @"..\..\..\..\Laboration4\Laboration4\bin\Debug\tillMediaShop\Products.csv";

        // MediaShop: Constructor. Calls helper-functions used to setup the application.
        // Pre: -
        // Post: The specified helper-functions have been called.
        public MediaShop()
        {
            InitializeComponent();
            LoadProductsOnStart();
            SetupDataSources();
            SetupComboBoxes();
        }

        // LoadProductsOnStart: Checks if a list of products exists, and if so, loads them.
        // Pre: -
        // Post: If a file containing a saved list of products exists, they've been loaded into the Stock's list of Products.
        private void LoadProductsOnStart()
        {
            if (File.Exists(_productsFile))
            {
                Stock.Products = FileManager.LoadProductsFromFile(_productsFile);
                if (File.Exists(_sellRecordsFile))
                    FileManager.LoadSellRecordsFromFile(Stock.Products, _sellRecordsFile);
            }
        }

        // SetupDataSources: Sets up the datasource for all BindingSources, DataGridView and ListBoxes.
        // Pre: -
        // Post: All DataSources required by the application to function has been setup.
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

        // SetupComboBoxes: Sets the initial value selected by the applications ComboBoxes.
        // Pre: -
        // Post: The SelectedIndex (ie, the selection) of the applications ComboBoxes has been set to the specified values.
        private void SetupComboBoxes()
        {
            searchFilterComboBox.SelectedIndex = 1; // The preset value for the searchfilter is "Namn".
            timePeriodComboBox.SelectedIndex = 0; // The preset value for the time period in statistics is "Total försäljning".
        }

        // RefreshProductsDataGridVew: Refreshes the products DataGridView.
        // Pre: -
        // Post: The products DataGridView has been refreshed. 
        private void RefreshProductsDataGridVew()
        {
            // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
            productsListBindingSource.DataSource = null;
            productsListBindingSource.DataSource = Stock.Products;
        }

        // RefreshShoppingCartDataGridView: Refreshes the shoppingcart DataGridView.
        // Pre: -
        // Post: The shoppingcart DataGridView has been refreshed. 
        private void RefreshShoppingCartDataGridView()
        {
            // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
            shoppingCartBindingSource.DataSource = null;
            shoppingCartBindingSource.DataSource = CheckOut.ShoppingCart;
        }

        // A note on event-handlers (mostly button-clicks, but other as well) for this application:
        // 
        // Most event-handler-functions begins by calling functions in the static Validation-class. 
        // These functions tests for any possible error or faulty user input. If an issue is found, 
        // a message detailing the issue is shown through a messagebox and the function returns true.
        // If any such function returns true to the event-handler, the event-handler will exit with a 
        // return statement. 
        //
        // This ensures that the user cannot perform any faulty operations.
        // In the following documentation for this class, these checks won't be noted and the Post-information 
        // for all functions assumes that no issue was found by these checks.
        //
        // The actual functionality of most event-handlers are done by other classes, ie CheckOut (CheckOutManager), FileManager,
        // Query (QueryManager) and Stock (StockManager). See these classes for full implementation and documentation of operations.

        // AddProductToCartButton_Click: Adds the selected product to the shopping cart.
        // Pre: -
        // Post: The selected amount of items of the selected product has been added to the shopping cart.
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

        // ShowOrderTotal: Displays the current ordertotal for the items in the shopping cart.
        // Pre: -
        // Post: The totalPriceTextBox displays the current ordertotal for the items in the shopping cart.
        private void ShowOrderTotal()
        {
            totalPriceTextBox.Text = CheckOut.OrderTotal.ToString();
        }

        // IncreaseAmountOfItemButton_Click: Increases the amount of the selected item by one.
        // Pre: - 
        // Post: The amount of the selected item has been increased by one and the new ordertotal is displayed.
        private void IncreaseAmountOfItemButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart) || Validation.AllCopiesAlreadyAddedToShoppingCart(SelectedShoppingCartItem))
                return;

            CheckOut.IncreaseAmountOfItem(SelectedShoppingCartItem);
            shoppingCartDataGridView.Refresh();
            ShowOrderTotal();
        }

        // DecreaseAmountOfItemButton_Click: Decreases the amount of the selected item by one.
        // Pre: - 
        // Post: The amount of the selected item has been decreased by one and the new ordertotal is displayed.
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

        // RemoveItemButton_Click: Removes the amount of the selected item by one.
        // Pre: - 
        // Post: The selected item has been removed from the shopping cart and the new ordertotal is displayed.
        private void RemoveItemButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart))
                return;

            CheckOut.RemoveItem(SelectedShoppingCartItem);
            RefreshShoppingCartDataGridView();
            ShowOrderTotal();
        }

        // FinishOrderButton_Click: Completes the order by selling the products in the shopping cart.
        // Pre: -
        // Post: The user has been given the option to print a receipt and the order has been finalized,
        // emptying the shopping cart and showing the order total as 0.
        private void FinishOrderButton_Click(object sender, EventArgs e)
        {
            if (Validation.ShoppingCartIsEmpty(CheckOut.ShoppingCart))
                return;

            DialogResult dialogResult = MessageBox.Show("Vill du skriva ut ett kvitto för köpet?",
                "Kvitto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
                CheckOut.PrintReceipt();

            foreach (ShoppingCartItem item in CheckOut.ShoppingCart)
                Stock.SaleOfProduct(Stock.Products.First(x => x.Id == item.Id), item.Amount);

            CheckOut.ClearShoppingCart();

            RefreshShoppingCartDataGridView();
            productListDataGridView.Refresh();
            ShowOrderTotal();
        }

        // AddProductButton_Click: Adds a product to the list of available products based on the input supplied by the user.
        // Pre: -
        // Post: A new product based on the users input has been added to the list of available products. 
        // The search-filter has been reset.
        private void AddProductButton_Click(object sender, EventArgs e)
        {
            if (NewProductInputsAreInvalid())
                return;

            Stock.AddProduct(Convert.ToInt32(idTextBox.Text), nameTextBox.Text.Trim(), Convert.ToDouble(priceTextBox.Text), 
                                        typeTextBox.Text.Trim(), creatorTextBox.Text.Trim(), publisherTextBox.Text.Trim());
            RefreshProductsDataGridVew();
            resetSearchFilterButton.PerformClick();
        }

        // NewProductInputsAreInvalid: Checks all TextBoxes for a new product details to ensure that they hold valid input.
        // Pre: - 
        // Post: If any fields contains faulty input, a message box has been shown, alerting the user of the issue.
        private bool NewProductInputsAreInvalid()
        {
            return IdInputIsInvalid(idTextBox.Text) 
                    || Validation.NameInputIsEmpty(nameTextBox.Text) 
                    || Validation.PriceInputIsNotAPositiveNumber(priceTextBox.Text) 
                    || Validation.TypeInputIsEmpty(typeTextBox.Text) 
                    || Validation.CreatorInputIsEmpty(creatorTextBox.Text) 
                    || Validation.PublisherInputIsEmpty(publisherTextBox.Text);
        }

        // IdInputIsInvalid: Checks the given Id for a new product to ensure that it's valid.
        // Pre: -
        // Post: If any issue exists with the input, a message box has been shown, alerting the user of the issue.
        private bool IdInputIsInvalid(string input)
        {
            return Validation.IdInputIsNotAPositiveNumber(input) || Validation.IdInputIsAlreadyUsed(Convert.ToInt32(input), Stock.Products);
        }

        // The following TextBox_Leave-event-handlers all check for faulty input upon leaving focus of the respectivce TextBox.
        // If any issue exists with the input, a message box has been shown, alerting the user of the issue.
        // Note that the users input is validated both upon leaving focus of each entry field as well as all togheter when clicking the AddProductButton.
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

        // SaveDeliveryButton_Click: Records the delivery of a product.
        // Pre: -
        // Post: The stock of the selected product has been increased by the selected value.
        private void SaveDeliveryButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct)
                || Validation.AmountToDeliverIsZero((int)amountDelivered.Value))
                return;

            Stock.DeliveryOfProduct(SelectedProduct, (int)amountDelivered.Value);
            productListDataGridView.Refresh();
        }

        // SaveReturnButton_Click: Records the return of a previously sold item.
        // Pre: -
        // Post: The selected product has had its sell-records adjusted based on the given amount and date when
        // the product was previously sold.
        private void SaveReturnButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct)
                || Validation.AmountToReturnIsZero((int)amountReturned.Value) || Validation.NoSellsOfProductAtGivenDate(SelectedProduct, sellDateCalendar.SelectionRange.Start.Date)
                || Validation.AmountToReturnIsGreaterThanAmountSoldOnGivenDate(SelectedProduct, (int)amountReturned.Value, sellDateCalendar.SelectionRange.Start.Date))
                return;

            Stock.ReturnOfProduct(SelectedProduct, (int)amountReturned.Value, sellDateCalendar.SelectionRange.Start.Date);
            productListDataGridView.Refresh();
        }

        // RemoveProductButton_Click: Removes the selected product from the list of available products.
        // Pre: -
        // Post: If any copies of the product exists in stock, the user has had the opportunity to cancel the operation.
        // If they selected not to cancel, or if there's no copies in stock, the selected product has been removed from the 
        // list of available products.
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

        // SaveToFileButton_Click: Saves the list of available products to a file.
        // Pre: - 
        // Post: The list of available products have been saved to a file.
        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            FileManager.SaveProductsToFile(Stock.Products, _productsFile);
            FileManager.SaveSellRecordsToFile(Stock.Products, _sellRecordsFile);
        }

        // ProductsListBindingSource_CurrentChanged: Sets the SelectedProduct to the users selection in the GUI.
        // Pre: -
        // Post: SelectedProduct has been set to the product selected by the user.
        private void ProductsListBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedProduct = productsListBindingSource.Current as Product;
        }

        // ShoppingCartBindingSource_CurrentChanged: Sets the SelectedShoppingCartItem to the users selection in the GUI.
        // Pre: -
        // Post: SelectedShoppingCartItem has been set to the item selected by the user.
        private void ShoppingCartBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            SelectedShoppingCartItem = shoppingCartBindingSource.Current as ShoppingCartItem;
        }

        // SearchButton_Click: Performs a search of the available products based on the input supplied by the user.
        // Pre: -
        // Post: The list of available products shows the products that fits the search-criteria supplied by the user.
        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            string searchFilter = searchFilterComboBox.Text;
            string searchTerm = searchTermTextBox.Text.Trim().ToLower();

            // This means that any non-numeric input value is simply ignored. Since a faulty input here won't cause any errors in the program, error messages were omitted and a
            // default value (0 for the lower bound and double.MaxValue for the upper bound) is used instead.
            double minValue = double.TryParse(searchAtLeastTextBox.Text, out double minInput) ? minInput : 0;
            double maxValue = double.TryParse(searchAtMostTextBox.Text, out double maxInput) ? maxInput : double.MaxValue;

            Query.CreateSearchResult(Stock.Products, searchFilter, searchTerm, minValue, maxValue);
            productsListBindingSource.DataSource = Query.SearchResult;
        }

        // ResetSearchFilterButton_Click: Resets the search-filter.
        // Pre: - 
        // Post: All input for the search-filter has been reset to their initial values and the list of available products shows all products in the system.
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

        // SearchFilterComboBox_SelectedIndexChanged: Enables or disables input for the search-filter based on the type of search the user selected.
        // Pre: -
        // Post: The TextBox(es) related to the type of search the user specified has been enabled, while those that are not related has been disabled
        // (for example, searching by name requires a string but no numeric values).
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

        // ShowItemStatisticsButton_Click: Shows sell-statistics of the selected product.
        // Pre: -
        // Post: Sell-statistics for the selected product is shown in the statistics list.
        private void ShowItemStatisticsButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products) || Validation.NoProductIsSelected(SelectedProduct))
                return;

            Query.CreateSingleItemStatisticsResult(SelectedProduct);
            RefreshStatisticsDataGridView();
        }

        // ShowTopSellersButton_Click: Shows sell-statistics for the top-ten selling products for the selected timeperiod.
        // Pre: -
        // Post: Sell-statistics for the top-ten selling products for the selected timeperiod is shown in the statistics list.
        private void ShowTopSellersButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            Query.CreateTopSellersStatisticsResult(Stock.Products, timePeriodComboBox.Text);
            RefreshStatisticsDataGridView();
        }

        // RefreshStatisticsDataGridView: Refreshes the statistics DataGridView.
        // Pre: -
        // Post: The statistics DataGridView has been refreshed. 
        private void RefreshStatisticsDataGridView()
        {
            // By reseting the datasource for the bindingsource, the list is refreshed when items are added or removed.
            statisticsBindingSource.DataSource = null;
            statisticsBindingSource.DataSource = Query.StatisticsResult;
        }

        // ExportProductsButton_Click: Saves the list of available products to a file, to be used by the MediaIntegrator.
        // Pre: -
        // Post: The list of available products have been saved to a file, to be used by the MediaIntegrator.
        private void ExportProductsButton_Click(object sender, EventArgs e)
        {
            if (Validation.ProductsListIsEmpty(Stock.Products))
                return;

            FileManager.SaveProductsToFile(Stock.Products, _exportProductsFile);
        }

        // ImportProductsButton_Click: Loads a list of available products from a file, generated by the MediaIntegrator.
        // Pre: -
        // Post: The list of available products has been set to the list loaded from the file, which was generated by the MediaIntegrator.
        private void ImportProductsButton_Click(object sender, EventArgs e)
        {
            if (Validation.NoImportFileFound(_importProductsFile))
                return;

            Stock.Products = FileManager.LoadProductsFromFile(_importProductsFile);
            RefreshProductsDataGridVew();
        }
    }
}