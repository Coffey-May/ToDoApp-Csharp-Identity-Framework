﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppIdentityFW.Models
{
    public class ToDoStatus
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
