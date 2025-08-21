using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Hotels
{
    public class Hotel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Name { get; set; }

        [Display(Name = "Местоположение")]
        [ValidateNever]
        public string? Location { get; set; }

        [ValidateNever]
        public List<Room>? rooms { get; set; }
    }
}
