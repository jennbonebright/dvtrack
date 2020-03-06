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
    public class BoostersController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Boosters/
        public ActionResult TrackFees()
        {
            ViewBag.Message = "Track Fees";
            DateTime endDate = DateTime.Today.AddMonths(5);

            ViewBag.Officers = db.BoosterOfficers.Where(e => e.Year == endDate.Year).ToList();
            return View();
        }

        public ActionResult FAQs()
        {
            ViewBag.Message = "Frequently Asked Questions";
            DateTime endDate = DateTime.Today.AddMonths(5);

            ViewBag.Officers = db.BoosterOfficers.Where(e => e.Year == endDate.Year).ToList();
            return View();
        }

        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Spirit()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            return View(db.Events.ToList());
        }

        //
        // GET: /Boosters/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            BoosterEvent boosterevent = db.Events.Find(id);
            if (boosterevent == null)
            {
                return HttpNotFound();
            }
            return View(boosterevent);
        }

        //
        // GET: /Boosters/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            return View();
        }

        //
        // POST: /Boosters/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoosterEvent boosterevent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            if (ModelState.IsValid)
            {
                db.Events.Add(boosterevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boosterevent);
        }

        //
        // GET: /Boosters/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            BoosterEvent boosterevent = db.Events.Find(id);
            if (boosterevent == null)
            {
                return HttpNotFound();
            }
            return View(boosterevent);
        }

        //
        // POST: /Boosters/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BoosterEvent boosterevent)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            if (ModelState.IsValid)
            {
                db.Entry(boosterevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boosterevent);
        }

        //
        // GET: /Boosters/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            BoosterEvent boosterevent = db.Events.Find(id);
            if (boosterevent == null)
            {
                return HttpNotFound();
            }
            return View(boosterevent);
        }

        //
        // POST: /Boosters/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Boosters");
            }
            BoosterEvent boosterevent = db.Events.Find(id);
            db.Events.Remove(boosterevent);
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