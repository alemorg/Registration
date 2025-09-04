using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Users
{
    public class User : IdentityUser
    {
        public int Id { get; set; }

        [Display(Name ="Логин")]
        [Required(ErrorMessage ="Это поле обязательно для ввода")]
        [StringLength(50,ErrorMessage ="Количество символов должно быть не более 50")]
        [MinLength(5,ErrorMessage ="Количество символов должно быть больше 5")]
        public string Login { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(50, ErrorMessage = "Количество символов должно быть не более 50")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(50, ErrorMessage = "Количество символов должно быть не более 50")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(50, ErrorMessage = "Количество символов должно быть не более 50")]
        public string LastName { get; set; }

        [Display(Name ="Email")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [UIHint("EmailAdress")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "День рождения")]
        //[Required(ErrorMessage = "Обязательное поле для ввода")]
        [Range(typeof(DateTime),"1950-01-01","2025-12-31")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}",ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Пароль")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Compare("ConfirmPassword", ErrorMessage = "Пароли должны совпадать")]
        [MinLength(15, ErrorMessage = "Минимальное количество символов 15")]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [UIHint("Password")]
        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [MinLength(15, ErrorMessage = "Минимальное количество символов 15")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Согласие на обработку персональных данных")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public bool IsAgree { get; set; }
    }
}
