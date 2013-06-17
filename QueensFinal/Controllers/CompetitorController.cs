using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueensFinal.Models;

namespace QueensFinal.Controllers
{
    public class CompetitorController : Controller
    {
        private QueensFinalDb db = new QueensFinalDb();

        //
        // GET: /Competitor/

        public ActionResult Index()
        {
            return View(db.Competitors.ToList());
        }

        //
        // GET: /Competitor/Details/5

        public ActionResult Details(int id = 0)
        {
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        //
        // GET: /Competitor/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Competitor/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                db.Competitors.Add(competitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competitor);
        }

        //
        // GET: /Competitor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        //
        // POST: /Competitor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competitor competitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competitor);
        }

        //
        // GET: /Competitor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Competitor competitor = db.Competitors.Find(id);
            if (competitor == null)
            {
                return HttpNotFound();
            }
            return View(competitor);
        }

        //
        // POST: /Competitor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competitor competitor = db.Competitors.Find(id);
            db.Competitors.Remove(competitor);
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