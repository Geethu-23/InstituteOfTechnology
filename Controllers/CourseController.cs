using InstituteOfTechnology.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InstituteOfTechnology.Controllers
{
    public class CourseController : Controller
    {
        private InstituteContext _context = new InstituteContext();

        public ActionResult List()
        {
            var course = _context.Course;
                
                         
            return View(course);
        }



        public ActionResult Create(Courses course)            //Creating the course record:

        {
            return View(course);
        }

        
        public ActionResult SaveCourse(Courses course)      // To save the course record:
        {
            if (course.CourseName == null || course.CourseDescription == null
                || course.CourseRating==0 || course.TutorName == null
                || course.CourseRating >10)
            {
                return RedirectToAction("Create", "Course", course);

            }


            if (course.Id == 0)
            {
                //When user try to add new records from UI and clicks the submit Button

                _context.Course.Add(course);
            }
            else
            {
                //This is else condition for users edited the records and save
                var courseindb = _context.Course.Single(c => c.Id == course.Id);
                //studentindb.Id = stud.Id;
                courseindb.CourseName = course.CourseName;
                courseindb.CourseDescription = course.CourseDescription;
                courseindb.CourseRating = course.CourseRating;
                courseindb.TutorName = course.TutorName;
            }
                _context.SaveChanges();
            return RedirectToAction("List", "Course");

        }



        public ActionResult Edit(int Id)             // Editing the records for course:

        {
            var CourseRecords= _context.Course.SingleOrDefault(c => c.Id == Id);

           
            if (CourseRecords == null)
            {
                return HttpNotFound();
            }
            //Redirecting to CreateStudent method
            return RedirectToAction("Create", "Course", CourseRecords);
        }



    //Deleting Course Record:

        public ActionResult DeleteCourse(int Id)
        {
            var CourseRecord = _context.Course.SingleOrDefault(c => c.Id == Id);
            if (CourseRecord == null)
            {
                return HttpNotFound();
            }
            _context.Course.Remove(CourseRecord);
            _context.SaveChanges();

            return View(CourseRecord);
        }


        public ActionResult Update()
        {
            return View();
        }
    }
}