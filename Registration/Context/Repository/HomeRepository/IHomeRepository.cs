using Registration.Model.Hotels;
using Registration.Model.Home;

namespace Registration.Context.Repository.HomeRepository
{
    public interface IHomeRepository
    {
        //IEnumerable<Hotel> ListHotel();
        //IEnumerable<Room> LisRoom();
        //IEnumerable<Booked> ListBooked();
        List<FindResultModel> FindByForm(HomePageModel homePageModel);
    }
}
