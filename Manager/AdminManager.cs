using ResultManagement.Gateway;
using ResultManagement.Models;
using System.Collections.Generic;

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
            int rowAffected = _adminGateway.SaveStudent(student);
            if (rowAffected > 0)
            {
                return "New Student Information Saved!";
            }
            else
            {
                return "Saving failed!";
            }
        }
    }
}