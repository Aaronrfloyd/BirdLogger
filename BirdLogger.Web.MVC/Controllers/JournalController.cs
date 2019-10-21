using BirdLogger.Models;
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
            var model = new JournalListItem[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);

        }
    }
}