using BirdLogger.Data;
using BirdLogger.Models;
using BirdLogger.service;
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

        public ActionResult Details(int id)
        {
            var svc = CreateJournalService();
            var model = svc.GetJournalById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateJournalService();
            var detail = service.GetJournalById(id);
            var model = new JournalEdit
            {
                JournalId = detail.JournalId,
                LoggerId = detail.LoggerId,
                Title = detail.Title,
                Content = detail.Content,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, JournalEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.JournalId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateJournalService();

            if (service.UpdateJournal(model))
            {
                TempData["SaveResult"] = "Your journal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your journal could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateJournalService();
            var model = svc.GetJournalById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateJournalService();

            service.DeleteJournal(id);

            TempData["SaveResult"] = "Your journal was deleted";

            return RedirectToAction("Index");
        }


        private JournalService CreateJournalService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new JournalService(userId);
            return service;
        }
    }
}