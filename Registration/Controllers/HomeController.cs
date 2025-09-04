using Microsoft.AspNetCore.Mvc;
using Registration.Context.Repository.BookedRepository;
using Registration.Context.Repository.HomeRepository;
using Registration.Model.Home;
using Registration.Model.Hotels;
using System.Globalization;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService homeService;
        public HomeController(HomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult HomePage(HomePageModel homePageModel)
        {

            ViewBag.dateStartBooked = homePageModel.dateStartBooked;
            ViewBag.dateEndBooked = homePageModel.dateEndBooked;
            if (homePageModel != null) 
            {
                var result = homeService.FindByForm(homePageModel);
                if (result.Count>0)
                return View(nameof(FindByForm),result);
            }
            return View(homePageModel);
        }

        public IActionResult FindByForm(List<FindResultModel> list)
        {
            return View(list);
        }
    }
}