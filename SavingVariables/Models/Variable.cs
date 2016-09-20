﻿using System.ComponentModel.DataAnnotations;

namespace SavingVariables.Models
{
    public class Variable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(1, ErrorMessage = "Only a single letter may be entered for Name")]
        public string Name { get; set; }
        [Required]
        public int Value { get; set; }
    }
}