using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Home
{
    public class HomePageModel
    {
        [Display(Name = "Локация")]
        [StringLength(50, ErrorMessage = "Количество символов должно быть не более 50")]
        public string? Location { get; set; }

        [Display(Name = "Дата заезда")]
        [Range(typeof(DateTime), "1950-01-01", "2025-12-31")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateStartBooked { get; set; }

        [Display(Name = "Дата выезда")]
        [Range(typeof(DateTime), "1950-01-01", "2025-12-31")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? dateEndBooked { get; set; }

        [Display(Name = "Количество взрослых")]
        [MinLength(1,ErrorMessage = "Количество взрослых не должно быть менее 1")]
        public int? Grownup {  get; set; }

        [Display(Name = "Количество детей")]
        [MinLength(1, ErrorMessage = "Количество взрослых не должно быть менее 1")]
        public int? Children { get; set; }

        [Display(Name = "С животными?")]
        public bool IsAnimal { get; set; } = false;
    }
}
