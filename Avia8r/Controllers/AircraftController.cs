﻿using Avia8r.Models;
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

        public ActionResult Details(string id)
        {
            var svc = _service;
            var model = svc.GetAircraftById(id);

            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var svc = _service;
            var detail = svc.GetAircraftById(id);
            var model =
                new AircraftEdit
                {
                    AcTail = detail.AcTail,
                    AcModel = detail.AcModel,
                    Manufacturer = detail.Manufacturer,
                    Airline = detail.Airline,
                };
            return View(model);
        }
    }
}