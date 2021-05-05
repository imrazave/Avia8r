using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avia8r.Controllers
{
    public class FlightLegController : Controller
    {
        private FlightLegService _service = new FlightLegService();
        // GET: FlightLeg
        public ActionResult Index()
        {
            var model = _service.GetFlightLeg();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlightLegCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_service.CreateFlightLeg(model))
            {
                TempData["SaveResult"] = "Your flight leg was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "flight leg could not be created");

            return View(model);
        }
        public ActionResult Details(string id)
        {
            var svc = _service;
            var model = svc.GetFlightLegByTripId(id);

            return View(model);
        }
        public ActionResult Edit(string id)
        {
            var svc = _service;
            var detail = svc.GetFlightLegByTripId(id);
            var model =
                new FlightLegEdit
                {
                    TripId = detail.TripId,
                    OriginAirport = detail.OriginAirport,
                    DestinationAirport = detail.DestinationAirport,
                    DepartureDate = detail.DepartureDate,
                    AcTail = detail.AcTail,
                    ArrivalDate = detail.ArrivalDate
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, FlightLegEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TripId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = _service;
            if (svc.UpdateFlightLeg(model))
            {
                TempData["SaveResult"] = "Your flight leg was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your flight leg could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(string id)
        {
            var svc = _service;
            var model = svc.GetFlightLegById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFlightLeg(string id)
        {
            var svc = _service;
            svc.DeleteFL(id);

            TempData["SaveResult"] = "Your flight leg was deleted";

            return RedirectToAction("Index");
        }

    }
}