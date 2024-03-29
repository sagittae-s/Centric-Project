﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class userData
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string firstName { get; set; }

        [Required]
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

        [Required]
        [Display(Name ="Business Unit")]
        public string businessUnit { get; set; }

        public string email { get; set; }

        [Required]
        [Display(Name ="Hire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> hireDate { get; set; }
        //[DisplayFormat(DataFormatString ="{0:d}")]
        //public DateTime hireDate { get; set; }

        [Required]
        [Display(Name ="Title")]
        public string title { get; set; }
        [ForeignKey("recognized")]
        public ICollection<recognitionUser> personReceiving { get; set; }
        [ForeignKey("recognizor")]
        public ICollection<recognitionUser> personGiving { get; set; }
    }
}