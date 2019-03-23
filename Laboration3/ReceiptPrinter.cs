using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace Laboration3
{
    public class ReceiptPrinter : IReceiptPrinter
    {
        private PrintDocument _printDocument = new PrintDocument();
        private readonly PrintDialog _printDialog = new PrintDialog();
        private readonly List<ShoppingCartItem> _shoppingCart;
        private double _orderTotal;

        // ReceiptPrinter: Constructor. Sets up the private fields required for the class to function.
        // Pre: shoppingCart != null.
        // Post: The _printDialog, _printDocument and _shoppingCart has been setup. 
        public ReceiptPrinter(List<ShoppingCartItem> shoppingCart)
        {
            _printDialog.Document = _printDocument;
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            _shoppingCart = shoppingCart;
        }

        // PrintReceipt: Prints a receipt based on the items in the list _shoppingCart.
        // Pre: The _shoppingCart is not empty. orderTotal equals the total value of items in the _shoppingCart.
        // Post: The _orderTotal has been set to the total value of items in the _shoppingCart and a PrintDialog-box has been shown, 
        // allowing the user to print a receipt for their purchase.
        public void PrintReceipt(double orderTotal)
        {
            _orderTotal = orderTotal;
            if (_printDialog.ShowDialog() == DialogResult.OK)
                _printDocument.Print();
        }

        // PrintDocument_PrintPage: Event-handler for when the user uses the _printDialog to print a page.
        // Pre: -
        // Post: A receipt has been printed based on the contents of the _shoppingCart.
        private const int _linesPerPage = 40;
        private int _linesToWrite = 0;
        private int _linesWrittenOnPage = 0;
        private int _totalLinesWritten = 0;
        private bool _isFirstPage = true; // Used to determine if it's the first page or not. If it's, the other related fields are reset for the new
                                          // receipt and a header is printed.
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_isFirstPage)
            {
                _linesToWrite = _shoppingCart.Count;
                _linesWrittenOnPage = 0;
                _totalLinesWritten = 0;
                string receiptHeader = "Datum: " + DateTime.Now.ToShortDateString() + ". Kl. " + DateTime.Now.ToShortTimeString() + ". Köpets totala kostnad: " + _orderTotal + ".";
                e.Graphics.DrawString(receiptHeader, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 90, 140);
                _isFirstPage = false;
            }

            while (_linesWrittenOnPage < _linesToWrite && _linesWrittenOnPage < _linesPerPage) // Writes at most _linesPerPage (currently 40) items per page.
            {
                string lineForShoppingItem = "Varunummer " + _shoppingCart[_totalLinesWritten].Id.ToString() + ": " +
                                             _shoppingCart[_totalLinesWritten].Name + ", # " +
                                             _shoppingCart[_totalLinesWritten].Amount.ToString() + " á " +
                                             _shoppingCart[_totalLinesWritten].Price.ToString() + " = " +
                                             _shoppingCart[_totalLinesWritten].TotalPrice.ToString() + " kr";
                e.Graphics.DrawString(lineForShoppingItem, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 90, 160 + 15 * _linesWrittenOnPage);
                _linesWrittenOnPage++;
                _totalLinesWritten++;
            }

            if (_totalLinesWritten < _linesToWrite)
            {
                e.HasMorePages = true; // If there are more items left to print, this function will be called again, continuing on a new page.
                _linesWrittenOnPage = 0;
            }
            else
            {
                e.HasMorePages = false;
                _isFirstPage = true; // If all items have been printed, the printer is set to expect a new first page. 
            }
        }
    }
}
