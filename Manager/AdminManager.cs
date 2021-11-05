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
    }
}