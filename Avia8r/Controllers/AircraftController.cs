using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avia8r.Controllers
{
    [Authorize]
    public class AircraftController : Controller
    {
        // GET: Aircraft
        public ActionResult Index()
        {
            var model = new AircraftListItem[0];
            return View(model);
        }
        //GET
        public ActionResult Create(AircraftCreate Model)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}