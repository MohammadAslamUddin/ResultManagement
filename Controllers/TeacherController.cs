using ResultManagement.Manager;
using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace ResultManagement.Controllers
{
    [Authorize(Roles = "Teacher, Admin")]
    public class TeacherController : Controller
    {
        private readonly TeacherManager _teacherManager;
        private TeacherInfo _teacher;
        private Course course;
        public TeacherController()
        {
            _teacherManager = new TeacherManager();
        }



        public ActionResult Index()
        {
            _teacher = _teacherManager.GetTeacherDetails();
            return View(_teacher);
        }

        [HttpGet]
        public ActionResult UpdatePassword(int? id, string email)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();

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
            if (ModelState.IsValid)
            {
                string rowAffected = _teacherManager.UpdatePassword(updatePassword);
                if (rowAffected.Equals("Updated"))
                {
                    return View(updatePassword);
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }


        [HttpGet]
        public ActionResult UpdateImage(int? id)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();

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
            ViewBag.teacher = _teacherManager.GetTeacherDetails();

            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
                string extension = Path.GetExtension(image.ImageFile.FileName);
                fileName = fileName + DateTime.Today.ToString("yymmdd") + extension;
                image.ImagePath = "~/Image/Teacher/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/Teacher/"), fileName);
                image.ImageFile.SaveAs(fileName);


                string rowAffected = _teacherManager.UpdateImage(image);

                if (rowAffected.Equals("Updated"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult InstractingCourse()
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            List<Course> courses = _teacherManager.ListedCourseForTheTeacher();
            return View(courses);
        }


        public ActionResult ChoosePart(int? id)
        {
            float grade_point = _teacherManager.IsPracticalPart(id);
            if (grade_point == 3.00)
            {
                return RedirectToAction("WrittenPartResult", new { cId = id });
            }
            else
            {
                return RedirectToAction("PracticalPartResult", new { cId = id });
            }
        }


        [HttpGet]
        public ActionResult WrittenPartResult(int? cId)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            ViewBag.courseinfo = _teacherManager.GetCourseDetails(cId);
            ViewBag.Students = _teacherManager.AllStudentsReg(cId);
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WrittenPartResult(EntryResult entry)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            ViewBag.courseinfo = _teacherManager.GetCourseDetails(entry.Course_Id);
            ViewBag.Students = _teacherManager.AllStudentsReg(entry.Course_Id);
            if (ModelState.IsValid)
            {
                ViewBag.message = _teacherManager.WrittenPartSave(entry);
            }
            return View();
        }


        [HttpGet]
        public ActionResult PracticalPartResult(int? cId)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            ViewBag.courseinfo = _teacherManager.GetCourseDetails(cId);
            ViewBag.Students = _teacherManager.AllStudentsReg(cId);
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PracticalPartResult(PracticalPartResult practicalPartResult)
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            ViewBag.courseinfo = _teacherManager.GetCourseDetails(practicalPartResult.Course_Id);
            ViewBag.Students = _teacherManager.AllStudentsReg(practicalPartResult.Course_Id);
            if (ModelState.IsValid)
            {
                ViewBag.message = _teacherManager.PracticalPartSave(practicalPartResult);
            }
            return View();
        }


        public JsonResult GetStudentDetails(int id)
        {
            EntryResult student = _teacherManager.GetStudentDetails(id);
            return Json(student);
        }

        [HttpGet]
        public ActionResult EnteredResults()
        {
            ViewBag.teacher = _teacherManager.GetTeacherDetails();
            List<Course> courses = _teacherManager.ListedCourseForTheTeacher();
            return View(courses);
        }

        public ActionResult ShowResult(int? id)
        {
            List<ResultViewForTeacherModel> results = _teacherManager.GetResults(id);
            return View(results);
        }

    }
}