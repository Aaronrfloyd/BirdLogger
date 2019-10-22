using BirdLogger.Data;
using BirdLogger.Models;
using BirdLogger.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BirdLogger.Web.MVC.Controllers
{
    [Authorize]
    public class JournalController : Controller
    {
        // GET: Journal
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalService(userId);
            var model = service.GetJournals();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateJournalService();

            if (service.CreateJournal(model))
            {
                TempData["SaveResult"] = "Your journal was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Journal could not be created.");

            return View(model);
        }

        private JournalService CreateJournalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalService(userId);
            return service;
        }
    }
}