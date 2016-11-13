using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketPlaces.Models
{
    public class Attendance
    {
        //An intermediary table to connect  many to many relationships between market and Users.  It makes it easier to query 
        //Add navigation properties - market and attendee
        public Market Market { get; set; }
        public ApplicationUser Attendee { get; set; }
        //add foreign key properties.  'Key' creates a composite key and Column order sets the order in which they are listed
        [Key]
        [Column(Order = 1)]
        public int MarketId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }


    }
}