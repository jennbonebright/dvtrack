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
    public class CoachesController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Coaches/
        public ActionResult Staff(string id)
        {
            //switch (id)
            //{
            //    case "sprint":
            //        ViewBag.Message = "Thunder Sprint Coaches";
            //        break;
            //    case "dist":
            //        ViewBag.Message = "Thunder Distance Coaches";
            //        break;
            //    case "vj":
            //        ViewBag.Message = "Thunder Vertical Jumps Coaches";
            //        break;
            //    case "hj":
            //        ViewBag.Message = "Thunder Hortizontal Jumps Coaches";
            //        break;
            //    case "throw":
            //        ViewBag.Message = "Thunder Throwing Coaches";
            //        break;
            //    default:
                    ViewBag.Message = "Thunder Coaches";
            //        break;
            //}

            var filtered = (from all in db.Coaches
                            where all.Active == true
                            orderby all.Head descending, all.Group, all.Title descending, all.Event ascending
                            select all).ToList();
            return View(filtered);
        }


        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            return View(db.Coaches.ToList());
        }

        //
        // GET: /Coaches/Details/5

        public ActionResult Details(int id = 0)
        {
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        //
        // GET: /Coaches/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            return View();
        }

        //
        // POST: /Coaches/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Coach coach)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            if (ModelState.IsValid)
            {
                db.Coaches.Add(coach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coach);
        }

        //
        // GET: /Coaches/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        //
        // POST: /Coaches/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Coach coach)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            if (ModelState.IsValid)
            {
                db.Entry(coach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coach);
        }

        //
        // GET: /Coaches/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            Coach coach = db.Coaches.Find(id);
            if (coach == null)
            {
                return HttpNotFound();
            }
            return View(coach);
        }

        //
        // POST: /Coaches/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Staff");
            }
            Coach coach = db.Coaches.Find(id);
            db.Coaches.Remove(coach);
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