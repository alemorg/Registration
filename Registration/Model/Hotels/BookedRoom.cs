using System.Data;

namespace Registration.Model.Hotels
{
    public class BookedRoom
    {
        public int Id { get; set; }
        public bool isBooked { get; set; }
        public DataSetDateTime dataBooked { get; set; }
    }
}
