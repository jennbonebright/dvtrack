using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVTrack.Models;

namespace DVTrack.Controllers
{
    public class MeetsController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Meets/
        public ActionResult Schedule()
        {
            int _year = DateTime.Today.AddMonths(5).Year;
            ViewBag.Message = "Thunder " + _year + " Schedule*";
            return View(db.Meets.Where(e=>e.YearId == _year).OrderBy(s => s.MeetDate).ToList());
        }
        public ActionResult Calendar()
        {
            int _year = DateTime.Today.AddMonths(5).Year;
            ViewBag.Message = "Thunder " + _year + " Schedule*";
            return View();
        }
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            DateTime _LastYear = DateTime.Today.AddMonths(-12);
            return View(db.Meets.Where(e => e.MeetDate > _LastYear).OrderByDescending(s => s.YearId).ThenBy(s => s.MeetDate).ToList());
        }

        //
        // GET: /Meets/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        //
        // GET: /Meets/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            return View();
        }

        //
        // POST: /Meets/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Meet meet)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            if (ModelState.IsValid)
            {
                db.Meets.Add(meet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meet);
        }

        //
        // GET: /Meets/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        //
        // POST: /Meets/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Meet meet)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            if (ModelState.IsValid)
            {
                db.Entry(meet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meet);
        }

        //
        // GET: /Meets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        //
        // POST: /Meets/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Schedule");
            }
            Meet meet = db.Meets.Find(id);
            db.Meets.Remove(meet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}