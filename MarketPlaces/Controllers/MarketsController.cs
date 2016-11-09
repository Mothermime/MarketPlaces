using System.Data.Entity;
using MarketPlaces.Models;
using MarketPlaces.ViewModels;
using Microsoft.AspNet.Identity;
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
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var markets = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Market)
                .Include(m=> m.Category)
                .ToList();
            var viewModel = new MarketsViewModel()
            {
                UpcomingMarkets = markets,
                ShowActions = User.Identity.IsAuthenticated
            };
            return View( viewModel);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new MarketFormViewModel
            {
                Categories = _context.Categories.ToList()
                
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
      [ValidateAntiForgeryToken]
        public ActionResult Create(MarketFormViewModel viewModel)
        {
            //Todo  fix this
            // THIS CODE DOES NOT WORK FOR ME!! It breaks the saving function even when all fields are correctly filled out.  It is saying it is not valid for some reason.
            // FIXED!! It was saying it wasn't valid because of the Create view above.  There was a validation error there.  Thank you Ryan.
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }



            var market = new Market
            {
                OrganiserId = User.Identity.GetUserId(),
                CategoryId = viewModel.Category,
                DateTime = viewModel.GetDateTime(),
                Title = viewModel.Title,
                Venue = viewModel.Venue

            };
            _context.Markets.Add(market);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
    }
}