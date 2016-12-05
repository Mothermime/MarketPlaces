using System;
using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.Models
{
    public class Notification
    {
          public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        //'?' means the property is not nullable
        public DateTime? OriginalDateTime { get; private set; }
        public string OriginalVenue { get; private set; }

        [Required]
        public Market Market { get; private set; }

        protected Notification()
        {
        }

       // constructor declared, taking two parameters - notificationType and Market
         private Notification(NotificationType type, Market market)
        {
            //Check that market is not null, otherwise set Type, market and datetime.
            //This constructor is responsible for setting the date time to null.  Because the facility to change the date should be nowhere else in the code, this is protected by making the settors properties private.  A private settor means it can't be changed once it has been set
            if (market == null)
            {
                throw new ArgumentNullException("market");

                Type = type;
                Market = market;
                DateTime = DateTime.Now;
            }


        }

        public static Notification MarketCreated(Market market)
        {
            return new Notification(NotificationType.MarketCreated, market);
        }
        //this ensures the notification is always in a valid state
        public static Notification MarketUpdated(Market newMarket, DateTime originalDateTime, string originalVenue)
        {
            var notification = new Notification(NotificationType.MarketUpdated, newMarket);
            notification.OriginalDateTime = originalDateTime;
            notification.OriginalVenue = originalVenue;
            return notification;
        }

        public static Notification MarketCancelled(Market market)
        {
            return new Notification(NotificationType.MarketCancelled, market);
        }
    }
}