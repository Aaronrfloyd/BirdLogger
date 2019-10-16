using BirdLogger.Models;
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
            var model = new LoggerListItem[0];
            return View();
        }
    }
}