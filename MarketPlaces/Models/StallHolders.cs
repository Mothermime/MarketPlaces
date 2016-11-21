using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.Models
{
    public class StallHolders
    {
        public int Id { get; set; }
        
        public ApplicationUser Stallholder { get; set; }
        [Required]
        public string StallholderId { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }
         [Required]
        [StringLength(225)]
        public string Product { get; set; }
    }
}