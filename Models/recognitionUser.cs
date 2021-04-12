using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class recognitionUser
    {
        public int recognitionUserID { get; set; }

        [Display(Name = "Person giving the recognition")]
        public Guid recognizor { get; set; }
        [ForeignKey("recognizor")]
        public virtual userData personGiving { get; set; }

        [Required]
        [Display(Name = "Person receiving recognition")]
        public Guid recognized { get; set; }
        [ForeignKey("recognized")]
        public virtual userData personReceiving { get; set; }

        [Required]
        [Display(Name = "Date of Recognition")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> date { get; set; }
        
        [Required]
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

        [Required]
        [Display(Name = "Reason")]
        public string reason { get; set; }
        //public Guid userDataID { get; set; }
        //    public virtual userData UserData { get; set; }
    }
}