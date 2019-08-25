using BattleTechCanonWarships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.ModelViews
{
    public class LocationModelView
    {
        public Location Location { get; set; }
        public IList<Location> ChildLocations { get; set; }

        public IList<Event> Events { get; set; }
    }
}
