using System.Collections;
using System.Collections.Generic;
using MarketPlaces.Models;

namespace MarketPlaces.ViewModels
{
    public class MarketsViewModel : IEnumerable
    {
        public IEnumerable<Market> UpcomingMarkets { get; set; }
        public bool ShowActions { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}