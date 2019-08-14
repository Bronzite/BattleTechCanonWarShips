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
    }
}
