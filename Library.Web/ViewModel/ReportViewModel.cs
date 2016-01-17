using System.ComponentModel;

namespace Library.Web.ViewModel
{
    public class ReportViewModel
    {
        [DisplayName("Категория")]
        public string Category { get; set; }

        [DisplayName("Количество")]
        public int Amount { get; set; }
    }
}