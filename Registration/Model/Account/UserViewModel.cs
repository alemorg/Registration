using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Account
{
    public class UserViewModel
    {
        [Display(Name = "ID")]
        public string Id { get; set; }

        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчетсво")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "День рождения")]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Права пользователя")]
        public string Role { get; set; }

    }
}
