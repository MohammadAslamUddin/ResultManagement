using ResultManagement.Manager;
using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace ResultManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AdminManager _adminManager;

        public AdminController()
        {
            _adminManager = new AdminManager();
        }
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ViewAllStudents()
        {
            List<StudentInfo> students = _adminManager.GetStudentInfoBySearching("");
            return View(students);
        }


        [HttpGet]
        public ActionResult ViewAllTeachers()
        {
            List<TeacherInfo> Teachers = _adminManager.ViewAllTeachers("");
            return View(Teachers);
        }

        //[HttpPost]
        //public JsonResult GetAllStudentsInfo(string stri)
        //{
        //    List<StudentInfo> students = _adminManager.GetStudentInfoBySearching(stri);
        //    return Json(students);
        //}
        [HttpGet]
        public ActionResult StudentDetails(int? id)
        {
            StudentInfo student = _adminManager.StudentDetails(id);
            return View(student);
        }
        [HttpGet]
        public ActionResult TeacherDetails(int? id)
        {
            TeacherInfo teacher = _adminManager.TeacherDetails(id);
            return View(teacher);
        }

        [HttpGet]
        public ActionResult EditStudentDetails(int? id)
        {
            //ViewBag.Departments = _adminManager.GetAllDepartments();
            StudentInfo student = _adminManager.StudentDetails(id);
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudentDetails(StudentInfo student)
        {
            ViewBag.message = _adminManager.UpdateStudentDetails(student);
            return View();
        }


        [HttpGet]
        public ActionResult EditTeacherDetails(int? id)
        {
            TeacherInfo teacher = _adminManager.TeacherDetails(id);
            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTeacherDetails(TeacherInfo teacher)
        {
            ViewBag.message = _adminManager.UpdateTeacherDetails(teacher);
            return View();
        }


        [HttpGet]
        public ActionResult AddingNewStudent()
        {
            ViewBag.Departments = _adminManager.GetAllDepartments();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddingNewStudent(StudentInfo student)
        {
            ViewBag.Departments = _adminManager.GetAllDepartments();


            string fileName = Path.GetFileNameWithoutExtension(student.ImageFile.FileName);
            string extension = Path.GetExtension(student.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
            student.ImagePath = "~/Image/Student/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Student/"), fileName);
            student.ImageFile.SaveAs(fileName);


            ViewBag.Message = _adminManager.SaveStudent(student);
            return View();

        }


        [HttpGet]
        public ActionResult AddingNewTeacher()
        {
            ViewBag.Departments = _adminManager.GetAllDepartments();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddingNewTeacher(TeacherInfo teacher)
        {
            ViewBag.Departments = _adminManager.GetAllDepartments();

            string fileName = Path.GetFileNameWithoutExtension(teacher.ImageFile.FileName);
            string extension = Path.GetExtension(teacher.ImageFile.FileName);
            fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
            teacher.ImagePath = "~/Image/Teacher/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/Teacher/"), fileName);
            teacher.ImageFile.SaveAs(fileName);

            ViewBag.Message = _adminManager.SaveTeacher(teacher);
            return View();
        }


        [HttpGet]
        public ActionResult AssignCourseToTeacher()
        {
            AssignCourseToTeacher act = new AssignCourseToTeacher();
            act.Teachers = _adminManager.GetAllTeachers();
            act.Courses = _adminManager.GetAllCourses();
            return View(act);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignCourseToTeacher(AssignCourseToTeacher act)
        {
            ViewBag.Message = _adminManager.AssignCourse(act);


            act.Teachers = _adminManager.GetAllTeachers();
            act.Courses = _adminManager.GetAllCourses();
            return View();
        }


        [HttpPost]
        public JsonResult GetTeacherInfo(int id)
        {
            TeacherInfo teacher = _adminManager.TeacherDetails(id);
            return Json(teacher);
        }


        [HttpPost]
        public JsonResult GetCourseInfo(int cid)
        {
            Course course = _adminManager.CourseDetails(cid);
            return Json(course);
        }
    }
}