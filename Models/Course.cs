namespace ResultManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public double CoursePoint { get; set; }
        public int CourseSemester { get; set; }
    }
}