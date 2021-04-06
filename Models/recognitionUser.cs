using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class recognitionUser
    {
        public int recognitionUserID { get; set; }

        [Display(Name = "Person giving the recognition")]
        public string recoginzor { get; set; }

        [Display(Name = "Person receiving recognition")]
        public string recognized { get; set; }

        [Display(Name = "Date of Recognition")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime date { get; set; }

        [Display(Name = "Core value recognized")]
        public CoreValue award { get; set; }
        public enum CoreValue
        {
            Stewardship = 1,
            Culture = 2,
            Excellence = 3,
            Innovation = 4,
            Passion = 5,
            Integrity = 6,
            Balance = 7
        }

        [Display(Name = "Reason")]
        public string reason { get; set; }
        //public Guid userDataID { get; set; }
        //    public virtual userData UserData { get; set; }
    }
}