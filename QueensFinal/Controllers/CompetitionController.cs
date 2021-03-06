﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueensFinal.Model;

namespace QueensFinal.Controllers
{
    public class CompetitionController : Controller
    {
        private QueensFinalDb db = new QueensFinalDb();

        //
        // GET: /Competition/

        public ActionResult Index()
        {
            return View(db.Competitions.ToList());
        }

        //
        // GET: /Competition/Details/Queens Final 2013

        public ActionResult Details(string name)
        {
            Competition competition = db.Competitions.Include(c => c.RegisterCards).Single(c => c.Name == name);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        //
        // GET: /Competition/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Competition/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competition);
        }

        //
        // GET: /Competition/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        //
        // POST: /Competition/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competition);
        }

        //
        // GET: /Competition/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        //
        // POST: /Competition/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competition competition = db.Competitions.Find(id);
            db.Competitions.Remove(competition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

	    public ActionResult AddShooter(int id)
	    {
		    return View();
	    }
    }
}