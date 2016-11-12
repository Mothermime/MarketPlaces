using System.ComponentModel.DataAnnotations;

namespace MarketPlaces.Models
{
    public class Category
    {

        public byte Id { get; set; }
        // string length of 255 is sufficient because there won't be that many categories
        //In some circumstances it may be a better design decision to create an admin page so that categories to be added.  
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}