using BirdLogger.Data;
using BirdLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.service
{
    public class NestService
    {

        private readonly Guid _userId;

        public NestService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNest(NestCreate model)
        {
            var entity =
                new Nest()
                {
                    OwnerId = _userId,
                    NestId = model.NestId,
                    LoggerId = model.LoggerId,
                    JournalId = model.JournalId,
                    Site = model.Site,
                    Materials = model.Materials,
                    Altitude = model.Altitude,
                    Eggs = model.Eggs,
                    Hatchlings = model.Hatchlings,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nests.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<NestListItem> GetNest()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Nests
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new NestListItem
                                {
                                    NestId = e.NestId,
                                    LoggerId = e.LoggerId,
                                    JournalId = e.JournalId,
                                    Site = e.Site,
                                    Materials = e.Materials,
                                    Altitude = e.Altitude,
                                    Eggs = e.Eggs,
                                    Hatchlings = e.Hatchlings,
                                    CreatedUtc = DateTimeOffset.Now
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
