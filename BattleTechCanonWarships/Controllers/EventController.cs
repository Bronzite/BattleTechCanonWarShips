using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/");
        }

        [Route("/Event/Detail/{guid}")]
        [Route("/Event/{guid}")]
        public IActionResult Detail(Guid guid)
        {
            Event retval = SiteStatics.Context.Event.Find(guid) as Event;
            if (retval == null) return Redirect("/");
            SiteStatics.Context.Entry(retval).Collection("Vessels").Load();
            foreach(VesselEvent ve in retval.Vessels)
            {
                SiteStatics.Context.Entry(ve).Reference("Vessel").Load();
            }
            SiteStatics.Context.Entry(retval).Reference("Location").Load();
            retval.Location.FullLoad();
            return View(retval);
        }
}
}