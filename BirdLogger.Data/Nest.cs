using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Data
{
    public class Nest
    {
        
        public int NestId { get; set; }

        [ForeignKey("LoggerVariable")]
        public int LoggerId { get; set; }
        public virtual Logger LoggerVariable { get; set; }
        public Guid OwnerId { get; set; }
        public string Site { get; set; }
        public string Materials { get; set; }
        public string Altitude { get; set; }
        public int Eggs { get; set; }
        public int Hatchlings { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
