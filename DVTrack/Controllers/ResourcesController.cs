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
    public class ResourcesController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Resources/
        public ActionResult Resources()
        {
            return View(db.Resources.OrderBy(e => e.Title).ToList());
        }

        public ActionResult Sponsors()
        {
            return View();
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            return View(db.Resources.OrderBy(e => e.Title).ToList());
        }

        //
        // GET: /Resources/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        //
        // GET: /Resources/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            return View();
        }

        //
        // POST: /Resources/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resource resource)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            if (ModelState.IsValid)
            {
                db.Resources.Add(resource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resource);
        }

        //
        // GET: /Resources/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        //
        // POST: /Resources/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Resource resource)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            if (ModelState.IsValid)
            {
                db.Entry(resource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resource);
        }

        //
        // GET: /Resources/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            Resource resource = db.Resources.Find(id);
            if (resource == null)
            {
                return HttpNotFound();
            }
            return View(resource);
        }

        //
        // POST: /Resources/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Resources");
            }
            Resource resource = db.Resources.Find(id);
            db.Resources.Remove(resource);
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