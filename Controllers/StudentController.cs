using ResultManagement.Manager;
using ResultManagement.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace ResultManagement.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly StudentManager _studentManager;
        private StudentInfo _student;
        private readonly UpdatePassword _updatePassword;
        private readonly UpdateImage _updateImage;

        public StudentController()
        {
            _student = new StudentInfo();
            _studentManager = new StudentManager();
            _updatePassword = new UpdatePassword();
            _updateImage = new UpdateImage();
        }


        // GET: Student
        public ActionResult Index()
        {
            _student = _studentManager.GetStudentDetails();
            return View(_student);
        }
        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    _student = _studentManager.Find(id);
        //    if (_student == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(_student);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(StudentInfo student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string rowAffected = _studentManager.Update(student);
        //        if (rowAffected.Equals("Updated"))
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return HttpNotFound();
        //        }
        //    }
        //    return View(student);
        //}
        [HttpGet]
        public ActionResult UpdatePassword(int? id, string email)
        {
            ViewBag.Student = _studentManager.GetStudentDetails();
            if (email == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(UpdatePassword updatePassword)
        {
            ViewBag.Student = _studentManager.GetStudentDetails();

            ViewBag.Message = _studentManager.UpdatePassword(updatePassword);
            return View(updatePassword);
        }


        [HttpGet]
        public ActionResult UpdateImage(int? id)
        {
            ViewBag.Student = _studentManager.GetStudentDetails();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateImage(UpdateImage image)
        {
            ViewBag.Student = _studentManager.GetStudentDetails();

            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
            image.ImagePath = "~/Image/Student/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Student/"), fileName);
            image.ImageFile.SaveAs(fileName);


            ViewBag.Message = _studentManager.UpdateImage(image);

            return View(image);
        }

        [HttpGet]
        public ActionResult GetResult()
        {
            ViewBag.Student = _studentManager.GetStudentDetails();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult GetResult(int? id)
        //{
        //    return View();
        //}

        public ActionResult Semester(int? semesterNo)
        {
            List<SemesterResult> semesterCourseList = _studentManager.SemesterCoursesBySemesterId(semesterNo);
            ViewBag.CGPA = _studentManager.GetCGPA(semesterNo);
            ViewBag.Semester = semesterNo;
            return View(semesterCourseList);
        }


        public ActionResult MakePdf(int? semesterNo)
        {
            ViewBag.Student = _studentManager.GetStudentDetails();

            List<SemesterResult> semesterCourseList = _studentManager.SemesterCoursesBySemesterId(semesterNo);
            ViewBag.CGPA = _studentManager.GetCGPA(semesterNo);

            return View(semesterCourseList);
        }

        public ActionResult ConvertToPdf(int semesterNo)
        {
            var printpdf = new ActionAsPdf("MakePdf", new { SemesterNo = semesterNo }) { FileName = "Result Sheet" };
            return printpdf;
        }



        public ActionResult ShowAllTeachers()
        {
            List<TeacherInfo> teachers = _studentManager.ShowAllTeacher();
            return View(teachers);
        }

        public ActionResult TeacherDetails(int? id)
        {
            TeacherInfo teacher = _studentManager.TeachersDetails(id);
            return View(teacher);
        }
    }
}