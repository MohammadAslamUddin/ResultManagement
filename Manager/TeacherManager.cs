using ResultManagement.Gateway;
using ResultManagement.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ResultManagement.Manager
{
    public class TeacherManager
    {
        private TeacherGateway _teacherGateway;

        public TeacherManager()
        {
            _teacherGateway = new TeacherGateway();
        }

        public TeacherInfo GetTeacherDetails()
        {
            return _teacherGateway.GetTeacherDetails();
        }

        public string UpdatePassword(UpdatePassword updatePassword)
        {
            if (updatePassword.New_Password.Equals(updatePassword.Confirm_Password))
            {
                if (_teacherGateway.Is_oldPasswordCorrect(updatePassword))
                {
                    int rowAffected = _teacherGateway.UpdatePassword(updatePassword);

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
            int rowAffected = _teacherGateway.UpdateImage(image);
            if (rowAffected > 0)
            {
                return "Updated";
            }
            else
            {
                return "Failed";
            }
        }

        public List<Course> ListedCourseForTheTeacher()
        {
            List<Course> courses = _teacherGateway.ListedCourseForTheTeacher();
            return courses;
        }

        public Course GetCourseDetails(int? id)
        {
            return _teacherGateway.GetCourseDetails(id);
        }

        public List<SelectListItem> AllStudentsReg(int? id)
        {
            return _teacherGateway.AllStudentsReg(id);
        }

        public EntryResult GetStudentDetails(int id)
        {
            return _teacherGateway.GetStudentDetails(id);
        }

        public string WrittenPartSave(EntryResult entry)
        {
            if (!_teacherGateway.isResultAlreadySave(entry))
            {
                entry.TotalNumber = entry.ClassTest1 + entry.ClassTest2 + entry.ClassTest3 + entry.PartA + entry.PartB + entry.Attendence;
                entry.Grade_Point = GetGradePointByNumber(entry.TotalNumber);
                entry.Letter_Grade = GetLetterGrade(entry.TotalNumber);

                int rowAffected = _teacherGateway.WrittenPartSave(entry);
                if (rowAffected > 0)
                {
                    return "Result Saved!";
                }
                else
                {
                    return "Result saving Failed!";
                }
            }
            else
            {
                return "Result Already Saved!";
            }
        }

        private string GetLetterGrade(double totalNumber)
        {
            string grade;
            if (totalNumber > 240 && totalNumber < 300)
            {
                grade = "A+";
            }
            else if (totalNumber > 225 && totalNumber < 240)
            {
                grade = "A";
            }
            else if (totalNumber > 210 && totalNumber < 225)
            {
                grade = "A-";
            }
            else if (totalNumber > 195 && totalNumber < 210)
            {
                grade = "B+";
            }
            else if (totalNumber > 180 && totalNumber < 195)
            {
                grade = "B";
            }
            else if (totalNumber > 165 && totalNumber < 180)
            {
                grade = "B-";
            }
            else if (totalNumber > 150 && totalNumber < 165)
            {
                grade = "C+";
            }
            else if (totalNumber > 135 && totalNumber < 150)
            {
                grade = "C";
            }
            else if (totalNumber > 120 && totalNumber < 135)
            {
                grade = "D";
            }
            else
            {
                grade = "F";
            }

            return grade;
        }

        private double GetGradePointByNumber(double totalNumber)
        {
            double point;
            if (totalNumber > 240 && totalNumber < 300)
            {
                point = 4;
            }
            else if (totalNumber > 225 && totalNumber < 240)
            {
                point = 3.75;
            }
            else if (totalNumber > 210 && totalNumber < 225)
            {
                point = 3.50;
            }
            else if (totalNumber > 195 && totalNumber < 210)
            {
                point = 3.25;
            }
            else if (totalNumber > 180 && totalNumber < 195)
            {
                point = 3;
            }
            else if (totalNumber > 165 && totalNumber < 180)
            {
                point = 2.75;
            }
            else if (totalNumber > 150 && totalNumber < 165)
            {
                point = 2.50;
            }
            else if (totalNumber > 135 && totalNumber < 150)
            {
                point = 2.25;
            }
            else if (totalNumber > 120 && totalNumber < 135)
            {
                point = 2;
            }
            else
            {
                point = 0;
            }

            return point;
        }

        public float IsPracticalPart(int? id)
        {
            return _teacherGateway.IsPracticalPart(id);
        }

        public string PracticalPartSave(PracticalPartResult pResult)
        {
            if (!_teacherGateway.isResultAlreadyPracticalSave(pResult))
            {
                pResult.TotalNumber = pResult.Viva + pResult.Quiz + pResult.Lab_Report + pResult.Attendence;
                pResult.Grade_Point = GetGradePointByNumber((float)(pResult.TotalNumber * 2));
                pResult.Letter_Grade = GetLetterGrade((float)(pResult.TotalNumber * 2));


                int rowAffected = _teacherGateway.PracticalPartSave(pResult);
                if (rowAffected > 0)
                {
                    return "Result Saved!";
                }
                else
                {
                    return "Result saving Failed!";
                }
            }
            else
            {
                return "Result Already Saved!";
            }
        }

        public List<ResultViewForTeacherModel> GetResults(int? id)
        {
            return _teacherGateway.GetResults(id);
        }
    }
}