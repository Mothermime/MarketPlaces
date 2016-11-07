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
        public Market Market { get; set; }
        public ApplicationUser Attendee { get; set; }
        [Key]
        [Column(Order = 1)]
        public int MarketId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string AttendeeId { get; set; }


    }
}