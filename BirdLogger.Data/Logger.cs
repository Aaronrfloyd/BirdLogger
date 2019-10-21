using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Data
{
    public class Logger
    {
        public int LoggerId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Display(Name = "What type of Bird?")]
        public string Type { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Activity { get; set; }
        [Required]
        public DateTime CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        

    }
}
