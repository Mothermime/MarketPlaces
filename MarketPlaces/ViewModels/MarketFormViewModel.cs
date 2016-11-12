using MarketPlaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.ViewModels
{
    //The view model pattern "provide clean separtation between UI and domain"
    public class MarketFormViewModel
    {

        //Serverside validation

        public string Organiser { get; set; }

        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }


    }
}


