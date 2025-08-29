using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Hotels
{
    public class Hotel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(100, ErrorMessage = "Это поле не может превышать 100 символов")]
        public string Name { get; set; }

        [Display(Name = "Местоположение")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(200, ErrorMessage = "Это поле не может превышать 200 символов")]
        public string Location { get; set; }
        //public Location Location { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [StringLength(300, ErrorMessage = "Это поле не может превышать 300 символов")]
        public string Description { get; set; }

        [Display(Name = "Количество звёзд")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [Range(1, 5, ErrorMessage = "Введите число от 1 до 5")]
        public int Rating { get; set; }

        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage ="Формат телефона: 8-497-355-22-15")]
        public string Phone {  get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Формат Email: support@mysite.ru")]
        public string Email { get; set; }

        //Prop Navigate
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
        public virtual ICollection<Booked> BookedRooms { get; set;} = new List<Booked>();
    }
}
