using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueensFinal.Model;

namespace QueensFinal.Controllers
{
    public class CompetitorController : Controller
    {
        private QueensFinalDb db = new QueensFinalDb();

        //
        // GET: /Competitor/

        public ActionResult Index()
        {
            return View(db.RegisterCards.ToList());
        }

        //
        // GET: /Competitor/Details/5

        public ActionResult Details(int id = 0)
        {
            RegisterCard competitor = db.RegisterCards.Find(id);
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
        public ActionResult Create(RegisterCard competitor)
        {
            if (ModelState.IsValid)
            {
                db.RegisterCards.Add(competitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competitor);
        }

        //
        // GET: /Competitor/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RegisterCard competitor = db.RegisterCards.Find(id);
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
        public ActionResult Edit(RegisterCard competitor)
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
            RegisterCard competitor = db.RegisterCards.Find(id);
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
            RegisterCard competitor = db.RegisterCards.Find(id);
            db.RegisterCards.Remove(competitor);
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