using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BattleTechCanonWarships.Models;
using Microsoft.AspNetCore.Mvc;

namespace BattleTechCanonWarships.Controllers
{
    public class ShipClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/ShipClass/Detail/{guid}")]
        public IActionResult Detail(Guid guid)
        {
            ShipClass retval = SiteStatics.Context.ShipClasses.Find(guid) as ShipClass;
            
            if (retval == null) return Redirect("/");
            SiteStatics.Context.Entry(retval).Collection("Vessels").Load();
            
            return View(retval);
        }
    }
}