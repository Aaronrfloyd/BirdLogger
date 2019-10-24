﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class JournalListItem
    {
        [Display(Name="Journal ID")]
        public int JournalId { get; set; }
        public int LoggerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
