using DVTrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVTrack.Controllers
{
    public class HomeController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Articles/

        public ActionResult Index()
        {
            ViewBag.Message = "Thunder Track and Field";

            return View(db.Articles.Where(e => e.ExternalLink == null).OrderByDescending(o => o.PostedDate).Take(3).ToList());
        }

        public ActionResult Calendar()
        {
            return View("Calendar");
        }
    }
}
