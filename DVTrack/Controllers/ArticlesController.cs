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
    public class ArticlesController : Controller
    {
        private TrackContext db = new TrackContext();

        //
        // GET: /Articles/
        public ActionResult News()
        {
            ViewBag.Message = "Thunder News";
            return View(db.Articles.OrderByDescending(e=>e.PostedDate).Take(3).ToList());
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            DateTime _LastYear = DateTime.Today.AddMonths(-12);
            return View(db.Articles.Where(e => e.PostedDate > _LastYear).OrderByDescending(e => e.PostedDate).ToList());
        }

        //
        // GET: /Articles/Details/5

        public ActionResult Details(int id = 0)
        {
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // GET: /Articles/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            return View();
        }

        //
        // POST: /Articles/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            if (ModelState.IsValid)
            {
                article.PostedDate = DateTime.UtcNow.AddHours(-7);
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        //
        // GET: /Articles/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Articles/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            if (ModelState.IsValid)
            {
                article.PostedDate = DateTime.UtcNow.AddHours(-7);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        //
        // GET: /Articles/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        //
        // POST: /Articles/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("News");
            }
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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