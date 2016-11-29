using System.Linq;
using System.Web.Http;
using MarketPlaces.Dtos;
using MarketPlaces.Models;
using Microsoft.AspNet.Identity;

namespace MarketPlaces.Controllers.Api
{
    [Authorize]//to limit to authenticated users
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            //similar to attendances - check if market is already being followed
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId == dto.FolloweeId)
        )
                return BadRequest("Following already exists.");
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId

            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();

        }
    }
}
