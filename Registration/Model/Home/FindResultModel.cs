using Registration.Model.Hotels;

namespace Registration.Model.Home
{
    public class FindResultModel
    {
        //добивить количество звезд
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public List<RoomInfo> rooms { get; set; }
    }

    public class RoomInfo
    {
        public int Id {  get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }

        public int Square { get; set; }
        public string Discription { get; set; }

    }
}
