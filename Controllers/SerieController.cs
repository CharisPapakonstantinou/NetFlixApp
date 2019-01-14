using NetflixApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NetflixApp.Controllers
{
    public class SerieController : Controller
    {
        private NetFlixDbContext db = new NetFlixDbContext();

        // GET: Serie
        public ActionResult Index(string searchString, string serieGenre)
        {
            var GenreList = new List<string>();
            // Bring Serie Genres From DB
            var genres = from g in db.Series
                         orderby g.Genre
                         select g.Genre;
            // Distinct Only Genres
            GenreList.AddRange(genres.Distinct());

            // Pass the Genre List to a SelectList for the View using ViewBag
            ViewBag.serieGenre = new SelectList(GenreList);

            // Bring Series From DB
            var series = from s in db.Series
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                // Limit Series based on searchString
                series = series.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(serieGenre))
            {
                // Limit Series based on SerieGenre
                series = series.Where(s => s.Genre == serieGenre);
            }

            // return new list of series
            return View(series);
        }

        // GET: Serie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // GET: Serie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Serie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,ReleaseDate,Genre,Seasons")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Series.Add(serie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serie);
        }

        // GET: Serie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Serie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,ReleaseDate,Genre,Seasons")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serie);
        }

        // GET: Serie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        // POST: Serie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serie serie = db.Series.Find(id);
            db.Series.Remove(serie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
