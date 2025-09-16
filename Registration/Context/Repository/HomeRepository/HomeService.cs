using Registration.Context.Repository.BookedRepository;
using Registration.Context.Repository.HotelRepository;
using Registration.Model.Home;
using Registration.Model.Hotels;

namespace Registration.Context.Repository.HomeRepository
{
    public class HomeService
    {
        private readonly IHomeRepository repository;
        public HomeService(IHomeRepository repository)
        {
            this.repository = repository;
        }

        public List<FindResultModel> FindByForm(HomePageModel homePageModel)
        {
            return repository.FindByForm(homePageModel);
        }
    }
}
