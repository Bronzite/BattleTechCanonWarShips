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

    public class PropertyChangeSummary
    {
        public PropertyChangeSummary(Vessel.PropertyChange p)
        {
            Property = p.Property.Name;
            Previous = p.PreviousValue;
            New = p.Value;
        }
        public string Property { get; set; }
        public string Previous { get; set; }
        public string New { get; set; }
    }

    public class VesselSummary
    {
        public VesselSummary(Vessel v)
        {
            VesselId = v.Id;
            VesselName = v.Name;
            VesselClassId = v.ShipClassId;
            VesselClassName = v.ShipClass.Name;
        }

        public Guid VesselId { get; set; }
        public string VesselName { get; set; }
        public Guid VesselClassId { get; set; }
        public string VesselClassName { get; set; }
    }

    public class VesselDetail
    {
        public VesselDetail(Vessel v)
        {
            VesselId = v.Id;
            VesselName = v.Name;
            VesselClassId = v.ShipClassId;
            VesselClassName = v.ShipClass.Name;
            if (PreviousVesselId.HasValue)
            {
                PreviousVesselId = v.PreviousVesselId;
                PreviousVesselName = v.PreviousVessel.Name;
            }
            EventIds = new List<Guid>();
            foreach(VesselEvent evt in v.Events)
            {
                EventIds.Add(evt.EventId);
            }
        }
        public Guid VesselId { get; set; }
        public string VesselName { get; set; }
        public Guid VesselClassId { get; set; }
        public string VesselClassName { get; set; }
        public Guid? PreviousVesselId { get; set; }
        public string PreviousVesselName { get; set; }
        public List<Guid> EventIds { get; set; }
    }
}
