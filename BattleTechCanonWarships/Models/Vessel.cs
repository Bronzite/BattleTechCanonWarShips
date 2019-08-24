using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class Vessel
    {
        public Guid Id { get; set; }
        public ICollection<VesselEvent> Events { get; set; }
        public string Name { get; set; }
        public Guid? PreviousVesselId { get; set; }
        public Vessel PreviousVessel { get; set; }
        public Guid ShipClassId { get; set; }
        public ShipClass ShipClass { get; set; }
        public class Property
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            
        }
        public class PropertyChange
        {
            public Guid Id { get; set; }
            public Guid VesselEventId { get; set; }
            public VesselEvent VesselEvent { get; set; }
            public Guid PropertyId { get; set; }
            public Vessel.Property Property { get; set; }
            public string PreviousValue { get; set; }
            public string Value { get; set; }
        }
    }
}
