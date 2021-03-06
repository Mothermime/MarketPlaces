﻿using System;
using MarketPlaces.Models;

namespace MarketPlaces.Dtos
{
    public class NotificationDto
    {
       
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public DateTime? OriginalDateTime { get; set; }
        public string OriginalVenue { get; set; }
      
        public MarketDto Market { get; set; }

    }
}