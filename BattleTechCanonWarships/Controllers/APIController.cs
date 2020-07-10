using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleTechCanonWarships.Controllers
{
    public class APIController : Controller
    {
        [Route("/api/Vessel/Detail/{id}")]
        public async Task<IActionResult> VesselDetail(Guid id)
        {
            List<Vessel> vesselList = await SiteStatics.Context.Vessels
                                                 .Include(x => x.ShipClass)
                                                 .Include(x => x.Events)
                                                 .Include(x => x.PreviousVessel)
                                                 .ToListAsync();

            Vessel retval = vesselList.First();

            return new JsonResult(new VesselDetail( retval));
        }

        [Route("/api/Vessels")]
        public async Task<IActionResult> VesselList()
        {
            IEnumerable<Vessel> vessels = await SiteStatics.Context.Vessels.Include(x=>x.ShipClass).ToListAsync();
            List<VesselSummary> retval = new List<VesselSummary>();
            foreach (Vessel v in vessels)
            {
                retval.Add(new VesselSummary(v));
            }

            return new JsonResult(retval);
        }

        [Route("/api/ShipClasses")]
        public async Task<IActionResult> ShipClassList()
        {
            IEnumerable<ShipClass> shipclasses = await SiteStatics.Context.ShipClasses.Include(x=>x.Vessels).ToListAsync();
            List<ShipClassSummary> retval = new List<ShipClassSummary>();
            foreach (ShipClass sc in shipclasses)
            {
                retval.Add(new ShipClassSummary(sc));
            }

            return new JsonResult(retval);
        }

        [Route("/api/ShipClass/{id}")]
        public async Task<IActionResult> ShipClassDetail(Guid id)
        {
            List<ShipClass> lstClasses = await SiteStatics.Context
                                                          .ShipClasses
                                                          .Include(x => x.Vessels)
                                                          .Where(x => x.Id == id)
                                                          .ToListAsync();
            ShipClass shipclass = lstClasses.First();
            
            ShipClassDetail retval = new ShipClassDetail(shipclass);

            return new JsonResult(retval);
        }

        [Route("/api/Locations")]
        public async Task<IActionResult> LocationList()
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
        public async Task<IActionResult> LocationDetail(Guid id)
        {
            List<Location> locations = await SiteStatics.Context
                                           .Locations
                                           .Include(x => x.ParentLocation)
                                           .ToListAsync();
            Location location = null;
            if (locations.Count > 0) location = locations.First();

            LocationDetail retval = new LocationDetail(location);

            return new JsonResult(retval);
        }

        [Route("/api/Events")]
        public async Task<IActionResult> EventList()
        {
            IEnumerable<Event> events = await SiteStatics.Context.Event
                                                           .Include(x=>x.Location)
                                                           .Include(x=>x.Vessels)
                                                           .ToListAsync();
            List<EventSummary> retval = new List<EventSummary>();
            
            foreach (Event curEvent in events)
                retval.Add(new EventSummary(curEvent));


            return new JsonResult(retval);
        }

        [Route("/api/Event/{id}")]
        public async Task<IActionResult> EventDetail(Guid id)
        {
            List<Event> curevents = await SiteStatics.Context.Event
                                                .Include(x=>x.Vessels)
                                                .ThenInclude(y=>y.References)
                                                .ThenInclude(z=>z.Source)
                                                .Include(x=>x.Location)
                                                .Include(x=>x.Vessels)
                                                .ThenInclude(y=>y.Vessel)
                                                .ThenInclude(z=>z.ShipClass)
                                                .Include(x=>x.Vessels)
                                                .ThenInclude(y=>y.PropertyChanges)
                                                .ThenInclude(z=>z.Property)
                                                .Where(x => x.Id == id)
                                                .ToListAsync();
            Event curevent = curevents.First();
            
            EventDetail retval = new EventDetail(curevent);


            return new JsonResult(retval);
        }
    }
}