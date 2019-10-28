using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class LoggerDetails
    {
        [Display(Name ="Bird ID")]
        public int LoggerId { get; set; }
        public Guid OwnerId { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Activity { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        
    }
}
