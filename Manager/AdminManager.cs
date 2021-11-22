using ResultManagement.Gateway;
using ResultManagement.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ResultManagement.Manager
{
    public class AdminManager
    {
        private AdminGateway _adminGateway;

        public AdminManager()
        {
            _adminGateway = new AdminGateway();
        }

        public List<StudentInfo> GetStudentInfoBySearching(string stri)
        {
            return _adminGateway.GetStudentInfoBySearching(stri);
        }

        public StudentInfo StudentDetails(int? id)
        {
            return _adminGateway.StudentDetails(id);
        }

        public List<TeacherInfo> ViewAllTeachers(string stri)
        {
            return _adminGateway.ViewAllTeachers(stri);
        }

        public TeacherInfo TeacherDetails(int? id)
        {
            return _adminGateway.TeacherDetails(id);
        }

        public string UpdateStudentDetails(StudentInfo student)
        {
            int rowAffected = _adminGateway.UpdateStudentDetails(student);
            if (rowAffected > 0)
            {
                return "Student's Information Updated!";
            }
            else
            {
                return "Updating Failed!";
            }
        }

        public List<Department> GetAllDepartments()
        {
            return _adminGateway.GetAllDepartments();
        }

        public string UpdateTeacherDetails(TeacherInfo teacher)
        {
            int rowAffected = _adminGateway.UpdateTeacherDetails(teacher);
            if (rowAffected > 0)
            {
                return "Teacher's Information Updated!";
            }
            else
            {
                return "Information updating Failed!";
            }
        }


        public string SaveStudent(StudentInfo student)
        {
            if (!_adminGateway.IsStudentExist(student))
            {
                int rowAffected = _adminGateway.SaveStudent(student);
                if (rowAffected > 0)
                {
                    return "New Student Information Saved!";
                }
                else
                {
                    _adminGateway.DeleteFromRoleAndLogInSystem(student);
                    return "Saving failed!";
                }
            }
            else
            {
                return "Student Already Exist";
            }
        }

        public string SaveTeacher(TeacherInfo teacher)
        {
            if (!_adminGateway.IsTeacherExist(teacher))
            {
                int rowAffected = _adminGateway.SaveTeacher(teacher);
                if (rowAffected > 0)
                {
                    return "New Teacher's Information Saved!";
                }
                else
                {
                    return "Teacher's Information Saving failed!";
                }
            }
            else
            {
                return "Teacher's Information Already Exist";
            }
        }

        public List<SelectListItem> GetAllTeachers()
        {
            return _adminGateway.GetAllTeachers();
        }

        public List<SelectListItem> GetAllCourses()
        {
            return _adminGateway.GetAllCourses();
        }

        public Course CourseDetails(int id)
        {
            return _adminGateway.CourseDetails(id);
        }

        public string AssignCourse(AssignCourseToTeacher act)
        {
            double courseCredit = _adminGateway.CourseCredit(act.ACT_Course_Id);
            double teacherCredit = _adminGateway.TeachersCredit(act.ACT_Teacher_Id);
            
            if (teacherCredit < courseCredit)
            {
                return "Teacher's credit is not supporting";
            }
            else
            {
                if (_adminGateway.IsCourseAssignBefore(act))
                {
                    return "This course is already assigned!";
                }
                else
                {
                    int rowAffected = _adminGateway.AssignCourse(act);
                    if (rowAffected > 0)
                    {
                        UpdateTeachersRemainingCredit(act);
                        return "Course Assigned to Teacher!";
                    }
                    else
                    {
                        return "Assigning Course Failed!";
                    }
                }
            }
        }

        private int UpdateTeachersRemainingCredit(AssignCourseToTeacher act)
        {
            double courseCredit = _adminGateway.CourseCredit(act.ACT_Course_Id);
            double TeachersCredit = _adminGateway.TeachersCredit(act.ACT_Teacher_Id);
            double credit = TeachersCredit - courseCredit;
            int rowAffected = _adminGateway.UpdateTeacherRemaingCredit(credit, act.ACT_Teacher_Id);
            return 1;
        }
    }
}