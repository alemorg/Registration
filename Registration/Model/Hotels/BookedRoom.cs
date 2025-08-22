using Registration.Model.Users;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Registration.Model.Hotels
{
    public class BookedRoom
    {
        public int Id { get; set; }
        /////////////////////////////////////////////
        /// 
        /// Зачем это?
        public BookedRoom()
        {
            isBooked = false;
        }
        public bool isBooked { get; set; }
        ///
        ///
        /////////////////////////////////////////////

        [Required(ErrorMessage ="Обязательное поле для ввода")]
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime dataBooked { get; set; }

        //навигационное свойство
        public int Roomid { get; set; }
        public RegistrationUser? Visitor { get; set; }
    }
}
