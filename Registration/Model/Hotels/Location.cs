using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Hotels
{
    public class Location
    {
        public int id {  get; set; }

        [Display(Name="Страна")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Country { get; set; }

        [Display(Name = "Область")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Region { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string City { get; set; }

        [Display(Name = "Улица")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Home { get; set; }        
    }
}
