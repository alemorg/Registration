using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Users
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [UIHint("EmailAdress")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Обязательное поле для ввода")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
