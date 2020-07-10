using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using BattleTechCanonWarships.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BattleTechCanonWarships.Controllers
{
    public class SearchController : Controller
    {
        [Route("/Search/{query}")]
        public async Task<IActionResult> Results(string query)
        {
            if (query.Trim().Length < 3) return Redirect("/");

            SearchResultModelView retval = new SearchResultModelView();
            retval.Query = query;
            retval.ShipClasses = await SiteStatics.Context.ShipClasses
                                                          .Where(x =>x.Name.Contains(query))
                                                          .ToListAsync();
            retval.Vessels = await SiteStatics.Context.Vessels
                                                .Include(x => x.ShipClass)
                                                .Where(x => x.Name.Contains(query))
                                                .ToListAsync();
            retval.Events = await SiteStatics.Context.Event
                                                     .Where(x => x.Description.Contains(query) || x.Title.Contains(query))
                                                     .ToListAsync();
            retval.Locations = await SiteStatics.Context.Locations
                                                        .Where(x => x.Name.Contains(query))
                                                        .ToListAsync();


            return View(retval);
        }

        [HttpPost]
        public async Task<IActionResult> Results(FormCollection formCollection)
        {
            string query = "";
            if (formCollection.ContainsKey("query")) query = formCollection["query"];

            if (query.Trim().Length < 3) return Redirect("/");

            SearchResultModelView retval = new SearchResultModelView();
            retval.Query = query;
            retval.ShipClasses = await SiteStatics.Context.ShipClasses
                                                          .Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                                                          .ToListAsync();
            retval.Vessels = await SiteStatics.Context.Vessels
                                                .Include(x => x.ShipClass)
                                                .Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                                                .ToListAsync();
            retval.Events = await SiteStatics.Context.Event
                                                     .Where(x => x.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                                                     .ToListAsync();
            retval.Locations = await SiteStatics.Context.Locations
                                                        .Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase))
                                                        .ToListAsync();



            return View(retval);
        }
    }
}