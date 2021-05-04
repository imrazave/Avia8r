using Avia8r.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Avia8r.Controllers
{
    public class MxEventController : Controller
    {
        [Authorize]
        // GET: FlightLeg
        public ActionResult Index()
        {
            var model = new MxEventListItem[0];
            return View(model);
        }
    }
}