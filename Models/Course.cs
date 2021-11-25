using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    public class Course
    {
        [Display(Name = "Course Id")]
        public int CourseId { get; set; }


        [Required]
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }


        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }


        [Required]
        [Display(Name = "Course Department")]
        public string DepartmentName { get; set; }


        [Required]
        [Display(Name = "Course Credit")]
        public double CoursePoint { get; set; }


        [Required]
        [Display(Name = "Course Semester No")]
        public int CourseSemester { get; set; }


        [Required]
        [Display(Name = "Semester No")]
        public int SemesterId { get; set; }
    }
}