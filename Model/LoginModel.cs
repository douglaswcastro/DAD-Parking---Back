using System;
using System.ComponentModel.DataAnnotations;

namespace DAD_Parking___Back.Model
{  
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public string Name { get; set; }
    }
}