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

        public override string ToString()
        {
            if (ParentLocation != null) return string.Format("{0}, {1}", Name, ParentLocation.ToString());
            return Name;
        }
    }

    public class LocationSummary
    {
        public LocationSummary(Location l) { Id = l.Id; Name = l.Name; FullName = l.ToString(); }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
    }

    public class LocationDetail
    {
        public LocationDetail(Location l) { Id = l.Id; Name = l.Name; FullName = l.ToString(); X = l.X; Y = l.Y;ParentLocationId = l.ParentLocationId; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public int? X { get; set; }
        public int? Y { get; set; }
        public Guid? ParentLocationId { get; set; }
    }
}
