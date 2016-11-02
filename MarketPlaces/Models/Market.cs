using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlaces.Models
{
    public class Market
    {
        public int Id { get; set; }


        public ApplicationUser Organiser { get; set; }

        [Required]
        public string OrganiserId { get; set; }

        [Required]
        [StringLength(255)]
        public string MarketName { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }


        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }
    }
}