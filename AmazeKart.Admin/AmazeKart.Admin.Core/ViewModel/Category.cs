﻿using System.ComponentModel.DataAnnotations;

namespace AmazeKart.Admin.Core.ViewModel
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string CategoryName { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}