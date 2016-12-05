using System;
using MarketPlaces.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
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
            //get a given market.  Eager loading gets the market and all of its attendances  use the include method to eager load
            var market = _context.Markets
               //.Include(m => m.Attendances.Select(a => a.Attendee))// use the select method because Attendances is a collection and 'attendee' is not a property of Attendances
                .Single(m => m.Id == id && m.OrganiserId == userId);
           

            if (market.IsCancelled)
                return NotFound();
            
            market.Cancel();

             // market.IsCancelled = true;

            //The commented code is the process of refactoring, using cohesion to make sure highly related things are together.  Anything that changes the demain is not the responsibility of the controller but rather the domain model  so the above method is made to encapsulate all of the refactored code below

            //var notification = new Notification
            ////{
            ////    DateTime = DateTime.Now,
            ////    Market = market,
            ////    Type = NotificationType.MarketCancelled
            ////};
            // //var attendees = _context.Attendances.Where(a => a.MarketId == market.Id).Select(a => a.Attendee).ToList();

            // //foreach (var attendee in attendees)
            // foreach (var attendee in market.Attendances.Select(a => a.Attendee))
            //{
            // attendee.Notify(notification);
            ////    var userNotification = new UserNotification
            ////    {
            ////        User = attendee,
            ////        Notification = notification
            ////    };
            ////    _context.UserNotifications.Add(UserNotification);
            ////}
            _context.SaveChanges();
            //try
            //{
            //    
            //}
            //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //{
            //    Exception raise = dbEx;
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            string message = string.Format("{0}:{1}",
            //                validationErrors.Entry.Entity.ToString(),
            //                validationError.ErrorMessage);
            //            // raise a new exception nesting
            //            // the current instance as InnerException
            //            raise = new InvalidOperationException(message, raise);
            //        }
            //    }
            //    throw raise;
            //}
            return Ok();
        }
    }
}
//Cohesion - things that are highly related should  be together