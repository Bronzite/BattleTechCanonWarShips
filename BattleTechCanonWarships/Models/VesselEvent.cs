using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class VesselEvent
    {
        public Guid Id { get; set; }
        public Guid VesselId { get; set; }
        public Vessel Vessel { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; }
        public ICollection<Reference> References { get; set; }
        public ICollection<Vessel.PropertyChange> PropertyChanges { get; set; }
    }
}
