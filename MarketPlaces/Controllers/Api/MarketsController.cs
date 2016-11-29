using MarketPlaces.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace MarketPlaces.Controllers.Api
{
    [Authorize]
    //accessible only by authenticated users
    public class MarketsController : ApiController
    {
        private ApplicationDbContext _context;

        public MarketsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var market = _context.Markets.Single(m => m.Id == id && m.OrganiserId == userId);

            if (market.IsCancelled)
                return NotFound();

            market.IsCancelled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
