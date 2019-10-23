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
        public NestDetails GetNestById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Nests
                                .Single(e => e.NestId == id && e.OwnerId == _userId);

                return new NestDetails
                {
                    NestId = entity.NestId,
                    LoggerId = entity.LoggerId,
                    Site = entity.Site,
                    Materials = entity.Materials,
                    Altitude = entity.Altitude,
                    Eggs = entity.Eggs,
                    Hatchlings = entity.Hatchlings,
                    CreatedUtc = DateTimeOffset.Now

                };
            }
        }

        public bool UpdateNest(NestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nests.Single(e => e.NestId == model.NestId && e.OwnerId == _userId);

                entity.NestId = model.NestId;
                entity.LoggerId = model.LoggerId;
                entity.Site = model.Site;
                entity.Altitude = model.Altitude;
                entity.Eggs = model.Eggs;
                entity.Hatchlings = model.Hatchlings;
                entity.CreatedUtc = DateTimeOffset.UtcNow;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNest(int nestId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nests.Single(e => e.NestId == nestId && e.OwnerId == _userId);

                ctx.Nests.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
