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
    public class OfficersController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Officers/

        public ActionResult Index()
        {
            
            return PartialView(db.BoosterOfficers.ToList());
        }

        //
        // GET: /Officers/Details/5

        public ActionResult Details(int id = 0)
        {
            Officer officer = db.BoosterOfficers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        //
        // GET: /Officers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Officers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.BoosterOfficers.Add(officer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officer);
        }

        //
        // GET: /Officers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Officer officer = db.BoosterOfficers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        //
        // POST: /Officers/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officer);
        }

        //
        // GET: /Officers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Officer officer = db.BoosterOfficers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        //
        // POST: /Officers/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Officer officer = db.BoosterOfficers.Find(id);
            db.BoosterOfficers.Remove(officer);
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