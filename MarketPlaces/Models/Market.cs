using System;
using System.ComponentModel.DataAnnotations;

//This class creates the table for the database and each of the properties becomes a column.
//"Don't try to model the entire universe"  Build models as you need them.  Make small changes

namespace MarketPlaces.Models
{
    public class Market
    {
        public int Id { get; set; }

        public bool IsCancelled { get; set; }

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
    }
}