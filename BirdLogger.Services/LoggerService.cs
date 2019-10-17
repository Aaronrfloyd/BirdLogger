using BirdLogger.Data;
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
                                        LoggerId = e.LoggerID,
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
    }
}
