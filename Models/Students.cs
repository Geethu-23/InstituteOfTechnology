using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace InstituteOfTechnology.Models
{
    public class Students
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //[Required]
        //[Display(Name = "Date of Birth")]
        //// [AgeValidation]
        //public DateTime? DateOfBirth
        //{
        //    get; set;
        //}
        [Required]
        [Display(Name = "Date of Birth")]
        [AgeValidation]
        public DateTime DateOfBirth { get; set; }
        //[Required]
       // public Courses Courses { get; set; }

        [Required]  
        public int CourseId { get; set; }

        [Required]
        public DateTime CourseEnrolledDate { get; set; }

        [Required]
        public string CourseStatus { get; set; }

        [Required]
        public string Grade { get; set; }
       
      
        public List<StudentCourse> studentcourse { get; set; }

        

        



    }
}