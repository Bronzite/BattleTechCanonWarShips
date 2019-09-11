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

    public class VesselEventDetail
    {
        public VesselEventDetail(VesselEvent ve)
        {
            Id = ve.Id;
            Vessel = new VesselSummary(ve.Vessel);
            Event = new EventSummary(ve.Event);
            References = new List<ReferenceSummary>();
            foreach(Reference r in ve.References)
            {
                References.Add(new ReferenceSummary(r));
            }
            PropertyChanges = new List<PropertyChangeSummary>();
            foreach(Vessel.PropertyChange pc in ve.PropertyChanges)
            {
                PropertyChanges.Add(new PropertyChangeSummary(pc));
            }

        }
        public Guid Id { get; set; }
        public VesselSummary Vessel { get; set; }
        public EventSummary Event { get; set; }
        public ICollection<ReferenceSummary> References { get; set; }
        public ICollection<PropertyChangeSummary> PropertyChanges { get; set; }
    }

}
