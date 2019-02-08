using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Laboration3
{
    public class Product
    {
        [DisplayName("Varunummer")]
        public int Id { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Pris")]
        public double Price { get; set; }

        [DisplayName("Varutyp")]
        public string Type { get; set; }

        [DisplayName("Skapare")]
        public string Creator { get; set; }

        [DisplayName("Utgivare")]
        public string Publisher { get; set; }

        [DisplayName("Lager")]
        public int NumberInStock { get; set; }

        [Browsable(false)]
        public Dictionary<DateTime, int> SellRecords { get; set; }

        [DisplayName("Antal Sålda")]
        public int AmountSold { get; set; }

        // This allows the Products to be shown by their Name in the applications listboxes.
        public override string ToString()
        {
            return Name;
        }
    }
}
