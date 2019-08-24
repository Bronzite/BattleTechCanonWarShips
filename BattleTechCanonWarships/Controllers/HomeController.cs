using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BattleTechCanonWarships.Models;
using BattleTechCanonWarships.ModelViews;

namespace BattleTechCanonWarships.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeIndexModelView retval = new HomeIndexModelView();
            int iVesselCount = SiteStatics.Context.Vessels.Count();
            int iClassCount = SiteStatics.Context.ShipClasses.Count();
            int iEventCount = SiteStatics.Context.Event.Count();
            Random r = new Random();
            retval.FeaturedVessel = SiteStatics.Context.Vessels.OrderBy(x => x.Id).Skip(r.Next(iVesselCount)).Take(1).Single(); 
            retval.FeaturedClass = SiteStatics.Context.ShipClasses.OrderBy(x => x.Id).Skip(r.Next(iClassCount)).Take(1).Single();
            retval.FeaturedEvent = SiteStatics.Context.Event.OrderBy(x => x.Id).Skip(r.Next(iEventCount)).Take(1).Single();



            return View(retval);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
