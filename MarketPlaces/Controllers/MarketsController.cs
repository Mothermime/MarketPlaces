﻿using MarketPlaces.Models;
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
            // THIS CODE DOES NOT WORK FOR ME!! It breaks the saving function even when all fields are correctly filled out
            //if (!ModelState.IsValid)
            //{
            //    viewModel.Categories = _context.Categories.ToList();
            //    return View("Create", viewModel);
            //}



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