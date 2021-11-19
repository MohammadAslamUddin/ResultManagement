using System.Collections.Generic;

namespace ResultManagement.Models
{
    public class AssignCourseToTeacher
    {
        public int ACT_Id { get; set; }
        public int ACT_Teacher_Id { get; set; }
        public int ACT_Course_Id { get; set; }
        public List<Course> Courses { get; set; }
        public List<TeacherInfo> Teachers { get; set; }
    }
}