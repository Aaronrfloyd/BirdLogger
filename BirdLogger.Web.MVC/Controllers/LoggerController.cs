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
    public class LoggerController : Controller
    {
        // GET: Logger
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoggerService(userId);
            var model = service.GetLogger();
            
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoggerCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            

            var service = CreateLoggerService();

            if (service.CreateLogger(model))
            { 
              return RedirectToAction("Index");
            };

            return View(model);
        }

        private LoggerService CreateLoggerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new LoggerService(userId);
            return service;
        }
    }
}