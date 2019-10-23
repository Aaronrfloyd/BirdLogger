using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class JournalEdit
    {
        public int JournalId { get; set; }
        public int LoggerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
