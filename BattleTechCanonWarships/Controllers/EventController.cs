using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Detail(Guid guid)
        {
            List<Event> lstEvents = await SiteStatics.Context
                                                     .Event
                                                     .Where(x => x.Id == guid)
                                                     .Include(x=>x.Vessels)
                                                     .ThenInclude(y=>y.Vessel)
                                                     .Include(x=>x.Location)
                                                     .ToListAsync();
            Event retval = lstEvents.First();
            if (retval == null) return Redirect("/");

            return View(retval);
        }
}
}