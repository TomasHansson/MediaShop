using System.ComponentModel;

namespace Laboration3
{
    public class StatisticsItem
    {
        [DisplayName("Varunummer")]
        public int Id { get; set; }

        [DisplayName("Namn")]
        public string Name { get; set; }

        [DisplayName("Senaste månaden")]
        public int AmountSoldLastMonth { get; set; }

        [DisplayName("Senaste året")]
        public int AmountSoldLastYear { get; set; }

        [DisplayName("Totalt")]
        public int AmountSold { get; set; }
    }
}
