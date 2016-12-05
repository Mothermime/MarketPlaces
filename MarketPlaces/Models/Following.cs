using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlaces.Models
{
    public class Following
    {
        //Again, like attendances, has a composite primary key and two navigation properties

        //This class is going to be used for following a stall holder rather than a market organiser but that is yet to come

        public ApplicationUser Followee { get; set; }
        public ApplicationUser Follower { get; set; }
        [Key]
        [Column(Order = 1)]
        public string FollowerId { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FolloweeId { get; set; }


    }
}