﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdLogger.Models
{
    public class NestCreate
    {
       
        [Display(Name="Nest ID")]
        public int NestId { get; set; }

        [Display(Name="Bird ID")]
        public int LoggerId { get; set; }
        [Required]
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
