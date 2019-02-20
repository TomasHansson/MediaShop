using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace Laboration3
{
    public class ReceiptPrinter
    {
        private PrintDocument _printDocument = new PrintDocument();
        private readonly PrintDialog _printDialog = new PrintDialog();
        private readonly List<ShoppingCartItem> _shoppingCart;
        private double _orderTotal;

        public ReceiptPrinter(List<ShoppingCartItem> shoppingCart)
        {
            _printDialog.Document = _printDocument;
            _printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            _shoppingCart = shoppingCart;
        }

        public void PrintReceipt(double orderTotal)
        {
            _orderTotal = orderTotal;
            if (_printDialog.ShowDialog() == DialogResult.OK)
                _printDocument.Print();
        }

        private const int _linesPerPage = 40;
        private int _linesToWrite = 0;
        private int _linesWrittenOnPage = 0;
        private int _totalLinesWritten = 0;
        private bool _isFirstPage = true;
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

            while (_linesWrittenOnPage < _linesToWrite && _linesWrittenOnPage < _linesPerPage)
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
