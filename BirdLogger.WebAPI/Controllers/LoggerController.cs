using BirdLogger.Models;
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
        public IHttpActionResult GetAll()
        {
            LoggerService loggerService = CreateLoggerService();
            var loggers = loggerService.GetLogger();
            return Ok(loggers);
        }
        public IHttpActionResult Get(int id)
        {
            LoggerService loggerService = CreateLoggerService();
            var logger = loggerService.GetLoggerById(id);
            return Ok();
        }

        public IHttpActionResult Post(LoggerCreate logger)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLoggerService();

            if (!service.CreateLogger(logger))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LoggerEdit logger)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLoggerService();

            if (!service.UpdateLogger(logger))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLoggerService();

            if (!service.DeleteLogger(id))
                return InternalServerError();
            return Ok();
        }

        private LoggerService CreateLoggerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var loggerService = new LoggerService(userId);
            return loggerService;
        }

    }
}
