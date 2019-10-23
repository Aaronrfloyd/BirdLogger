﻿using BirdLogger.Models;
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

        private NestService CreateNestService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NestService(userId);
            return service;
        }
    }
}