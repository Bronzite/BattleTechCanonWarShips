using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleTechCanonWarships.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<VesselEvent> Vessels { get; set; }
        public Guid? LocationId { get; set; }
        public Location Location { get; set; }

        public string GetDateString()
        {
            if (StartDate.Year < 1900) return "Date Unknown";
            if (StartDate == EndDate) return StartDate.ToLongDateString();
            return string.Format("{0} - {1}", StartDate.ToLongDateString(), EndDate.ToLongDateString());
        }
    }

    public class EventSummary
    {
        public EventSummary(Event e)
        {
            Id = e.Id;
            Title = e.Title;
            StartDate = e.StartDate;
            EndDate = e.EndDate;
            Vessels = e.Vessels.Count;
            Location = new LocationSummary(e.Location);
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Vessels { get; set; }
        public LocationSummary Location { get; set; }
    }

    public class EventDetail
    {
        public EventDetail(Event e)
        {
            Id = e.Id;
            Title = e.Title;
            Description = e.Description;
            StartDate = e.StartDate;
            EndDate = e.EndDate;
            VesselEvents = new List<VesselEventDetail>();
            foreach (VesselEvent v in e.Vessels)
            {
                VesselEvents.Add(new VesselEventDetail(v));
            }
            Location = new LocationSummary(e.Location);
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<VesselEventDetail> VesselEvents { get; set; }
        public LocationSummary Location { get; set; }
    }
}
