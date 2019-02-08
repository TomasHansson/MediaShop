using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;

namespace Laboration3
{
    public class ReceiptPrinter
    {
        private PrintDocument printDocument = new PrintDocument();
        private readonly PrintDialog printDialog = new PrintDialog();
        private readonly List<ShoppingCartItem> shoppingCart;
        private double orderTotal;

        public ReceiptPrinter(List<ShoppingCartItem> _shoppingCart)
        {
            printDialog.Document = printDocument;
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            shoppingCart = _shoppingCart;
        }

        public void PrintReceipt(double _orderTotal)
        {
            orderTotal = _orderTotal;
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDocument.Print();
        }

        private const int linesPerPage = 40;
        private int linesToWrite = 0;
        private int linesWrittenOnPage = 0;
        private int totalLinesWritten = 0;
        private bool isFirstPage = true;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (isFirstPage)
            {
                linesToWrite = shoppingCart.Count;
                linesWrittenOnPage = 0;
                totalLinesWritten = 0;
                string receiptHeader = "Datum: " + DateTime.Now.ToShortDateString() + ". Kl. " + DateTime.Now.ToShortTimeString() + ". Köpets totala kostnad: " + orderTotal + ".";
                e.Graphics.DrawString(receiptHeader, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 90, 140);
                isFirstPage = false;
            }

            while (linesWrittenOnPage < linesToWrite && linesWrittenOnPage < linesPerPage)
            {
                string lineForShoppingItem = "Varunummer " + shoppingCart[totalLinesWritten].Id.ToString() + ": " +
                                             shoppingCart[totalLinesWritten].Name + ", # " +
                                             shoppingCart[totalLinesWritten].Amount.ToString() + " á " +
                                             shoppingCart[totalLinesWritten].Price.ToString() + " = " +
                                             shoppingCart[totalLinesWritten].TotalPrice.ToString() + " kr";
                e.Graphics.DrawString(lineForShoppingItem, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 90, 160 + 15 * linesWrittenOnPage);
                linesWrittenOnPage++;
                totalLinesWritten++;
            }

            if (totalLinesWritten < linesToWrite)
            {
                e.HasMorePages = true; // If there are more items left to print, this function will be called again, continuing on a new page.
                linesWrittenOnPage = 0;
            }
            else
            {
                e.HasMorePages = false;
                isFirstPage = true; // If all items have been printed, the printer is set to expect a new first page. 
            }
        }
    }
}
