using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

//This class creates the table for the database and each of the properties becomes a column.
//"Don't try to model the entire universe"  Build models as you need them.  Make small changes

namespace MarketPlaces.Models
{
    public class Market
    {
        public int Id { get; set; }

        public bool IsCancelled { get; private set; } //set 'set' to private for notifications

        //ApplicationUser is a preset class & is a navigation property
        public ApplicationUser Organiser { get; set; }
        //The 'Required' label makes the column 'not null'.  It wiil initially show an error because it needs a using statement.  if Resharper doesn't work right-click and choose resolve using statements
        [Required]

        public string OrganiserId { get; set; }

        //The 'string length' handle gives a limit to the nvarchar data type as it automatically sets to 'max'
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public DateTime DateTime { get; set; }



        [Required]
        [StringLength(255)]
        public string Venue { get; set; }

        //make a model/class of categories - a navigation property
        public Category Category { get; set; }
        //and add foreign key properties
        [Required]
        public byte CategoryId { get; set; }

        // make the settor private so that once it is initialized, nowhere else can it be overwritten, creating a valid state
        public ICollection<Attendance> Attendances { get; private set; }

        //initialise attendances in a constructor:
        public Market()
        {
            Attendances = new Collection<Attendance>();
        }

        public void Cancel()
        {
            IsCancelled = true;

            var notification = Notification.MarketCancelled(this);

            foreach (var attendee in Attendances.Select(a => a.Attendee))
            {
                attendee.Notify(notification);
            }
        }

        public void Modify(DateTime dateTime, string venue, byte Category)
        {
            //a factory method is responsible for creating an object in a valid state
            var notification = Notification.MarketUpdated(this, DateTime, Venue);



            Venue = venue;
            DateTime = dateTime;
            CategoryId = Category;
            //iterate over attendees and notify them
            foreach (var attendee in Attendances.Select(a => a.Attendee))
                attendee.Notify(notification);

        }
    }
}
