using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using BattleTechCanonWarships.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class SearchController : Controller
    {
        [Route("/Search/{query}")]
        public IActionResult Results(string query)
        {
            if (query.Trim().Length < 3) return Redirect("/");

            SearchResultModelView retval = new SearchResultModelView();
            retval.Query = query;
            retval.ShipClasses = new List<ShipClass>( SiteStatics.Context.ShipClasses.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
            retval.Vessels = new List<Vessel>(SiteStatics.Context.Vessels.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
            retval.Events = new List<Event>(SiteStatics.Context.Event.Where(x => x.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.Title.Contains(query,StringComparison.CurrentCultureIgnoreCase)));
            retval.Locations = new List<Location>(SiteStatics.Context.Locations.Where(x => x.Name.Contains(query,StringComparison.CurrentCultureIgnoreCase)));



            return View(retval);
        }

        [HttpPost]
        public IActionResult Results(FormCollection formCollection)
        {
            string query = "";
            if (formCollection.ContainsKey("query")) query = formCollection["query"];

            if (query.Trim().Length < 3) return Redirect("/");

            SearchResultModelView retval = new SearchResultModelView();
            retval.Query = query;
            retval.ShipClasses = new List<ShipClass>(SiteStatics.Context.ShipClasses.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
            retval.Vessels = new List<Vessel>(SiteStatics.Context.Vessels.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
            retval.Events = new List<Event>(SiteStatics.Context.Event.Where(x => x.Description.Contains(query, StringComparison.CurrentCultureIgnoreCase) || x.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase)));
            retval.Locations = new List<Location>(SiteStatics.Context.Locations.Where(x => x.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)));



            return View(retval);
        }
    }
}