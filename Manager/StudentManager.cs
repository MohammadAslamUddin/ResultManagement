using ResultManagement.Gateway;
using ResultManagement.Models;
using System.Collections.Generic;

namespace ResultManagement.Manager
{
    public class StudentManager
    {
        private readonly StudentGateway _studentGateway;

        public StudentManager()
        {
            _studentGateway = new StudentGateway();
        }

        public StudentInfo GetStudentDetails()
        {
            return _studentGateway.GetStudentDetails();
        }

        public StudentInfo Find(int? id)
        {
            return _studentGateway.Find(id);
        }

        public string Update(StudentInfo student)
        {
            int rowAffected = _studentGateway.Update(student);

            if (rowAffected > 0)
            {
                return "Updated";
            }
            else
            {
                return "Updating Failed!";
            }
        }

        //public UpdatePassword FindDetails(int? id)
        //{
        //    return _studentGateway.FindDetails(id);
        //}


        //public UpdateImage FindImageDetails(int? id)
        //{
        //    return _studentGateway.FindImageDetails(id);
        //}

        public string UpdatePassword(UpdatePassword updatePassword)
        {
            if (updatePassword.New_Password.Equals(updatePassword.Confirm_Password))
            {
                if (_studentGateway.Is_oldPasswordCorrect(updatePassword))
                {
                    int rowAffected = _studentGateway.UpdatePassword(updatePassword);

                    if (rowAffected > 0)
                    {
                        return "Updated";
                    }
                    else
                    {
                        return "Updating Failed!";
                    }
                }
                else
                {
                    return "Faild!";
                }
            }
            return "Failed!";
        }

        public string UpdateImage(UpdateImage image)
        {
            int rowAffected = _studentGateway.UpdateImage(image);
            if (rowAffected > 0)
            {
                return "Updated";
            }
            else
            {
                return "Failed";
            }
        }


        public List<SemesterResult> SemesterCoursesBySemesterId(int? semester)
        {
            return _studentGateway.SemesterCoursesBySemesterId(semester);
        }

        public object GetCGPA(int? semesterNo)
        {
            return _studentGateway.GetCGPA(semesterNo);
        }
    }
}