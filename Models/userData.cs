using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class userData
    {
        public Guid ID { get; set; }

        [Display(Name ="First Name")]
        public string firstName { get; set; }

        [Display(Name ="Last Name")]
        public string lastName { get; set; }

        [Display(Name ="Full Name")]
        public string fullName 
        { 
            get
            {
                return lastName + ", " + firstName;
            }
                }

        [Display(Name ="Business Unit")]
        public string businessUnit { get; set; }

        [Display(Name ="Hire Date")]
        public DateTime hireDate { get; set; }

        [Display(Name ="Title")]
        public string title { get; set; }
    }
}