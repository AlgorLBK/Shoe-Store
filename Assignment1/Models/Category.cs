﻿using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Please enter a category name.")]
        public string Name { get; set; }
    }
}
