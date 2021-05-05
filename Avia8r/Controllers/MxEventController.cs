using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avia8r.Controllers
{
    private MxEventService _service = new MxEventService();
    public class MxEventController : Controller
    {
        [Authorize]
        // GET: FlightLeg
        public ActionResult Index()
        {
            var model = new MxEventListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        //GET
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MxEventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (_service.CreateMxEvent(model))
            {
                TempData["SaveResult"] = "Your maintenance event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "maintenance event could not be created");

            return View(model);
        }
        public ActionResult Details(string id)
        {
            var svc = _service;
            var model = svc.GetMxEventByMxId(id);

            return View(model);
        }
        public ActionResult Edit(string id)
        {
            var svc = _service;
            var detail = svc.GetMxEventByMxId(id);
            var model =
                new MxEventEdit
                {
                    MxId = detail.MxId,
                    AcTail = detail.AcTail,
                    TypeOfMx = detail.TypeOfMx,
                    MxDescription = detail.MxDescription,
                    ManHours = detail.ManHours,
                    HoursOutOfService = detail.HoursOutOfService,
                    Cost = detail.Cost
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, MxEventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TripId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var svc = _service;
            if (svc.UpdateMxEvent(model))
            {
                TempData["SaveResult"] = "Your maintenance event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your maintenance event could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(string id)
        {
            var svc = _service;
            var model = svc.GetMxEventById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMxEvent(string id)
        {
            var svc = _service;
            svc.DeleteMX(id);

            TempData["SaveResult"] = "Your maintenance event was deleted";

            return RedirectToAction("Index");
        }
    }
}