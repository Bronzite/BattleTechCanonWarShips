using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using BattleTechCanonWarships.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleTechCanonWarships.Controllers
{
    public class LocationController : Controller
    {
        [Route("/Location/{guid}")]
        public async Task<IActionResult> Detail(Guid guid)
        {
            List<Location> lstLocations = await SiteStatics.Context
                                                   .Locations
                                                   .Where(x => x.Id == guid)
                                                   .Include(x=>x.ParentLocation)
                                                   .ToListAsync();

            Location selectedLocation = lstLocations.First();
            if (selectedLocation == null) return Redirect("/");
            LocationModelView retval = new LocationModelView();
            retval.Location = selectedLocation;
            retval.ChildLocations = new List<Location>(SiteStatics.Context.Locations.Where(x => x.ParentLocationId == selectedLocation.Id));
            retval.Events = new List<Event>(SiteStatics.Context.Event.Where(x => x.LocationId == selectedLocation.Id));

            return View(retval);
        }
    }
}