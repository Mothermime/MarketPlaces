﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http.Routing.Constraints;

namespace MarketPlaces.Models
{
    public class Following
    {
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