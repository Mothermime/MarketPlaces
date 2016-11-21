using System.Web.Mvc;
using MarketPlaces.Models;
using MarketPlaces.ViewModels;
using Microsoft.AspNet.Identity;

namespace MarketPlaces.Controllers
{
    public class StallHolderController : Controller
    {
        private ApplicationDbContext _context;

        public StallHolderController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: StallHolder
        [Authorize]
        public ActionResult CreateStallHolder()
        {
            var viewModel = new StallHolderFormViewModel();
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStallHolder(StallHolderFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // viewModel.Categories = _context.Categories.ToList();
                return View("CreateStallHolder", viewModel);
            }

           
            var stallholder = new StallHolders
            {
                //these are all the properties I want to display on the form 
                StallholderId = User.Identity.GetUserId(),
                Name = viewModel.Name,

                Product = viewModel.Product

            };
            _context.StallHolder.Add(stallholder);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}