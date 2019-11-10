using BirdLogger.service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BirdLogger.WebAPI.Controllers
{
    [Authorize]
    public class LoggerController : ApiController
    {
        public IHttpActionResult Get()
        {
            LoggerService loggerService = CreateLoggerService();
            var loggers = loggerService.GetLogger();
            return Ok(loggers);
        }
        private LoggerService CreateLoggerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var loggerService = new LoggerService(userId);
            return loggerService;
        }

    }
}
