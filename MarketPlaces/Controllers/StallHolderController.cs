using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MarketPlaces.Controllers
{
    public class StallHolderController : Controller
    {
        // GET: StallHolder
        public ActionResult CreateStallHolder()
        {
            return View();
        }
    }
}