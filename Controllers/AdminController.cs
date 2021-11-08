using ResultManagement.Manager;
using ResultManagement.Models;
using System.Collections.Generic;
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

    }
}