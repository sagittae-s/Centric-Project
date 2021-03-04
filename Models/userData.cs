using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centric_Project.Models
{
    public class userData
    {
        public Guid ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName 
        { 
            get
            {
                return lastName + ", " + firstName;
            }
                }
        public string businessUnit { get; set; }
        public DateTime hireDate { get; set; }
        public string title { get; set; }
    }
}