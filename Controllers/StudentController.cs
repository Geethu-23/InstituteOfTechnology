using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteOfTechnology.Models;

namespace InstituteOfTechnology.Controllers
{
    public class StudentController : Controller
    {

        private InstituteContext _context = new InstituteContext();

        // GET: Student - This method to show the list of records fetched from DB
        public ActionResult List()
        {
            var student = _context.Student;
            return View(student);
        }

        // This method used for created new records or edited records save
        public ActionResult CreateStudent(Students student)
        {
            Students stud = new Students();
            // the below code logic for initializing studentcourse model values into Student model
            //to display the dropdown list box in UI
            using (InstituteContext db = new InstituteContext()) { 

                stud.studentcourse = db.StudentCourse.ToList<StudentCourse>();
                            }

            return View(stud);
            
        }

        public ActionResult Save(Students stud)
        {
            if (stud.FirstName == null 
                 || stud.Grade == null || stud.CourseEnrolledDate == null
                 || stud.CourseId < 0 || stud.CourseStatus == null
                || stud.CourseId==0
                 || stud.DateOfBirth == null || stud.DateOfBirth.Equals("1/1/0001 12:00:00 AM")
                 || stud.CourseEnrolledDate.Equals("1/1/0001 12:00:00 AM"))
                {
                return RedirectToAction("CreateStudent", "Student",stud);

                }
            if (stud.Id == 0)
            {
                //When user try to add new records ords from UI and clicks the submit Button
                
                _context.Student.Add(stud);
            }
            else
            {
                //This  else condition for users edit the records and save
                var studentindb = _context.Student.Single(c => c.Id == stud.Id);
                //studentindb.Id = stud.Id;
                studentindb.LastName = stud.LastName;
                studentindb.FirstName = stud.FirstName;
                studentindb.Grade = stud.Grade;
                studentindb.CourseEnrolledDate = stud.CourseEnrolledDate;
                studentindb.CourseId = stud.CourseId;
                studentindb.CourseStatus = stud.CourseStatus;
                studentindb.DateOfBirth = stud.DateOfBirth;
            }

            _context.SaveChanges();
            return RedirectToAction("List", "Student",stud);
        }
        public ActionResult Edit(int id)
        {
            //When User clicks edit on the record control will come
            //to this method and fetch the record for the ID selected


           var studentRecords_Database = _context.Student.SingleOrDefault(c => c.Id == id);

            //If the selected id records not found in database throw the error in UI
            if (studentRecords_Database == null)
            {
                return HttpNotFound();
            }
            //Redirecting to CreateStudent method
            return RedirectToAction("CreateStudent", "Student", studentRecords_Database);
        }

        //This Method used for deleting the user selected record from database and save the changes
        public ActionResult Delete(int id)
        {
            var studentRecords_Database  = _context.Student.SingleOrDefault(c => c.Id == id);
            if (studentRecords_Database == null)
            {
                return HttpNotFound();
            }
            _context.Student.Remove(studentRecords_Database);
            _context.SaveChanges();

            return View(studentRecords_Database);
        }
       
    }
}