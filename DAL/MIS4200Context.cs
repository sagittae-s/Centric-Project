using Centric_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Centric_Project.DAL
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {

        }
        public DbSet<userData> userData { get; set; }
        public DbSet<RegisteredUser> registeredUsers { get; set; }
    }
}