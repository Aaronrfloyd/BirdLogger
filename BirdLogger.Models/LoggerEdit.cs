using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class LoggerEdit
    {
        public int LoggerId { get; set; }
        public Guid  OwnerId { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Activity { get; set; }
    }
}
