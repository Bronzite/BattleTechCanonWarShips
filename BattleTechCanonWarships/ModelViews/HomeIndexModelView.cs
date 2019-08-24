using BattleTechCanonWarships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.ModelViews
{
    public class HomeIndexModelView
    {
        public Vessel FeaturedVessel { get; set; }
        public ShipClass FeaturedClass { get; set; }
        public Event FeaturedEvent { get; set; }
    }
}
