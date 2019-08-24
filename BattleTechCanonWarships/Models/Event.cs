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
}
