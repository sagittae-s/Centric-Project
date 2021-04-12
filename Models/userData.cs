using System;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> hireDate { get; set; }
        //[DisplayFormat(DataFormatString ="{0:d}")]
        //public DateTime hireDate { get; set; }


        [Display(Name ="Title")]
        public string title { get; set; }
        [ForeignKey("recognized")]
        public ICollection<recognitionUser> personReceiving { get; set; }
        [ForeignKey("recognizor")]
        public ICollection<recognitionUser> personGiving { get; set; }
    }
}