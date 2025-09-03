using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.VisualBasic;
using Registration.Model.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Registration.Model.Hotels
{
    public class Booked
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Обязательное поле для ввода")]
        [Display(Name = "Дата первого дня бронирования")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dateStartBooked { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Display(Name = "Дата последнего дня бронирования")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime dateEndBooked { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Display(Name = "Имя гостя")]
        [StringLength(50, ErrorMessage ="Количество символов не должно превышать 50")]
        public string GuestFirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Display(Name = "Отчество гостя")]
        [StringLength(50, ErrorMessage = "Количество символов не должно превышать 50")]
        public string GuestSecondName { get; set; }

        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Display(Name = "Фамилия гостя")]
        [StringLength(50, ErrorMessage = "Количество символов не должно превышать 50")]
        public string GuestLastName { get; set; }

        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage = "Формат телефона: 8-497-355-22-15")]
        public string GuestPhone { get; set; }

        [Required(ErrorMessage = "Обязательное поле для ввода")]
        [Display(Name = "Количество гостей")]
        [Range(1,10,ErrorMessage ="Число гостей не должно первышать 10 и не должно быть меньше 1")]
        public int NumberGuest { get; set; }

        [Display(Name = "Специальные пожелания")]
        [StringLength(200, ErrorMessage = "Количество символов не должно превышать 200")]
        public string? SpecialRequests { get; set; }


        public int Roomid { get; set; }
        //навигационное свойство

        [ValidateNever]
        [ForeignKey("Roomid")]
        public virtual Room Room { get; set; }

        //public User? Visitor { get; set; }
    }
}
