using BirdLogger.Models;
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
            var model = new NestListItem[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NestCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}