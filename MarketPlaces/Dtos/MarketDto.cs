using System;

namespace MarketPlaces.Dtos
{
    public class MarketDto
    {
        public int Id { get; set; }
        public bool IsCancelled { get; set; }
        public UserDto Organiser { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public CategoryDto Category { get; set; }
        
     
       

       

    }
}