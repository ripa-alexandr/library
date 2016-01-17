using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.ViewModel
{
    public class CategoryViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [StringLength(200, ErrorMessage = "Длина строки должна быть до {1} символов")]
        public string Name { get; set; }

        [DisplayName("Дата создания (UTC)")]
        public DateTime? CreationDate { get; set; }
    }
}