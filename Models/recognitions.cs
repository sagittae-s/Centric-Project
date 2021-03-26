using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class recognitions
    {
        public int recognitionsID { get; set; }
        [Display(Name = "Core Value Recognition")]
        public CoreValue award { get; set; }
        [Display(Name = "Person Giving Recognition")]
        public string recognizor { get; set; }
        [Display(Name = "Person Receiving Recognition")]
        public string recognized { get; set; }
        [Display(Name = "Date of Recognition")]
        [DisplayFormat(DataFormatString = "{0;d}")]
        public DateTime recognitionDate { get; set; }
        [Display(Name = "Reason")]
        public string reason { get; set; }
        public enum CoreValue
            { 
            Stewardship = 1,
            Culture = 2,
            Delivery = 3,
            Innovation = 4,
            Passion = 5,
            Integrity = 6,
            Balance = 7
            }
    }
}