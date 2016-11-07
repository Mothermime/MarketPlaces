using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlaces.Models;
using System.Data.Entity;

namespace MarketPlaces.Controllers
{
    public class HomeController : Controller
    {
        private  ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingMarkets = _context.Markets

                .Include(m => m.Category)
                .Include(m => m.Organiser).OrderBy(m => m.DateTime)
                .Where(m => m.DateTime > DateTime.Now).ToList();
      
            return View(upcomingMarkets);
            
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