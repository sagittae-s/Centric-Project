using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class RegisteredUser
    {
        public Guid Id { get; set; }
        
        [Required]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Full Name")]
        public string fullName 
        { get
            {
                return lastName + ", " + firstName;
            }
        }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Registration Date")]
        public DateTime registrationDate { get; set; }

        [Required]
        [Display(Name = "User's Role")]
        public roles role { get; set; }
        public enum roles 
        { 
            admin = 0,
            employee = 1,
            manager = 2,
            visitor = 3,
        }


    }
}