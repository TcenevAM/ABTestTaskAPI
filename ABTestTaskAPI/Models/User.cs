using ABTestTaskAPI.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABTestTaskAPI.Models
{
    [UserDatasValidate]
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [UserRegistationDateValidate]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [UserLastActivityDateValidate]
        public DateTime LastActivityDate { get; set; }

    }
}
