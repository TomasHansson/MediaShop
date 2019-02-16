using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Laboration3
{
    public static class Validation
    {
        public static bool ProductsListIsEmpty(List<Product> products)
        {
            if (products.Count == 0)
            {
                MessageBox.Show("Det finns inga produkter i systemet.");
                return true;
            }
            return false;
        }

        public static bool NoProductIsSelected(Product product)
        {
            if (product == null)
            {
                MessageBox.Show("Du har inte markerat någon produkt.");
                return true;
            }
            return false;
        }

        public static bool ProductAlreadyInShoppingCart(List<ShoppingCartItem> shoppingCart, Product selectedProduct)
        {
            if (shoppingCart.Exists(x => x.Id == selectedProduct.Id))
            {
                MessageBox.Show("Den produkten har redan placerats i varukorgen. Om du vill ha fler av samma vara kan du öka antalet av den, " +
                                "alternativt ta bort den och sedan lägga till ett nytt antal.");
                return true;
            }
            return false;
        }

        public static bool AmountToAddIsZero(int amount)
        {
            if (amount == 0)
            {
                MessageBox.Show("Du måste ange hur många exemplar av varan du vill lägga till i kassan.");
                return true;
            }
            return false;
        }

        public static bool AmountIsLargerThanStockOfProduct(Product product, int amount)
        {
            if (amount > product.NumberInStock)
            {
                MessageBox.Show("Du kan inte lägga till fler exemplar i varukorgen än vad som finns på lagret.");
                return true;
            }
            return false;
        }

        public static bool ShoppingCartIsEmpty(List<ShoppingCartItem> shoppingCart)
        {
            if (shoppingCart.Count == 0)
            {
                MessageBox.Show("Det finns inga varor i varukorgen.");
                return true;
            }
            return false;
        }

        public static bool AllCopiesAlreadyAddedToShoppingCart(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItem.Amount == shoppingCartItem.NumberInStock)
            {
                MessageBox.Show("Det finns tyvärr inga fler av den produkten i lager.");
                return true;
            }
            return false;
        }

        public static bool IdInputIsNotAPositiveNumber(string input)
        {
            if (!int.TryParse(input, out int itemId) || itemId < 1)
            {
                MessageBox.Show("Du måste ange ett positivt heltal som varunummer.");
                return true;
            }
            return false;
        }

        public static bool IdInputIsAlreadyUsed(int input, List<Product> products)
        {
            if (products.Exists(x => x.Id == input))
            {
                MessageBox.Show("Det varunumret finns redan i systemet. Alla varunummer måste vara unika.");
                return true;
            }
            return false;
        }

        public static bool NameInputIsEmpty(string input)
        {
            if (input == string.Empty)
            {
                MessageBox.Show("Du måste ange ett namn på produkten.");
                return true;
            }
            return false;
        }

        public static bool PriceInputIsNotAPositiveNumber(string input)
        {
            if (!double.TryParse(input, out double itemPrice) || itemPrice <= 0)
            {
                MessageBox.Show("Du måste ange ett positivt tal för priset.");
                return true;
            }
            return false;
        }

        public static bool TypeInputIsEmpty(string input)
        {
            if (input == string.Empty)
            {
                MessageBox.Show("Du måste ange typ av produkt.");
                return true;
            }
            return false;
        }

        public static bool CreatorInputIsEmpty(string input)
        {
            if (input == string.Empty)
            {
                MessageBox.Show("Du måste ange vem som skapat produkten.");
                return true;
            }
            return false;
        }

        public static bool PublisherInputIsEmpty(string input)
        {
            if (input == string.Empty)
            {
                MessageBox.Show("Du måste ange vem som givit ut produkten.");
                return true;
            }
            return false;
        }

        public static bool AmountToDeliverIsZero(int amount)
        {
            if (amount == 0)
            {
                MessageBox.Show("Du måste ange hur många exemplar av produkten som levererats.");
                return true;
            }
            return false;
        }

        public static bool AmountToReturnIsZero(int amount)
        {
            if (amount == 0)
            {
                MessageBox.Show("Du måste ange hur många exemplar av produkten som returnerats.");
                return true;
            }
            return false;
        }

        public static bool NoSellsOfProductAtGivenDate(Product product, DateTime dateTime)
        {
            if (!product.SellRecords.ContainsKey(dateTime.Date))
            {
                MessageBox.Show("Inga exemplar av produkten såldes på det markerade datumet.");
                return true;
            }
            return false;
        }

        public static bool AmountToReturnIsGreaterThanAmountSoldOnGivenDate(Product product, int amount, DateTime dateTime)
        {
            if (amount > product.SellRecords[dateTime.Date])
            {
                MessageBox.Show("Det såldes inte så många exemplar av varan på det markerade datumet.");
                return true;
            }
            return false;
        }

        public static bool ProductToRemoveIsInShoppingCart(Product product, List<ShoppingCartItem> shoppingCart)
        {
            if (shoppingCart.Exists(x => x.Id == product.Id))
            {
                MessageBox.Show("Du kan inte ta bort en produkt från systemet medan den finns i varukorgen.");
                return true;
            }
            return false;
        }

        public static bool NoImportFileFound(string filepath)
        {
            if (!File.Exists(filepath))
            {
                MessageBox.Show("Det finns ingen fil att importera.");
                return true;
            }
            return false;
        }
    }
}
