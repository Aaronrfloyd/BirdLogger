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
        [Key]
        public int LoggerID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Display(Name = "What type of Bird?")]
        public string Type { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [Display(Name ="What is/are the bird(s) doing?")]
        public string Activity { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        

    }
}
