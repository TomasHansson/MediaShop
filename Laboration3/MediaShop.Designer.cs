namespace Laboration3
{
    partial class MediaShop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.productListDataGridView = new System.Windows.Forms.DataGridView();
            this.stockTab = new System.Windows.Forms.TabPage();
            this.exportProductsButton = new System.Windows.Forms.Button();
            this.saveToFileButton = new System.Windows.Forms.Button();
            this.newProductPanel = new System.Windows.Forms.Panel();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.addProductButton = new System.Windows.Forms.Button();
            this.publisherTextBox = new System.Windows.Forms.TextBox();
            this.creatorLabel = new System.Windows.Forms.Label();
            this.creatorTextBox = new System.Windows.Forms.TextBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.saveDeliveryButton = new System.Windows.Forms.Button();
            this.amountDeliveredLabel = new System.Windows.Forms.Label();
            this.addDeliveryLabel = new System.Windows.Forms.Label();
            this.amountDelivered = new System.Windows.Forms.NumericUpDown();
            this.removeProductButton = new System.Windows.Forms.Button();
            this.availableProductsLabel = new System.Windows.Forms.Label();
            this.availableProductsListBox = new System.Windows.Forms.ListBox();
            this.checkOutTab = new System.Windows.Forms.TabPage();
            this.sellDateLabel = new System.Windows.Forms.Label();
            this.sellDateCalendar = new System.Windows.Forms.MonthCalendar();
            this.saveReturnButton = new System.Windows.Forms.Button();
            this.amountReturnedLabel = new System.Windows.Forms.Label();
            this.returnOfProductLabel = new System.Windows.Forms.Label();
            this.amountReturned = new System.Windows.Forms.NumericUpDown();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.decreaseAmountOfItemButton = new System.Windows.Forms.Button();
            this.increaseAmountOfItemButton = new System.Windows.Forms.Button();
            this.removeItemButton = new System.Windows.Forms.Button();
            this.shoppingCartDataGridView = new System.Windows.Forms.DataGridView();
            this.productsLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountToAddToCart = new System.Windows.Forms.NumericUpDown();
            this.addProductToCartButton = new System.Windows.Forms.Button();
            this.productsListBox = new System.Windows.Forms.ListBox();
            this.finishOrderButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.statisticsTab = new System.Windows.Forms.TabPage();
            this.showItemStatisticsButton = new System.Windows.Forms.Button();
            this.timePeriodComboBox = new System.Windows.Forms.ComboBox();
            this.showTopSellersButton = new System.Windows.Forms.Button();
            this.topSellersLabel = new System.Windows.Forms.Label();
            this.statisticsOfProductLabel = new System.Windows.Forms.Label();
            this.statisticsListBox = new System.Windows.Forms.ListBox();
            this.statisticsDataGridView = new System.Windows.Forms.DataGridView();
            this.productsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shoppingCartBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.searchFilterComboBox = new System.Windows.Forms.ComboBox();
            this.searchTermTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.resetSearchFilterButton = new System.Windows.Forms.Button();
            this.searchAtLeastTextBox = new System.Windows.Forms.TextBox();
            this.searchAtMostTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchAtLeastLabel = new System.Windows.Forms.Label();
            this.searchAtMostLabel = new System.Windows.Forms.Label();
            this.searchInformationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.importProductsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productListDataGridView)).BeginInit();
            this.stockTab.SuspendLayout();
            this.newProductPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountDelivered)).BeginInit();
            this.checkOutTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountReturned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountToAddToCart)).BeginInit();
            this.tabControl.SuspendLayout();
            this.statisticsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productListDataGridView
            // 
            this.productListDataGridView.AllowUserToAddRows = false;
            this.productListDataGridView.AllowUserToDeleteRows = false;
            this.productListDataGridView.AllowUserToResizeRows = false;
            this.productListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.productListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.productListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.productListDataGridView.Location = new System.Drawing.Point(0, 450);
            this.productListDataGridView.MultiSelect = false;
            this.productListDataGridView.Name = "productListDataGridView";
            this.productListDataGridView.ReadOnly = true;
            this.productListDataGridView.RowHeadersVisible = false;
            this.productListDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.productListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productListDataGridView.Size = new System.Drawing.Size(1111, 278);
            this.productListDataGridView.TabIndex = 1;
            // 
            // stockTab
            // 
            this.stockTab.Controls.Add(this.importProductsButton);
            this.stockTab.Controls.Add(this.exportProductsButton);
            this.stockTab.Controls.Add(this.saveToFileButton);
            this.stockTab.Controls.Add(this.newProductPanel);
            this.stockTab.Controls.Add(this.saveDeliveryButton);
            this.stockTab.Controls.Add(this.amountDeliveredLabel);
            this.stockTab.Controls.Add(this.addDeliveryLabel);
            this.stockTab.Controls.Add(this.amountDelivered);
            this.stockTab.Controls.Add(this.removeProductButton);
            this.stockTab.Controls.Add(this.availableProductsLabel);
            this.stockTab.Controls.Add(this.availableProductsListBox);
            this.stockTab.Location = new System.Drawing.Point(4, 22);
            this.stockTab.Name = "stockTab";
            this.stockTab.Padding = new System.Windows.Forms.Padding(3);
            this.stockTab.Size = new System.Drawing.Size(1256, 422);
            this.stockTab.TabIndex = 1;
            this.stockTab.Text = "Lager";
            this.stockTab.UseVisualStyleBackColor = true;
            // 
            // exportProductsButton
            // 
            this.exportProductsButton.Location = new System.Drawing.Point(898, 382);
            this.exportProductsButton.Name = "exportProductsButton";
            this.exportProductsButton.Size = new System.Drawing.Size(139, 23);
            this.exportProductsButton.TabIndex = 19;
            this.exportProductsButton.Text = "Exportera produktregister";
            this.exportProductsButton.UseVisualStyleBackColor = true;
            this.exportProductsButton.Click += new System.EventHandler(this.ExportProductsButton_Click);
            // 
            // saveToFileButton
            // 
            this.saveToFileButton.Location = new System.Drawing.Point(782, 382);
            this.saveToFileButton.Name = "saveToFileButton";
            this.saveToFileButton.Size = new System.Drawing.Size(113, 23);
            this.saveToFileButton.TabIndex = 18;
            this.saveToFileButton.Text = "Spara produktlistan";
            this.saveToFileButton.UseVisualStyleBackColor = true;
            this.saveToFileButton.Click += new System.EventHandler(this.SaveToFileButton_Click);
            // 
            // newProductPanel
            // 
            this.newProductPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.newProductPanel.Controls.Add(this.publisherLabel);
            this.newProductPanel.Controls.Add(this.addProductButton);
            this.newProductPanel.Controls.Add(this.publisherTextBox);
            this.newProductPanel.Controls.Add(this.creatorLabel);
            this.newProductPanel.Controls.Add(this.creatorTextBox);
            this.newProductPanel.Controls.Add(this.typeLabel);
            this.newProductPanel.Controls.Add(this.typeTextBox);
            this.newProductPanel.Controls.Add(this.priceLabel);
            this.newProductPanel.Controls.Add(this.priceTextBox);
            this.newProductPanel.Controls.Add(this.nameLabel);
            this.newProductPanel.Controls.Add(this.nameTextBox);
            this.newProductPanel.Controls.Add(this.idLabel);
            this.newProductPanel.Controls.Add(this.idTextBox);
            this.newProductPanel.Location = new System.Drawing.Point(219, 35);
            this.newProductPanel.Name = "newProductPanel";
            this.newProductPanel.Size = new System.Drawing.Size(554, 302);
            this.newProductPanel.TabIndex = 16;
            // 
            // publisherLabel
            // 
            this.publisherLabel.AutoSize = true;
            this.publisherLabel.Location = new System.Drawing.Point(43, 216);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(47, 13);
            this.publisherLabel.TabIndex = 11;
            this.publisherLabel.Text = "Utgivare";
            // 
            // addProductButton
            // 
            this.addProductButton.Location = new System.Drawing.Point(46, 265);
            this.addProductButton.Name = "addProductButton";
            this.addProductButton.Size = new System.Drawing.Size(90, 23);
            this.addProductButton.TabIndex = 17;
            this.addProductButton.Text = "Lägg till produkt";
            this.addProductButton.UseVisualStyleBackColor = true;
            this.addProductButton.Click += new System.EventHandler(this.AddProductButton_Click);
            // 
            // publisherTextBox
            // 
            this.publisherTextBox.Location = new System.Drawing.Point(46, 232);
            this.publisherTextBox.Name = "publisherTextBox";
            this.publisherTextBox.Size = new System.Drawing.Size(465, 20);
            this.publisherTextBox.TabIndex = 10;
            this.publisherTextBox.Leave += new System.EventHandler(this.PublisherTextBox_Leave);
            // 
            // creatorLabel
            // 
            this.creatorLabel.AutoSize = true;
            this.creatorLabel.Location = new System.Drawing.Point(43, 177);
            this.creatorLabel.Name = "creatorLabel";
            this.creatorLabel.Size = new System.Drawing.Size(47, 13);
            this.creatorLabel.TabIndex = 9;
            this.creatorLabel.Text = "Skapare";
            // 
            // creatorTextBox
            // 
            this.creatorTextBox.Location = new System.Drawing.Point(46, 193);
            this.creatorTextBox.Name = "creatorTextBox";
            this.creatorTextBox.Size = new System.Drawing.Size(465, 20);
            this.creatorTextBox.TabIndex = 8;
            this.creatorTextBox.Leave += new System.EventHandler(this.CreatorTextBox_Leave);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(43, 138);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(43, 13);
            this.typeLabel.TabIndex = 7;
            this.typeLabel.Text = "Varutyp";
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(46, 154);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(465, 20);
            this.typeTextBox.TabIndex = 6;
            this.typeTextBox.Leave += new System.EventHandler(this.TypeTextBox_Leave);
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(43, 99);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(24, 13);
            this.priceLabel.TabIndex = 5;
            this.priceLabel.Text = "Pris";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(46, 115);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(465, 20);
            this.priceTextBox.TabIndex = 4;
            this.priceTextBox.Leave += new System.EventHandler(this.PriceTextBox_Leave);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(43, 60);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Namn";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(46, 76);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(465, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Leave += new System.EventHandler(this.NameTextBox_Leave);
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(43, 21);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(66, 13);
            this.idLabel.TabIndex = 1;
            this.idLabel.Text = "Varunummer";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(46, 37);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(465, 20);
            this.idTextBox.TabIndex = 0;
            this.idTextBox.Leave += new System.EventHandler(this.IdTextBox_Leave);
            // 
            // saveDeliveryButton
            // 
            this.saveDeliveryButton.Location = new System.Drawing.Point(265, 382);
            this.saveDeliveryButton.Name = "saveDeliveryButton";
            this.saveDeliveryButton.Size = new System.Drawing.Size(139, 23);
            this.saveDeliveryButton.TabIndex = 15;
            this.saveDeliveryButton.Text = "Spara leverans";
            this.saveDeliveryButton.UseVisualStyleBackColor = true;
            this.saveDeliveryButton.Click += new System.EventHandler(this.SaveDeliveryButton_Click);
            // 
            // amountDeliveredLabel
            // 
            this.amountDeliveredLabel.AutoSize = true;
            this.amountDeliveredLabel.Location = new System.Drawing.Point(346, 358);
            this.amountDeliveredLabel.Name = "amountDeliveredLabel";
            this.amountDeliveredLabel.Size = new System.Drawing.Size(58, 13);
            this.amountDeliveredLabel.TabIndex = 14;
            this.amountDeliveredLabel.Text = "Ange antal";
            // 
            // addDeliveryLabel
            // 
            this.addDeliveryLabel.AutoSize = true;
            this.addDeliveryLabel.Location = new System.Drawing.Point(265, 340);
            this.addDeliveryLabel.Name = "addDeliveryLabel";
            this.addDeliveryLabel.Size = new System.Drawing.Size(124, 13);
            this.addDeliveryLabel.TabIndex = 13;
            this.addDeliveryLabel.Text = "Lägg in leverans av vara";
            // 
            // amountDelivered
            // 
            this.amountDelivered.Location = new System.Drawing.Point(265, 356);
            this.amountDelivered.Name = "amountDelivered";
            this.amountDelivered.Size = new System.Drawing.Size(75, 20);
            this.amountDelivered.TabIndex = 12;
            // 
            // removeProductButton
            // 
            this.removeProductButton.Location = new System.Drawing.Point(782, 353);
            this.removeProductButton.Name = "removeProductButton";
            this.removeProductButton.Size = new System.Drawing.Size(113, 23);
            this.removeProductButton.TabIndex = 11;
            this.removeProductButton.Text = "Ta bort produkt";
            this.removeProductButton.UseVisualStyleBackColor = true;
            this.removeProductButton.Click += new System.EventHandler(this.RemoveProductButton_Click);
            // 
            // availableProductsLabel
            // 
            this.availableProductsLabel.AutoSize = true;
            this.availableProductsLabel.Location = new System.Drawing.Point(779, 18);
            this.availableProductsLabel.Name = "availableProductsLabel";
            this.availableProductsLabel.Size = new System.Drawing.Size(108, 13);
            this.availableProductsLabel.TabIndex = 10;
            this.availableProductsLabel.Text = "Tillgängliga produkter";
            // 
            // availableProductsListBox
            // 
            this.availableProductsListBox.FormattingEnabled = true;
            this.availableProductsListBox.Location = new System.Drawing.Point(779, 34);
            this.availableProductsListBox.Name = "availableProductsListBox";
            this.availableProductsListBox.Size = new System.Drawing.Size(258, 303);
            this.availableProductsListBox.TabIndex = 9;
            // 
            // checkOutTab
            // 
            this.checkOutTab.Controls.Add(this.sellDateLabel);
            this.checkOutTab.Controls.Add(this.sellDateCalendar);
            this.checkOutTab.Controls.Add(this.saveReturnButton);
            this.checkOutTab.Controls.Add(this.amountReturnedLabel);
            this.checkOutTab.Controls.Add(this.returnOfProductLabel);
            this.checkOutTab.Controls.Add(this.amountReturned);
            this.checkOutTab.Controls.Add(this.totalPriceLabel);
            this.checkOutTab.Controls.Add(this.totalPriceTextBox);
            this.checkOutTab.Controls.Add(this.decreaseAmountOfItemButton);
            this.checkOutTab.Controls.Add(this.increaseAmountOfItemButton);
            this.checkOutTab.Controls.Add(this.removeItemButton);
            this.checkOutTab.Controls.Add(this.shoppingCartDataGridView);
            this.checkOutTab.Controls.Add(this.productsLabel);
            this.checkOutTab.Controls.Add(this.amountLabel);
            this.checkOutTab.Controls.Add(this.amountToAddToCart);
            this.checkOutTab.Controls.Add(this.addProductToCartButton);
            this.checkOutTab.Controls.Add(this.productsListBox);
            this.checkOutTab.Controls.Add(this.finishOrderButton);
            this.checkOutTab.Location = new System.Drawing.Point(4, 22);
            this.checkOutTab.Name = "checkOutTab";
            this.checkOutTab.Padding = new System.Windows.Forms.Padding(3);
            this.checkOutTab.Size = new System.Drawing.Size(1256, 422);
            this.checkOutTab.TabIndex = 0;
            this.checkOutTab.Text = "Kassa";
            this.checkOutTab.UseVisualStyleBackColor = true;
            // 
            // sellDateLabel
            // 
            this.sellDateLabel.AutoSize = true;
            this.sellDateLabel.Location = new System.Drawing.Point(975, 56);
            this.sellDateLabel.Name = "sellDateLabel";
            this.sellDateLabel.Size = new System.Drawing.Size(142, 13);
            this.sellDateLabel.TabIndex = 30;
            this.sellDateLabel.Text = "Ange datum då varan såldes";
            // 
            // sellDateCalendar
            // 
            this.sellDateCalendar.Location = new System.Drawing.Point(964, 68);
            this.sellDateCalendar.MaxSelectionCount = 1;
            this.sellDateCalendar.Name = "sellDateCalendar";
            this.sellDateCalendar.ShowToday = false;
            this.sellDateCalendar.ShowTodayCircle = false;
            this.sellDateCalendar.TabIndex = 29;
            // 
            // saveReturnButton
            // 
            this.saveReturnButton.Location = new System.Drawing.Point(978, 271);
            this.saveReturnButton.Name = "saveReturnButton";
            this.saveReturnButton.Size = new System.Drawing.Size(139, 23);
            this.saveReturnButton.TabIndex = 28;
            this.saveReturnButton.Text = "Spara retur";
            this.saveReturnButton.UseVisualStyleBackColor = true;
            this.saveReturnButton.Click += new System.EventHandler(this.SaveReturnButton_Click);
            // 
            // amountReturnedLabel
            // 
            this.amountReturnedLabel.AutoSize = true;
            this.amountReturnedLabel.Location = new System.Drawing.Point(975, 229);
            this.amountReturnedLabel.Name = "amountReturnedLabel";
            this.amountReturnedLabel.Size = new System.Drawing.Size(202, 13);
            this.amountReturnedLabel.TabIndex = 27;
            this.amountReturnedLabel.Text = "Ange hur många exemplar som returneras";
            // 
            // returnOfProductLabel
            // 
            this.returnOfProductLabel.AutoSize = true;
            this.returnOfProductLabel.Location = new System.Drawing.Point(1045, 37);
            this.returnOfProductLabel.Name = "returnOfProductLabel";
            this.returnOfProductLabel.Size = new System.Drawing.Size(72, 13);
            this.returnOfProductLabel.TabIndex = 26;
            this.returnOfProductLabel.Text = "Retur av vara";
            // 
            // amountReturned
            // 
            this.amountReturned.Location = new System.Drawing.Point(978, 245);
            this.amountReturned.Name = "amountReturned";
            this.amountReturned.Size = new System.Drawing.Size(75, 20);
            this.amountReturned.TabIndex = 25;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(106, 376);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(72, 13);
            this.totalPriceLabel.TabIndex = 24;
            this.totalPriceLabel.Text = "Total kostnad";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Enabled = false;
            this.totalPriceTextBox.Location = new System.Drawing.Point(109, 391);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.Size = new System.Drawing.Size(113, 20);
            this.totalPriceTextBox.TabIndex = 23;
            this.totalPriceTextBox.Text = "0";
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // decreaseAmountOfItemButton
            // 
            this.decreaseAmountOfItemButton.Location = new System.Drawing.Point(189, 350);
            this.decreaseAmountOfItemButton.Name = "decreaseAmountOfItemButton";
            this.decreaseAmountOfItemButton.Size = new System.Drawing.Size(75, 23);
            this.decreaseAmountOfItemButton.TabIndex = 22;
            this.decreaseAmountOfItemButton.Text = "Minska antal";
            this.decreaseAmountOfItemButton.UseVisualStyleBackColor = true;
            this.decreaseAmountOfItemButton.Click += new System.EventHandler(this.DecreaseAmountOfItemButton_Click);
            // 
            // increaseAmountOfItemButton
            // 
            this.increaseAmountOfItemButton.Location = new System.Drawing.Point(108, 350);
            this.increaseAmountOfItemButton.Name = "increaseAmountOfItemButton";
            this.increaseAmountOfItemButton.Size = new System.Drawing.Size(75, 23);
            this.increaseAmountOfItemButton.TabIndex = 21;
            this.increaseAmountOfItemButton.Text = "Öka antal";
            this.increaseAmountOfItemButton.UseVisualStyleBackColor = true;
            this.increaseAmountOfItemButton.Click += new System.EventHandler(this.IncreaseAmountOfItemButton_Click);
            // 
            // removeItemButton
            // 
            this.removeItemButton.Location = new System.Drawing.Point(270, 350);
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(75, 23);
            this.removeItemButton.TabIndex = 20;
            this.removeItemButton.Text = "Ta bort vara";
            this.removeItemButton.UseVisualStyleBackColor = true;
            this.removeItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
            // 
            // shoppingCartDataGridView
            // 
            this.shoppingCartDataGridView.AllowUserToAddRows = false;
            this.shoppingCartDataGridView.AllowUserToDeleteRows = false;
            this.shoppingCartDataGridView.AllowUserToResizeRows = false;
            this.shoppingCartDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.shoppingCartDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.shoppingCartDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.shoppingCartDataGridView.Location = new System.Drawing.Point(109, 28);
            this.shoppingCartDataGridView.MultiSelect = false;
            this.shoppingCartDataGridView.Name = "shoppingCartDataGridView";
            this.shoppingCartDataGridView.ReadOnly = true;
            this.shoppingCartDataGridView.RowHeadersVisible = false;
            this.shoppingCartDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.shoppingCartDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shoppingCartDataGridView.Size = new System.Drawing.Size(607, 316);
            this.shoppingCartDataGridView.TabIndex = 19;
            // 
            // productsLabel
            // 
            this.productsLabel.AutoSize = true;
            this.productsLabel.Location = new System.Drawing.Point(722, 9);
            this.productsLabel.Name = "productsLabel";
            this.productsLabel.Size = new System.Drawing.Size(166, 13);
            this.productsLabel.TabIndex = 18;
            this.productsLabel.Text = "Välj varor att placera i varukorgen";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(722, 347);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(58, 13);
            this.amountLabel.TabIndex = 17;
            this.amountLabel.Text = "Ange antal";
            // 
            // amountToAddToCart
            // 
            this.amountToAddToCart.Location = new System.Drawing.Point(722, 363);
            this.amountToAddToCart.Name = "amountToAddToCart";
            this.amountToAddToCart.Size = new System.Drawing.Size(176, 20);
            this.amountToAddToCart.TabIndex = 16;
            // 
            // addProductToCartButton
            // 
            this.addProductToCartButton.Location = new System.Drawing.Point(722, 389);
            this.addProductToCartButton.Name = "addProductToCartButton";
            this.addProductToCartButton.Size = new System.Drawing.Size(176, 23);
            this.addProductToCartButton.TabIndex = 15;
            this.addProductToCartButton.Text = "Lägg till varan i varukorgen";
            this.addProductToCartButton.UseVisualStyleBackColor = true;
            this.addProductToCartButton.Click += new System.EventHandler(this.AddProductToCartButton_Click);
            // 
            // productsListBox
            // 
            this.productsListBox.FormattingEnabled = true;
            this.productsListBox.Location = new System.Drawing.Point(722, 28);
            this.productsListBox.Name = "productsListBox";
            this.productsListBox.Size = new System.Drawing.Size(176, 316);
            this.productsListBox.TabIndex = 14;
            // 
            // finishOrderButton
            // 
            this.finishOrderButton.Location = new System.Drawing.Point(232, 389);
            this.finishOrderButton.Name = "finishOrderButton";
            this.finishOrderButton.Size = new System.Drawing.Size(113, 23);
            this.finishOrderButton.TabIndex = 13;
            this.finishOrderButton.Text = "Genomför köp";
            this.finishOrderButton.UseVisualStyleBackColor = true;
            this.finishOrderButton.Click += new System.EventHandler(this.FinishOrderButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.checkOutTab);
            this.tabControl.Controls.Add(this.stockTab);
            this.tabControl.Controls.Add(this.statisticsTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1264, 448);
            this.tabControl.TabIndex = 0;
            // 
            // statisticsTab
            // 
            this.statisticsTab.Controls.Add(this.showItemStatisticsButton);
            this.statisticsTab.Controls.Add(this.timePeriodComboBox);
            this.statisticsTab.Controls.Add(this.showTopSellersButton);
            this.statisticsTab.Controls.Add(this.topSellersLabel);
            this.statisticsTab.Controls.Add(this.statisticsOfProductLabel);
            this.statisticsTab.Controls.Add(this.statisticsListBox);
            this.statisticsTab.Controls.Add(this.statisticsDataGridView);
            this.statisticsTab.Location = new System.Drawing.Point(4, 22);
            this.statisticsTab.Name = "statisticsTab";
            this.statisticsTab.Padding = new System.Windows.Forms.Padding(3);
            this.statisticsTab.Size = new System.Drawing.Size(1256, 422);
            this.statisticsTab.TabIndex = 2;
            this.statisticsTab.Text = "Statistik";
            this.statisticsTab.UseVisualStyleBackColor = true;
            // 
            // showItemStatisticsButton
            // 
            this.showItemStatisticsButton.Location = new System.Drawing.Point(763, 368);
            this.showItemStatisticsButton.Name = "showItemStatisticsButton";
            this.showItemStatisticsButton.Size = new System.Drawing.Size(176, 23);
            this.showItemStatisticsButton.TabIndex = 27;
            this.showItemStatisticsButton.Text = "Visa produktens säljstatistik";
            this.showItemStatisticsButton.UseVisualStyleBackColor = true;
            this.showItemStatisticsButton.Click += new System.EventHandler(this.ShowItemStatisticsButton_Click);
            // 
            // timePeriodComboBox
            // 
            this.timePeriodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timePeriodComboBox.FormattingEnabled = true;
            this.timePeriodComboBox.Items.AddRange(new object[] {
            "Total försäljning",
            "Senaste året",
            "Senaste månaden"});
            this.timePeriodComboBox.Location = new System.Drawing.Point(986, 54);
            this.timePeriodComboBox.Name = "timePeriodComboBox";
            this.timePeriodComboBox.Size = new System.Drawing.Size(121, 21);
            this.timePeriodComboBox.TabIndex = 26;
            // 
            // showTopSellersButton
            // 
            this.showTopSellersButton.Location = new System.Drawing.Point(986, 81);
            this.showTopSellersButton.Name = "showTopSellersButton";
            this.showTopSellersButton.Size = new System.Drawing.Size(121, 23);
            this.showTopSellersButton.TabIndex = 25;
            this.showTopSellersButton.Text = "Visa toppsäljare";
            this.showTopSellersButton.UseVisualStyleBackColor = true;
            this.showTopSellersButton.Click += new System.EventHandler(this.ShowTopSellersButton_Click);
            // 
            // topSellersLabel
            // 
            this.topSellersLabel.AutoSize = true;
            this.topSellersLabel.Location = new System.Drawing.Point(969, 29);
            this.topSellersLabel.Name = "topSellersLabel";
            this.topSellersLabel.Size = new System.Drawing.Size(162, 13);
            this.topSellersLabel.TabIndex = 24;
            this.topSellersLabel.Text = "Visa topp 10 inom vald tidsperiod";
            // 
            // statisticsOfProductLabel
            // 
            this.statisticsOfProductLabel.AutoSize = true;
            this.statisticsOfProductLabel.Location = new System.Drawing.Point(764, 29);
            this.statisticsOfProductLabel.Name = "statisticsOfProductLabel";
            this.statisticsOfProductLabel.Size = new System.Drawing.Size(175, 13);
            this.statisticsOfProductLabel.TabIndex = 22;
            this.statisticsOfProductLabel.Text = "Välj en produkt att se säljstatistik för";
            // 
            // statisticsListBox
            // 
            this.statisticsListBox.FormattingEnabled = true;
            this.statisticsListBox.Location = new System.Drawing.Point(763, 45);
            this.statisticsListBox.Name = "statisticsListBox";
            this.statisticsListBox.Size = new System.Drawing.Size(176, 316);
            this.statisticsListBox.TabIndex = 21;
            // 
            // statisticsDataGridView
            // 
            this.statisticsDataGridView.AllowUserToAddRows = false;
            this.statisticsDataGridView.AllowUserToDeleteRows = false;
            this.statisticsDataGridView.AllowUserToResizeRows = false;
            this.statisticsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.statisticsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.statisticsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.statisticsDataGridView.Location = new System.Drawing.Point(150, 45);
            this.statisticsDataGridView.MultiSelect = false;
            this.statisticsDataGridView.Name = "statisticsDataGridView";
            this.statisticsDataGridView.ReadOnly = true;
            this.statisticsDataGridView.RowHeadersVisible = false;
            this.statisticsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.statisticsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.statisticsDataGridView.Size = new System.Drawing.Size(607, 316);
            this.statisticsDataGridView.TabIndex = 20;
            // 
            // productsListBindingSource
            // 
            this.productsListBindingSource.CurrentChanged += new System.EventHandler(this.ProductsListBindingSource_CurrentChanged);
            // 
            // shoppingCartBindingSource
            // 
            this.shoppingCartBindingSource.CurrentChanged += new System.EventHandler(this.ShoppingCartBindingSource_CurrentChanged);
            // 
            // searchFilterComboBox
            // 
            this.searchFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchFilterComboBox.FormattingEnabled = true;
            this.searchFilterComboBox.Items.AddRange(new object[] {
            "Varunummer",
            "Namn",
            "Pris",
            "Varutyp",
            "Skapare",
            "Utgivare",
            "Lager",
            "Antal sålda"});
            this.searchFilterComboBox.Location = new System.Drawing.Point(1117, 476);
            this.searchFilterComboBox.Name = "searchFilterComboBox";
            this.searchFilterComboBox.Size = new System.Drawing.Size(143, 21);
            this.searchFilterComboBox.TabIndex = 2;
            this.searchFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchFilterComboBox_SelectedIndexChanged);
            // 
            // searchTermTextBox
            // 
            this.searchTermTextBox.Location = new System.Drawing.Point(1117, 526);
            this.searchTermTextBox.MaxLength = 15;
            this.searchTermTextBox.Name = "searchTermTextBox";
            this.searchTermTextBox.Size = new System.Drawing.Size(143, 20);
            this.searchTermTextBox.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(1117, 613);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(143, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Sök";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // resetSearchFilterButton
            // 
            this.resetSearchFilterButton.Location = new System.Drawing.Point(1117, 651);
            this.resetSearchFilterButton.Name = "resetSearchFilterButton";
            this.resetSearchFilterButton.Size = new System.Drawing.Size(143, 23);
            this.resetSearchFilterButton.TabIndex = 5;
            this.resetSearchFilterButton.Text = "Nollställ sökfilter";
            this.resetSearchFilterButton.UseVisualStyleBackColor = true;
            this.resetSearchFilterButton.Click += new System.EventHandler(this.ResetSearchFilterButton_Click);
            // 
            // searchAtLeastTextBox
            // 
            this.searchAtLeastTextBox.Enabled = false;
            this.searchAtLeastTextBox.Location = new System.Drawing.Point(1117, 577);
            this.searchAtLeastTextBox.MaxLength = 8;
            this.searchAtLeastTextBox.Name = "searchAtLeastTextBox";
            this.searchAtLeastTextBox.Size = new System.Drawing.Size(71, 20);
            this.searchAtLeastTextBox.TabIndex = 6;
            // 
            // searchAtMostTextBox
            // 
            this.searchAtMostTextBox.Enabled = false;
            this.searchAtMostTextBox.Location = new System.Drawing.Point(1189, 577);
            this.searchAtMostTextBox.MaxLength = 8;
            this.searchAtMostTextBox.Name = "searchAtMostTextBox";
            this.searchAtMostTextBox.Size = new System.Drawing.Size(71, 20);
            this.searchAtMostTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1117, 460);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Ange sökfilter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1117, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sökterm";
            // 
            // searchAtLeastLabel
            // 
            this.searchAtLeastLabel.AutoSize = true;
            this.searchAtLeastLabel.Location = new System.Drawing.Point(1117, 561);
            this.searchAtLeastLabel.Name = "searchAtLeastLabel";
            this.searchAtLeastLabel.Size = new System.Drawing.Size(33, 13);
            this.searchAtLeastLabel.TabIndex = 10;
            this.searchAtLeastLabel.Text = "Lägst";
            // 
            // searchAtMostLabel
            // 
            this.searchAtMostLabel.AutoSize = true;
            this.searchAtMostLabel.Location = new System.Drawing.Point(1186, 561);
            this.searchAtMostLabel.Name = "searchAtMostLabel";
            this.searchAtMostLabel.Size = new System.Drawing.Size(35, 13);
            this.searchAtMostLabel.TabIndex = 11;
            this.searchAtMostLabel.Text = "Högst";
            // 
            // searchInformationLabel
            // 
            this.searchInformationLabel.AutoSize = true;
            this.searchInformationLabel.Location = new System.Drawing.Point(1114, 691);
            this.searchInformationLabel.Name = "searchInformationLabel";
            this.searchInformationLabel.Size = new System.Drawing.Size(145, 13);
            this.searchInformationLabel.TabIndex = 12;
            this.searchInformationLabel.Text = "Filtret nollställs om en produkt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1111, 707);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "tas bort eller läggs till i systemet.";
            // 
            // importProductsButton
            // 
            this.importProductsButton.Location = new System.Drawing.Point(898, 353);
            this.importProductsButton.Name = "importProductsButton";
            this.importProductsButton.Size = new System.Drawing.Size(139, 23);
            this.importProductsButton.TabIndex = 20;
            this.importProductsButton.Text = "Importera produktregister";
            this.importProductsButton.UseVisualStyleBackColor = true;
            this.importProductsButton.Click += new System.EventHandler(this.ImportProductsButton_Click);
            // 
            // MediaShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 729);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchInformationLabel);
            this.Controls.Add(this.searchAtMostLabel);
            this.Controls.Add(this.searchAtLeastLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchAtMostTextBox);
            this.Controls.Add(this.searchAtLeastTextBox);
            this.Controls.Add(this.resetSearchFilterButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTermTextBox);
            this.Controls.Add(this.searchFilterComboBox);
            this.Controls.Add(this.productListDataGridView);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 768);
            this.MinimumSize = new System.Drawing.Size(1280, 768);
            this.Name = "MediaShop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MediaShop";
            ((System.ComponentModel.ISupportInitialize)(this.productListDataGridView)).EndInit();
            this.stockTab.ResumeLayout(false);
            this.stockTab.PerformLayout();
            this.newProductPanel.ResumeLayout(false);
            this.newProductPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountDelivered)).EndInit();
            this.checkOutTab.ResumeLayout(false);
            this.checkOutTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.amountReturned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountToAddToCart)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.statisticsTab.ResumeLayout(false);
            this.statisticsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoppingCartBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productListDataGridView;
        private System.Windows.Forms.TabPage stockTab;
        private System.Windows.Forms.TabPage checkOutTab;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.BindingSource productsListBindingSource;
        private System.Windows.Forms.Button addProductButton;
        private System.Windows.Forms.Panel newProductPanel;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.TextBox publisherTextBox;
        private System.Windows.Forms.Label creatorLabel;
        private System.Windows.Forms.TextBox creatorTextBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Button saveDeliveryButton;
        private System.Windows.Forms.Label amountDeliveredLabel;
        private System.Windows.Forms.Label addDeliveryLabel;
        private System.Windows.Forms.NumericUpDown amountDelivered;
        private System.Windows.Forms.Button removeProductButton;
        private System.Windows.Forms.Label availableProductsLabel;
        private System.Windows.Forms.ListBox availableProductsListBox;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Button decreaseAmountOfItemButton;
        private System.Windows.Forms.Button increaseAmountOfItemButton;
        private System.Windows.Forms.Button removeItemButton;
        private System.Windows.Forms.DataGridView shoppingCartDataGridView;
        private System.Windows.Forms.Label productsLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.NumericUpDown amountToAddToCart;
        private System.Windows.Forms.Button addProductToCartButton;
        private System.Windows.Forms.ListBox productsListBox;
        private System.Windows.Forms.Button finishOrderButton;
        private System.Windows.Forms.BindingSource shoppingCartBindingSource;
        private System.Windows.Forms.Button saveToFileButton;
        private System.Windows.Forms.Button saveReturnButton;
        private System.Windows.Forms.Label amountReturnedLabel;
        private System.Windows.Forms.Label returnOfProductLabel;
        private System.Windows.Forms.NumericUpDown amountReturned;
        private System.Windows.Forms.ComboBox searchFilterComboBox;
        private System.Windows.Forms.TextBox searchTermTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button resetSearchFilterButton;
        private System.Windows.Forms.TextBox searchAtLeastTextBox;
        private System.Windows.Forms.TextBox searchAtMostTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label searchAtLeastLabel;
        private System.Windows.Forms.Label searchAtMostLabel;
        private System.Windows.Forms.Label searchInformationLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar sellDateCalendar;
        private System.Windows.Forms.Label sellDateLabel;
        private System.Windows.Forms.TabPage statisticsTab;
        private System.Windows.Forms.ComboBox timePeriodComboBox;
        private System.Windows.Forms.Button showTopSellersButton;
        private System.Windows.Forms.Label topSellersLabel;
        private System.Windows.Forms.Label statisticsOfProductLabel;
        private System.Windows.Forms.ListBox statisticsListBox;
        private System.Windows.Forms.DataGridView statisticsDataGridView;
        private System.Windows.Forms.BindingSource statisticsBindingSource;
        private System.Windows.Forms.Button showItemStatisticsButton;
        private System.Windows.Forms.Button exportProductsButton;
        private System.Windows.Forms.Button importProductsButton;
    }
}

