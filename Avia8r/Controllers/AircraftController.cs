using Avia8r.Models;
using Avia8r.Services;
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
        private AircraftService _service = new AircraftService();
        // GET: Aircraft
        public ActionResult Index()
        {
            //var model = new AircraftListItem[0];
            //var userId = Guid.Parse(User.Identity.GetUserId());
            //var service = new AircraftService(userId);
            var model = _service.GetAircraft();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AircraftCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_service.CreateAircraft(model))
            {
                TempData["SaveResult"] = "Your aircraft was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Aircraft could not be created");

            return View(model);
        }

        public ActionResult Details(string AcTail)
        {
            var svc = CreateAircraftService();
            var model = svc.GetNoteById(AcTail);

            return View(model);
        }
    }
}