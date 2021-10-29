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
        public ActionResult ViewAllStudents()
        {
            ViewBag.Students = _adminManager.GetStudentInfoBySearching("");
            return View();
        }

        [HttpPost]
        public JsonResult GetAllStudentsInfo(string stri)
        {
            List<StudentInfo> students = _adminManager.GetStudentInfoBySearching(stri);
            return Json(students);
        }
    }
}