﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Data
{
    public class Journal
    {
        [Key]
        public int JournalId { get; set; }

        [ForeignKey("LoggerVariable")]
        public int LoggerId { get; set; }

        public virtual Logger LoggerVariable { get; set;}

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name ="Body")]
        public string Content { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}