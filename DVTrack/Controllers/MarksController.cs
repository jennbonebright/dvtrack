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
    public class MarksController : Controller
    {
        private TrackContext db = new TrackContext();
        public class Classes
        {
            public string Value { get; set; }
            public string Label { get; set; }
        }

        public class Events
        {
            public string Value { get; set; }
            public string Label { get; set; }
        }

        //
        // GET: /Marks/
        public ActionResult Stats()
        {
            ViewBag.Message = "Thunder Records";

            List<Classes> ListItems = new List<Classes>();
            ListItems.Add(new Classes { Value = "0", Label = "All Time" });
            ListItems.Add(new Classes { Value = "1", Label = "Class Records" });
            SelectList _classes = new SelectList(ListItems, "Value", "Label");
            ViewBag.Classes = _classes;

            List<Events> ListItems2 = new List<Events>();
            ListItems2.Add(new Events { Value = "100", Label = "100 Meter Run" });
            ListItems2.Add(new Events { Value = "200", Label = "200 Meter Run" });
            ListItems2.Add(new Events { Value = "400", Label = "400 Meter Run" });
            ListItems2.Add(new Events { Value = "800", Label = "800 Meter Run" });
            ListItems2.Add(new Events { Value = "1600", Label = "1600 Meter Run" });
            ListItems2.Add(new Events { Value = "3200", Label = "3200 Meter Run" });
            ListItems2.Add(new Events { Value = "100H", Label = "100 Meter Hurdles" });
            ListItems2.Add(new Events { Value = "110H", Label = "110 Meter Hurdles" });
            ListItems2.Add(new Events { Value = "300H", Label = "300 Meter Hurdles" });
            ListItems2.Add(new Events { Value = "SP", Label = "Shot Put" });
            ListItems2.Add(new Events { Value = "DT", Label = "Discus" });
            ListItems2.Add(new Events { Value = "JT", Label = "Javelin" });
            ListItems2.Add(new Events { Value = "PV", Label = "Pole Vault" });
            ListItems2.Add(new Events { Value = "HJ", Label = "High Jump" });
            ListItems2.Add(new Events { Value = "LJ", Label = "Long Jump" });
            ListItems2.Add(new Events { Value = "TJ", Label = "Triple Jump" });
            SelectList _events = new SelectList(ListItems2, "Value", "Label");
            ViewBag.Events = _events;

            var bestMarks = (from p in db.Marks
                             where p.Event == "100"
                             group p by p.AthleteName into grps
                             select new
                             {
                                 Key = grps.Key,
                                 Values = grps,
                                 BestTime = grps.Min
                                       (g => g.Time)
                             });

            var res =
                (from cv in db.Marks
                 join gm in
                     bestMarks on new { cv.Time, cv.AthleteName } equals new { Time = gm.BestTime, AthleteName = gm.Key }
                 orderby cv.Time ascending
                 select cv).ToList();

            return View(res);
        }

        public ActionResult MoreMarks()
        {
            return View();
        }

        public ActionResult Refresh(string EventId, int ClassId)
        {

            if (ClassId == 0)
            {
                var bestMarks = (from p in db.Marks
                                 where p.Event == EventId
                                 group p by p.AthleteName into grps
                                 select new
                                 {
                                     Key = grps.Key,
                                     Values = grps,
                                     Event = grps.Min(e => e.Event),
                                     BestTime = grps.Min(g => g.Time),
                                     BestMeters = grps.Max(g => g.Meters),
                                     BestInches = grps.Max(g => g.Inches)
                                 });

                var res =
                    (from cv in db.Marks
                     join gm in
                         bestMarks on new { cv.Event, cv.Time, cv.Meters, cv.Inches, cv.AthleteName } equals new { Event = gm.Event, Time = gm.BestTime, Meters = gm.BestMeters, Inches = gm.BestInches, AthleteName = gm.Key }
                     orderby cv.Time ascending, cv.Meters descending, cv.Inches descending, cv.Year
                     select cv).ToList();
                return PartialView("PartialMarks", res);

            }
            else
            {
                var bestMarks = (from p in db.Marks
                                 where p.Event == EventId && p.Grade > 0
                                 group p by new { p.Grade, p.Gender } into grps
                                 select new
                                 {
                                     Key = grps.Key,
                                     Values = grps,
                                     Event = grps.Min(e => e.Event),
                                     BestTime = grps.Min(g => g.Time),
                                     BestMeters = grps.Max(g => g.Meters),
                                     BestInches = grps.Max(g => g.Inches)
                                 });

                var res =
                    (from cv in db.Marks
                     join gm in
                         bestMarks on new { cv.Event, cv.Time, cv.Meters, cv.Inches, cv.Grade, cv.Gender } equals new { Event = gm.Event, Time = gm.BestTime, Meters = gm.BestMeters, Inches = gm.BestInches, Grade = gm.Key.Grade, Gender = gm.Key.Gender }
                     orderby cv.Time ascending, cv.Meters descending, cv.Inches descending
                     select cv).ToList();
                return PartialView("PartialMarks", res);
            }
        }

        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            return View(db.Marks.Where(e => e.Year == db.Marks.Max(d => d.Year)).ToList().OrderBy(f => f.Event));
        }

        //
        // GET: /Marks/Details/5

        public ActionResult Details(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        //
        // GET: /Marks/Create

        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            return View();
        }

        //
        // POST: /Marks/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mark mark)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            if (ModelState.IsValid)
            {
                db.Marks.Add(mark);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mark);
        }

        //
        // GET: /Marks/Edit/5

        public ActionResult Edit(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        //
        // POST: /Marks/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mark mark)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            if (ModelState.IsValid)
            {
                db.Entry(mark).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mark);
        }

        //
        // GET: /Marks/Delete/5

        public ActionResult Delete(int id = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            Mark mark = db.Marks.Find(id);
            if (mark == null)
            {
                return HttpNotFound();
            }
            return View(mark);
        }

        //
        // POST: /Marks/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Stats");
            }
            Mark mark = db.Marks.Find(id);
            db.Marks.Remove(mark);
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