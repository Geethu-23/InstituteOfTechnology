using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfTechnology.Models
{
    public class Courses
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseDescription { get; set; }

        [Required]
        public string TutorName { get; set; }

        [Required]
        public int CourseRating { get; set; }

    }
}