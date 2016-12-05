using MarketPlaces.Dtos;
using MarketPlaces.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;


namespace MarketPlaces.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {

            //mapping code:
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Market.Organiser)
                .ToList();

            //Mapper.Map<ApplicationUser, UserDto>();
            //Mapper.CreateMap<Market, MarketDto>();
            //Mapper.CreateMap<Notification, NotificationDto>();

            //Mapper.Initialize(cfg => cfg.CreateMap<ApplicationUser, UserDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Market, MarketDto>());
            //Mapper.Initialize(cfg => cfg.CreateMap<Notification, NotificationDto>());

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
            //return notifications.Select(n => new NotificationDto()
            //    {
            //        DateTime = n.DateTime,
            //        Market = new MarketDto()
            //        {
            //            Organiser = new UserDto()
            //            {
            //                Id = n.Market.Organiser.Id,
            //                Name = n.Market.Organiser.Name
            //            },
            //            DateTime = n.Market.DateTime,
            //            Id = n.Market.Id,
            //            IsCancelled = n.Market.IsCancelled,
            //            Venue = n.Market.Venue
            //        },
            //        OriginalDateTime = n.OriginalDateTime,
            //        OriginalVenue = n.OriginalVenue,
            //        Type = n.Type
            //    });
            //}
        }
    }
}
