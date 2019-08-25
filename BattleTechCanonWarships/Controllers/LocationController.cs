using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using BattleTechCanonWarships.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class LocationController : Controller
    {
        [Route("/Location/{guid}")]
        public IActionResult Detail(Guid guid)
        {
            Location selectedLocation = SiteStatics.Context.Locations.Find(guid);

            if (selectedLocation == null) return Redirect("/");
            LocationModelView retval = new LocationModelView();
            retval.Location = selectedLocation;
            selectedLocation.FullLoad();
            retval.ChildLocations = new List<Location>(SiteStatics.Context.Locations.Where(x => x.ParentLocationId == selectedLocation.Id));

            retval.Events = new List<Event>(SiteStatics.Context.Event.Where(x => x.LocationId == selectedLocation.Id));

            return View(retval);
        }
    }
}