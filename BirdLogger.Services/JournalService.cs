using BirdLogger.Data;
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
        public JournalService(Guid userId)
        {
            _userId = userId;      
        }

        public bool CreateJournal(JournalCreate model)
        {
            var entity = new Journal()
            {
                OwnerId = _userId,
                Title = model.Title,
                Content = model.Content,
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Journal.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JournalListItem> GetJournal()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Journal.Where(e => e.OwnerId == _userId).Select(e => new JournalListItem { JournalId = e.JournalId, Title = e.Title, CreatedUtc = e.CreatedUtc });
                return query.ToArray();
            }
        }
    }
}
