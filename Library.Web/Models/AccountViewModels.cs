using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [Display(Name = "Пользователь")]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [StringLength(100, ErrorMessage = "{0} должен состоять минимум из {2} знаков.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить новый пароль")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и подтвержденный отличаются.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [Display(Name = "Пользователь")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [Display(Name = "Пользователь")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле '{0}' должно быть установлено")]
        [StringLength(100, ErrorMessage = "{0} должен состоять минимум из {2} знаков.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        [Compare("Password", ErrorMessage = "Новый пароль и подтвержденный отличаются.")]
        public string ConfirmPassword { get; set; }
    }
}
