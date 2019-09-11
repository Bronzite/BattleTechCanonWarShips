using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class APIController : Controller
    {
        [Route("/api/Vessel/Detail/{id}")]
        public IActionResult VesselDetail(Guid id)
        {
            Vessel retval = SiteStatics.Context.Vessels.Find(id);
            SiteStatics.Context.Entry(retval).Reference("ShipClass").Load();
            SiteStatics.Context.Entry(retval).Collection("Events").Load();
            SiteStatics.Context.Entry(retval).Reference("PreviousVessel").Load();
            return new JsonResult(new VesselDetail( retval));
        }

        [Route("/api/Vessels")]
        public IActionResult VesselList()
        {
            IEnumerable<Vessel> vessels = SiteStatics.Context.Vessels;
            List<VesselSummary> retval = new List<VesselSummary>();
            foreach (Vessel v in vessels)
            {
                SiteStatics.Context.Entry(v).Reference("ShipClass").Load();
                retval.Add(new VesselSummary(v));
            }

            return new JsonResult(retval);
        }

        [Route("/api/ShipClasses")]
        public IActionResult ShipClassList()
        {
            IEnumerable<ShipClass> shipclasses = SiteStatics.Context.ShipClasses;
            List<ShipClassSummary> retval = new List<ShipClassSummary>();
            foreach (ShipClass sc in shipclasses)
            {
                SiteStatics.Context.Entry(sc).Collection("Vessels").Load();
                retval.Add(new ShipClassSummary(sc));
            }

            return new JsonResult(retval);
        }

        [Route("/api/ShipClass/{id}")]
        public IActionResult ShipClassDetail(Guid id)
        {
            ShipClass shipclass = SiteStatics.Context.ShipClasses.Find(id);
            SiteStatics.Context.Entry(shipclass).Collection("Vessels").Load();
            ShipClassDetail retval = new ShipClassDetail(shipclass);
            
            
            return new JsonResult(retval);
        }

        [Route("/api/Locations")]
        public IActionResult LocationList()
        {
            IEnumerable<Location> shipclasses = SiteStatics.Context.Locations;
            List<LocationSummary> retval = new List<LocationSummary>();
            //TODO: Maybe we can link up all locations in the webserver using the list we just downloaded?
            foreach (Location loc in shipclasses)
            {
                //Not loading all locations for time management purposes.
                retval.Add(new LocationSummary(loc));
            }


            return new JsonResult(retval);
        }

        [Route("/api/Location/{id}")]
        public IActionResult LocationDetail(Guid id)
        {
            Location location = SiteStatics.Context.Locations.Find(id);
            location.FullLoad();
            LocationDetail retval = new LocationDetail(location);


            return new JsonResult(retval);
        }

        [Route("/api/Events")]
        public IActionResult EventList()
        {
            IEnumerable<Event> events = SiteStatics.Context.Event;
            List<EventSummary> retval = new List<EventSummary>();
            
            foreach (Event curEvent in events)
            {
                SiteStatics.Context.Entry(curEvent).Reference("Location").Load();
                SiteStatics.Context.Entry(curEvent).Collection("Vessels").Load();
                retval.Add(new EventSummary(curEvent));
            }


            return new JsonResult(retval);
        }

        [Route("/api/Event/{id}")]
        public IActionResult EventDetail(Guid id)
        {
            Event curevent = SiteStatics.Context.Event.Find(id);
            SiteStatics.Context.Entry(curevent).Reference("Location").Load();
            SiteStatics.Context.Entry(curevent).Collection("Vessels").Load();
            foreach(VesselEvent ve in curevent.Vessels)
            {
                ve.Event = curevent;
                SiteStatics.Context.Entry(ve).Reference("Vessel").Load();
                SiteStatics.Context.Entry(ve.Vessel).Reference("ShipClass").Load();
                SiteStatics.Context.Entry(ve).Collection("References").Load();
                SiteStatics.Context.Entry(ve).Collection("PropertyChanges").Load();
                foreach(Reference r in ve.References)
                {
                    SiteStatics.Context.Entry(r).Reference("Source").Load();
                }
                foreach(Vessel.PropertyChange pc in ve.PropertyChanges)
                {
                    SiteStatics.Context.Entry(pc).Reference("Property").Load();

                }
            }

            EventDetail retval = new EventDetail(curevent);


            return new JsonResult(retval);
        }
    }
}