﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QueensFinal.Model;

namespace QueensFinal.Controllers
{
	public class HomeController : Controller
	{
		readonly QueensFinalDb _db = new QueensFinalDb();

		public ActionResult Index()
		{
			var model = _db.Competitions.ToList();

			return View(model);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your app description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		protected override void Dispose(bool disposing)
		{
			if (_db != null)
			{
				_db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
