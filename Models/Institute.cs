using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstituteOfTechnology.Models
{
    public class InstituteContext : DbContext
    {
        public InstituteContext() : base("name=InstituteContext")
        { 
        
        }
        public DbSet<Students> Student { get; set; }
        public DbSet<Courses> Course { get; set; }

        public DbSet<StudentCourse> StudentCourse { get; set; }
        

        


    }
}
    

 