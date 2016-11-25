using MarketPlaces.Models;
using MarketPlaces.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MarketPlaces.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingMarkets = _context.Markets

              //.Include(m => m.Category)
              // .Include(m => m.Organiser)
              .OrderBy(m => m.DateTime)
                .Where(m => m.DateTime > DateTime.Now).ToList();
            var viewModel = new MarketsViewModel
            {
                UpcomingMarkets = upcomingMarkets,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View( viewModel);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}