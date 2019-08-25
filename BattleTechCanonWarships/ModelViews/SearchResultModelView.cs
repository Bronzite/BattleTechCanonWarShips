using BattleTechCanonWarships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.ModelViews
{
    public class SearchResultModelView
    {
        public string Query { get; set; }
        public IList<Vessel> Vessels { get; set; }
        public IList<Event> Events { get; set; }
        public IList<Location> Locations { get; set; }
        public IList<ShipClass> ShipClasses { get; set; }
        
    }
}
