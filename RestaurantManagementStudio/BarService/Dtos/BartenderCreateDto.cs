﻿using System.ComponentModel.DataAnnotations;

namespace BarService.Dtos
{
    public class BartenderCreateDto
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
