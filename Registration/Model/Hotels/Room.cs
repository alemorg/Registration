using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Registration.Model.Hotels
{
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Номер комнаты")]
        [StringLength(20,ErrorMessage ="Количество символов не должено превышать 20")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        [Range(0.01,double.MaxValue,ErrorMessage ="Значение должно быть больше 0")]
        [DataType(DataType.Currency)]
        [Display(Name ="Цена за ночь")]
        public decimal Price { get; set; }

        [Display(Name ="Площадь")]
        [Range(1,int.MaxValue,ErrorMessage ="Значение должно быть больше 1")]
        [Required(ErrorMessage ="Это поле обязательно для ввода")]
        public int Square {  get; set; }

        [Display(Name = "Количество гостей")]
        [Range(1,int.MaxValue,ErrorMessage ="Количество гостей должно быть не менее 1")]
        [Required(ErrorMessage = "Это поле обязательно для ввода")]
        public int Capasity { get; set; }

        [Display(Name = "Доступно для бронирования")]
        public bool isActivity { get; set; } = true;

        [Display(Name ="Описание")]
        [StringLength(200,ErrorMessage ="Максимальное количество символов 200")]
        public string Discription {  get; set; }


        //Внешний ключ
        public int HotelId { get; set; }

        //Навигационное свойство
        public virtual ICollection<BookedRoom> ListBookeds { get; set; } = new List<BookedRoom>();

        [ForeignKey("HotelId")]
        public virtual Hotel Hotel { get; set; }
    }
}
