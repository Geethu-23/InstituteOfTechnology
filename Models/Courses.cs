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

        [Required(ErrorMessage = "Please enter the field number")]
        [Range(1, 10, ErrorMessage = "The field number should between 1 to 10")]
        public int CourseRating { get; set; }

    }
}