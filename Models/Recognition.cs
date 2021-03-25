using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class Recognition
    {
        public int recognitionID { get; set; }
        public Guid ID { get; set; }
        [Display(Name = "Core Value")]
        public string coreValues { get; set; }
        [Display(Name = "Reason")]
        public string reason { get; set; }
        public ICollection<userData> userDatas { get; set; }
    }
}