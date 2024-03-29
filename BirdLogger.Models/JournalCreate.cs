﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class JournalCreate
    {
        [Key]
        [Display(Name ="Bird ID")]
        public int  LoggerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }

        [MaxLength(8000)]
        [Display(Name ="Body")]
        public string Content { get; set; }

    }
}
