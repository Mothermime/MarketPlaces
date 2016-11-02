using MarketPlaces.Models;
using MarketPlaces.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MarketPlaces.Controllers
{
    public class MarketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Create()
        {
            var viewModel = new MarketFormViewModel
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
    }
}