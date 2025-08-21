using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Registration.Model.Hotels
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name ="Площадь")]
        [Required(ErrorMessage ="Это поле обязательно для ввода")]
        public int Square {  get; set; }

        [Display(Name = "Максимальное количество гостей")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public int MaximumGuests { get; set; }


        //навигационное свойство
        public int HotelId { get; set; }

        [ValidateNever]
        public List <BookedRoom>? ListBookeds { get; set; }
    }
}
