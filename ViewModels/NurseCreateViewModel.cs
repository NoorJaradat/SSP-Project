using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.ViewModels
{
    public class NurseCreateViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Required]
        public SectionEnum? Section { get; set; }
        public IFormFile Photo { get; set; }
    }
}
