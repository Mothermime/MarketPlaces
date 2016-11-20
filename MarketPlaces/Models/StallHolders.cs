using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketPlaces.Models
{
    public class StallHolders
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser Stallholder { get; set; }
        [Required]
        [StringLength(225)]
        public string Name { get; set; }
         [Required]
        [StringLength(225)]
        public string Product { get; set; }
    }
}