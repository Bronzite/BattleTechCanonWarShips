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
    }
}