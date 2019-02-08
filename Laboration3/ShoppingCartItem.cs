using System.ComponentModel;

namespace Laboration3
{
    public class ShoppingCartItem
    {
        [DisplayName("Varunummer")]
        public int Id { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Styck Pris")]
        public double Price { get; set; }

        [DisplayName("Antal Valda")]
        public int Amount { get; set; }

        [DisplayName("Totalt Pris")]
        public double TotalPrice { get; set; }

        [Browsable(false)]
        public int NumberInStock { get; set; }
    }
}
