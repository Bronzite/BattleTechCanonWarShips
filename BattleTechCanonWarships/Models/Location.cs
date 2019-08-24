using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public Guid? ParentLocationId { get; set; }
        public Location ParentLocation { get; set; }

        public void FullLoad()
        {
            if (ParentLocationId.HasValue)
            {
                ParentLocation = SiteStatics.Context.Locations.Find(ParentLocationId.Value);
                ParentLocation.FullLoad();
            }
        }

        public override string ToString()
        {
            if (ParentLocation != null) return string.Format("{0}, {1}", Name, ParentLocation.ToString());
            return Name;
        }
    }
}
