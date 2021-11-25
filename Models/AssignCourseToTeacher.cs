using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ResultManagement.Models
{
    public class AssignCourseToTeacher
    {
        public int ACT_Id { get; set; }



        [Required]
        [Display(Name = "Teacher's Name")]
        public int ACT_Teacher_Id { get; set; }



        [Required]
        [Display(Name = "Teacher's Department")]
        public string ACT_Teacher_Department { get; set; }



        [Required]
        [Display(Name = "Teacher's Remaining Credit")]
        public double ACT_Teacher_RemainingCredit { get; set; }




        [Required]
        [Display(Name = "Course Semester")]
        public int ACT_CourseSemester { get; set; }




        [Required]
        [Display(Name = "Course Department")]
        public string ACT_CourseDepartment { get; set; }



        [Required]
        [Display(Name = "Course Title")]
        public int ACT_Course_Id { get; set; }



        [Required]
        [Display(Name = "Course Credit")]
        public double ACT_CourseCredit { get; set; }




        public List<SelectListItem> Courses { get; set; }



        public List<SelectListItem> Teachers { get; set; }
    }
}