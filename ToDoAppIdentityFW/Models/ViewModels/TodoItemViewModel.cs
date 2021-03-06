﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoAppIdentityFW.Models.ViewModels
{
    public class TodoItemViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string Title { get; set; }
        [Required]

        public int TodoStatusId { get; set; }

        public ToDoStatus ToDoStatus { get; set; }
        [Required]

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<SelectListItem> ToDoStatusOptions { get; set; }

    }
}