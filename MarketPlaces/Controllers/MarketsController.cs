using MarketPlaces.Models;
using MarketPlaces.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MarketPlaces.Controllers
{
    //An empty controller allows you to add all the code from scratch
    public class MarketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarketsController()
        {
            //initialize _context
            _context = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var markets = _context.Markets
                .Where(m => m.OrganiserId == userId && m.DateTime > DateTime.Now && !m.IsCancelled)
                .Include(m => m.Category)
                .ToList();
            return View(markets);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var markets = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Market)
                .Include(m => m.Category)
                .ToList();
            var viewModel = new MarketsViewModel()
            {
                UpcomingMarkets = markets,
                ShowActions = User.Identity.IsAuthenticated
            };
            return View(viewModel);
        }
        //Initially this was the Index method but a new view was created and put into a folder in the views section that has been given the same name as the controller
        //Authorize allows only authenticated users to access the page
        [Authorize]
        public ActionResult Create()
        {
            //create a view model and set the categories property

            var viewModel = new MarketFormViewModel
            {
                Categories = _context.Categories.ToList(),
                Heading = "Add a Market"

            };
            // put the view model inside the view
            return View("MarketForm", viewModel);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var market = _context.Markets.Single(m => m.Id == id && m.OrganiserId == userId);
            //create a view model and set the categories property

            var viewModel = new MarketFormViewModel
            {

                Heading = "Edit a Market",
                Id = market.CategoryId,
                Title = market.Title,
                Categories = _context.Categories.ToList(),
                Date = market.DateTime.ToString("d MMM yyyy"),
                Time = market.DateTime.ToString("HH:mm"),
                Category = market.CategoryId,
                Venue = market.Venue

            };
            // put the view model inside the view
            return View("MarketForm", viewModel);
        }
        [Authorize]//only authenticated users can access
        [HttpPost]
        [ValidateAntiForgeryToken]//validates the token in the create.cshtml. When the programme is run it creates a 'hidden field'(?) with a random token.  It also creates a cookie with an encrypted version of the token. Asp.Net compares the two to see if they match.  If they don't, it is an attack and will not proceed
                                  //The parameter holds the name of the model behind the view so that when the form is posted that is what we will get
        public ActionResult Create(MarketFormViewModel viewModel)
        {
            //Todo  fix this
            // THIS CODE DOES NOT WORK FOR ME!! It breaks the saving function even when all fields are correctly filled out.  It is saying it is not valid for some reason.
            // FIXED!! It was saying it wasn't valid because of the Create view above.  There was a validation error there.  Thank you Ryan.

            //Check to see if model is valid.  If it's not return the create view otherwise returnt he home view
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("MarketForm", viewModel);
            }


            var market = new Market
            {
                //these are all the properties I want to display on the form 
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
        [Authorize]//only authenticated users can access
        [HttpPost]
        [ValidateAntiForgeryToken]//validates the token in the create.cshtml. When the programme is run it creates a 'hidden field'(?) with a random token.  It also creates a cookie with an encrypted version of the token. Asp.Net compares the two to see if they match.  If they don't, it is an attack and will not proceed
                                  //The parameter holds the name of the model behind the view so that when the form is posted that is what we will get
        public ActionResult Update(MarketFormViewModel viewModel)
        {
            //Check to see if model is valid.  If it's not return the create view otherwise returnt he home view
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("MarketForm", viewModel);
            }
            var UserId = User.Identity.GetUserId();
            var market = _context.Markets
                .Include(m => m.Attendances.Select(a => a.Attendee))
                .Single(m => m.Id == viewModel.Id && m.OrganiserId == UserId);
           // market.Modify(viewModel.GetDateTime(), viewModel.Venue, viewModel.Category);

            _context.SaveChanges();
            return RedirectToAction("Index", "Home");


        }
        [HttpPost]
        public ActionResult Details()
        {
            var upcomingMarkets = _context.Markets

                .Include(m => m.Category)
                .Include(m => m.Organiser).OrderBy(m => m.DateTime)
                .Where(m => m.DateTime > DateTime.Now).ToList();
            var viewModel = new MarketsViewModel
            {
                UpcomingMarkets = upcomingMarkets,

            };

            return RedirectToAction("Details");
        }

       

    }
}