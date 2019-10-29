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
    public class NestController : Controller
    {
        // GET: Nest
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NestService(userId);
            var model = service.GetNest();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NestCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateNestService();

            if (service.CreateNest(model))
            {
                TempData["SaveResult"] = "Your nest was created.";
                return RedirectToAction("Index");

            };

            ModelState.AddModelError("", "Nest could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateNestService();
            var model = svc.GetNestById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateNestService();
            var detail = service.GetNestById(id);
            var model = new NestEdit
            {
                LoggerId = detail.LoggerId,
                OwnerId = detail.OwnerId,
                Site = detail.Site,
                Materials = detail.Materials,
                Altitude = detail.Altitude,
                Eggs = detail.Eggs,
                Hatchlings = detail.Hatchlings,
                NestId = detail.NestId,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NestEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NestId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateNestService();

            if (service.UpdateNest(model))
            {
                TempData["SaveResult"] = "Your nest was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "your nest could not be updated.");
            return View(model);
        }


        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateNestService();
            var model = svc.GetNestById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateNestService();
            service.DeleteNest(id);
            TempData["SaveResult"] = "Your nest was deleted.";
            return RedirectToAction("Index");
        }

        private NestService CreateNestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NestService(userId);
            return service;
        }
    }
}