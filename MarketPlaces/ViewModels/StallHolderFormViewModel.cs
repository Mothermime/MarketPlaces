using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.ViewModels
{
    public class StallHolderFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Product { get; set; }

        [Required]
        public string Stallholder { get; set; }
    }
}