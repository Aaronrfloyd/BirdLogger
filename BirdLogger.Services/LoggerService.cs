﻿using BirdLogger.Data;
using BirdLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Services
{
    public class LoggerService
    {
        private readonly Guid _userId;

        public LoggerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLogger(LoggerCreate model)
        {
            var entity = new Logger()
            {
                OwnerId = _userId,
                Type = model.Type,
                Location = model.Location,
                Size = model.Size,
                Color = model.Color,
                Activity = model.Activity,
                CreatedUtc = DateTime.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Loggers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LoggerListItem> GetLogger()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Loggers
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LoggerListItem
                                {
                                    LoggerId = e.LoggerId,
                                    Type = e.Type,
                                    Location = e.Location,
                                    Size = e.Size,
                                    Color = e.Color,
                                    Activity = e.Activity,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public LoggerDetails GetLoggerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Loggers
                                .Single(e => e.LoggerId == id && e.OwnerId == _userId);

                return new LoggerDetails
                {
                    LoggerId = entity.LoggerId,
                    Type = entity.Type,
                    Location = entity.Location,
                    Size = entity.Size,
                    Color = entity.Color,
                    Activity = entity.Activity,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc

                };


            }
        }

    }
}
