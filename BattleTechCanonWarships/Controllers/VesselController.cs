using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class VesselController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/");
        }

        [Route("/Vessel/Detail/{guid}")]
        [Route("/Vessel/{guid}")]
        public IActionResult Detail(Guid guid)
        {
            Vessel thisVessel = SiteStatics.Context.Vessels.Find(guid) as Vessel;
            
            if (thisVessel == null) return Redirect("/");
            SiteStatics.Context.Entry(thisVessel).Collection("Events").Load();
            SiteStatics.Context.Entry(thisVessel).Reference("ShipClass").Load();
            SiteStatics.Context.Entry(thisVessel).Reference("PreviousVessel").Load();
            
            foreach (VesselEvent ve in thisVessel.Events)
            {
                SiteStatics.Context.Entry(ve).Reference("Event").Load();
                SiteStatics.Context.Entry(ve).Collection("PropertyChanges").Load();
                SiteStatics.Context.Entry(ve).Collection("References").Load();
                foreach (Vessel.PropertyChange p in ve.PropertyChanges)
                {
                    SiteStatics.Context.Entry(p).Reference("Property").Load();
                }
                foreach(Reference reference in ve.References)
                {
                    SiteStatics.Context.Entry(reference).Reference("Source").Load();
                }
            }
            thisVessel.Events =  new List<VesselEvent>(thisVessel.Events.OrderBy(x => x.Event.StartDate));
            return View(thisVessel);
        }
    }
}