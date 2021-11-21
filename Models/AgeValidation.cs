using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InstituteOfTechnology.Models
{
    public class AgeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Students)validationContext.ObjectInstance;
           
            var age = DateTime.Today.Year - student.DateOfBirth.DayOfYear;
            if (student.DateOfBirth== null)
                return new ValidationResult("Birthdate is required");
            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Student should be at least 18 years old!");

        }
    }
}