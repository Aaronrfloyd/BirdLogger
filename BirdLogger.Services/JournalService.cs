﻿using BirdLogger.Data;
using BirdLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Services
{
    public class JournalService
    {
        private readonly Guid _userId;
        public JournalService(Guid OwnerId)
        {
            _userId = OwnerId;
        }

        public bool CreateJournal(JournalCreate model)
        {
            var entity = new Journal()
            {
                    OwnerId = _userId,
                    LoggerId =model.LoggerId,
                    Title = model.Title,
                    Content = model.Content,
                    CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Journals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JournalListItem> GetJournals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Journals
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                    e =>
                       new JournalListItem
                       {
                           JournalId = e.JournalId,
                           Title = e.Title,
                           CreatedUtc = e.CreatedUtc,
                       }
                    );
                return query.ToArray();
            }
        }

        public JournalDetail GetJournalById (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Journals
                    .Single(e => e.JournalId == id && e.OwnerId == _userId);
                return new JournalDetail
                {
                    JournalId = entity.JournalId,
                    LoggerId = entity.LoggerId,
                    OwnerId = entity.OwnerId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc,
                };
            }
        }
    }
}

