using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;

namespace ResultManagement.Gateway
{
    public class TeacherGateway : CommonGateway
    {
        private string email = HttpContext.Current.User.Identity.Name.ToString();
        private TeacherInfo _teacher;
        private StudentInfo _student;

        public TeacherGateway()
        {

        }


        public TeacherInfo GetTeacherDetails()
        {
            Query = "SELECT * FROM Teacher inner join Department on Teacher.teacher_department = Department.department_id WHERE teacher_email = @email";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            _teacher = new TeacherInfo();

            while (Reader.Read())
            {
                _teacher.Teacher_Id = (int)Reader["teacher_id"];
                _teacher.Teacher_Name = Reader["teacher_name"].ToString();
                _teacher.Teacher_Email = Reader["teacher_email"].ToString();
                _teacher.Teacher_Contact = Reader["teacher_contact"].ToString();
                _teacher.Teacher_Birth_Date = ((DateTime)Reader["teacher_date_of_birth"]).ToString("MM/dd/yyyy");
                _teacher.Teacher_Address = Reader["teacher_address"].ToString();
                _teacher.Teacher_Father_Name = Reader["teacher_fathers_name"].ToString();
                _teacher.Teacher_Mother_Name = Reader["teacher_mothers_name"].ToString();
                _teacher.Department_Id = (int)Reader["teacher_department"];
                _teacher.Department_Name = Reader["department_title"].ToString();
                _teacher.Department_Code = Reader["department_code"].ToString();
                _teacher.ImagePath = Reader["teacher_image"].ToString();
                _teacher.Designation = Reader["teacher_designation"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return _teacher;
        }

        public bool Is_oldPasswordCorrect(UpdatePassword updatePassword)
        {
            Query = "SELECT teacher_password FROM Teacher INNER JOIN logIn ON Teacher.teacher_email = logIn.email WHERE Teacher.teacher_id = @id and login.password = @pass ;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = updatePassword.Id;

            Command.Parameters.Add("pass", SqlDbType.NVarChar);
            Command.Parameters["pass"].Value = updatePassword.Old_Password;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();

            Connection.Close();

            return hasRows;
        }

        public int UpdatePassword(UpdatePassword updatePassword)
        {
            Query = "Update Teacher SET teacher_password = @pass where Teacher.teacher_email = @email";
            string query = " UPDATE logIn SET PASSWORD = @pass where logIn.email=@email;";

            Command = new SqlCommand(Query, Connection);
            SqlCommand command = new SqlCommand(query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("pass", SqlDbType.NVarChar);
            Command.Parameters["pass"].Value = updatePassword.New_Password;

            Command.Parameters.Add("email", SqlDbType.NVarChar);
            Command.Parameters["email"].Value = updatePassword.Email;


            command.Parameters.Clear();
            command.Parameters.Add("pass", SqlDbType.NVarChar);
            command.Parameters["pass"].Value = updatePassword.New_Password;

            command.Parameters.Add("email", SqlDbType.NVarChar);
            command.Parameters["email"].Value = updatePassword.Email;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();
            int rowAffected = command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected * rowAffected;
        }

        public int UpdateImage(UpdateImage image)
        {
            Query = "Update Teacher SET teacher_image = @image WHERE teacher_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("image", SqlDbType.NVarChar);
            Command.Parameters["image"].Value = image.ImagePath;

            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = image.Id;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<Course> ListedCourseForTheTeacher()
        {
            Query = "SELECT Course.course_id, course_code, course_title,course_credit, teacher_name, ACTD.semester_id " +
                    "FROM AssignCourseToTeacher AS ACTT inner join Teacher " +
                    "ON ACTT.act_teacher_id=Teacher.teacher_id inner join Course " +
                    "ON ACTT.act_course_id=Course.course_id inner join AssignCourseToDepartment AS ACTD " +
                    "ON Course.course_id=ACTD.course_id WHERE teacher_email=@email";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.NVarChar);
            Command.Parameters["email"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();

                course.CourseId = (int)Reader["course_id"];
                course.CourseTitle = Reader["course_title"].ToString();
                course.CourseCode = Reader["course_code"].ToString();
                course.CoursePoint = Convert.ToDouble(Reader["course_credit"]);
                course.CourseSemester = (int)Reader["semester_id"];

                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();

            return courses;
        }

        public Course GetCourseDetails(int? id)
        {
            Query = "SELECT * FROM Course WHERE course_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.NVarChar);
            Command.Parameters["id"].Value = id;
            Connection.Open();

            Reader = Command.ExecuteReader();

            Course course = new Course();

            while (Reader.Read())
            {
                course.CourseId = (int)Reader["course_id"];
                course.CourseTitle = Reader["course_title"].ToString();
                course.CourseCode = Reader["course_code"].ToString();
                course.CoursePoint = Convert.ToDouble(Reader["course_credit"]);
            }

            Reader.Close();
            Connection.Close();

            return course;
        }

        public List<SelectListItem> AllStudentsReg(int? id)
        {
            int semesteId;
            semesteId = GetSemesterIdByCourseId(id);

            Query = "SELECT * FROM Student WHERE student_semester = @sid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = semesteId;


            Connection.Open();
            List<SelectListItem> students = new List<SelectListItem>()
            {
                new SelectListItem(){Value = "-1", Text = "Select An Item"}
            };
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                SelectListItem student = new SelectListItem();
                student.Text = Reader["student_reg_no"].ToString();
                student.Value = Reader["student_id"].ToString();

                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        private int GetSemesterIdByCourseId(int? id)
        {
            Query = "SELECT semester_id FROM AssignCourseToDepartment WHERE course_id = @cid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("cid", SqlDbType.NVarChar);
            Command.Parameters["cid"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int sid = 0;
            while (Reader.Read())
            {
                sid = (int)Reader["semester_id"];
            }

            Reader.Close();
            Connection.Close();

            return sid;
        }

        public EntryResult GetStudentDetails(int id)
        {
            Query = "SELECT * FROM Student inner join Department on Student.student_department = Department.department_id WHERE student_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            EntryResult _resultinfo = new EntryResult();
            while (Reader.Read())
            {
                _resultinfo.Student_Name = Reader["student_name"].ToString();
                _resultinfo.Student_Email = Reader["student_email"].ToString();
                _resultinfo.Student_Contact = Reader["student_contact"].ToString();
                _resultinfo.Student_Reg = Reader["student_reg_no"].ToString();
                _resultinfo.Student_Department = Reader["department_title"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return _resultinfo;
        }

        public int WrittenPartSave(EntryResult entry)
        {
            Query = "INSERT INTO Result VALUES(@sid, @cid, @ct1, @ct2, @ct3, @parta, @partb, @atten, @tnum, @resultCredit, @grade);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = entry.Student_Reg;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = entry.Course_Id;

            Command.Parameters.Add("ct1", SqlDbType.Float);
            Command.Parameters["ct1"].Value = entry.ClassTest1;

            Command.Parameters.Add("ct2", SqlDbType.Float);
            Command.Parameters["ct2"].Value = entry.ClassTest2;

            Command.Parameters.Add("ct3", SqlDbType.Float);
            Command.Parameters["ct3"].Value = entry.ClassTest3;

            Command.Parameters.Add("parta", SqlDbType.Float);
            Command.Parameters["parta"].Value = entry.PartA;

            Command.Parameters.Add("partb", SqlDbType.Float);
            Command.Parameters["partb"].Value = entry.PartB;

            Command.Parameters.Add("tnum", SqlDbType.Float);
            Command.Parameters["tnum"].Value = entry.TotalNumber;

            Command.Parameters.Add("atten", SqlDbType.Float);
            Command.Parameters["atten"].Value = entry.Attendence;

            Command.Parameters.Add("resultCredit", SqlDbType.Float);
            Command.Parameters["resultCredit"].Value = entry.Grade_Point;

            Command.Parameters.Add("grade", SqlDbType.VarChar);
            Command.Parameters["grade"].Value = entry.Letter_Grade;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public bool isResultAlreadySave(EntryResult entry)
        {
            Query = "SELECT * FROM Result WHERE student_id = @sid AND course_id = @cid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = entry.Student_Reg;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = entry.Course_Id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRows;
        }
        public bool isResultAlreadyPracticalSave(PracticalPartResult pResult)
        {
            Query = "SELECT * FROM Result WHERE student_id = @sid AND course_id = @cid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = pResult.Student_Reg;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = pResult.Course_Id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public float IsPracticalPart(int? id)
        {
            Query = "SELECT * FROM Course WHERE course_id = @cid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            float point = 0;
            while (Reader.Read())
            {
                point = (float)Convert.ToDouble(Reader["course_credit"]);
            }
            Reader.Close();
            Connection.Close();

            return point;
        }

        public int PracticalPartSave(PracticalPartResult pResult)
        {
            Query = "INSERT INTO Result VALUES(@sid, @cid, @ct1, @ct2, @ct3, @parta, @partb, @atten, @tnum, @resultCredit, @grade);";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = pResult.Student_Reg;

            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = pResult.Course_Id;

            Command.Parameters.Add("ct1", SqlDbType.Float);
            Command.Parameters["ct1"].Value = pResult.Quiz;

            Command.Parameters.Add("ct2", SqlDbType.Float);
            Command.Parameters["ct2"].Value = pResult.Viva;

            Command.Parameters.Add("ct3", SqlDbType.Float);
            Command.Parameters["ct3"].Value = pResult.Lab_Report;

            Command.Parameters.Add("parta", SqlDbType.Float);
            Command.Parameters["parta"].Value = 0;

            Command.Parameters.Add("partb", SqlDbType.Float);
            Command.Parameters["partb"].Value = 0;

            Command.Parameters.Add("tnum", SqlDbType.Float);
            Command.Parameters["tnum"].Value = pResult.TotalNumber;

            Command.Parameters.Add("atten", SqlDbType.Float);
            Command.Parameters["atten"].Value = pResult.Attendence;

            Command.Parameters.Add("resultCredit", SqlDbType.Float);
            Command.Parameters["resultCredit"].Value = pResult.Grade_Point;

            Command.Parameters.Add("grade", SqlDbType.VarChar);
            Command.Parameters["grade"].Value = pResult.Letter_Grade;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<ResultViewForTeacherModel> GetResults(int? id)
        {
            int semesterId = GetSemesterIdByCourseId(id);

            Query =
                "SELECT student_name,student_reg_no,course_code,ct_1,ct_2,ct_3,attendence,part_a,part_b,result_credit,latter_grade FROM Result INNER JOIN Course ON Result.course_id = Course.course_id INNER JOIN Student ON Result.student_id = Student.student_id WHERE student_semester = @sid AND Course.course_id = @cid";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("cid", SqlDbType.Int);
            Command.Parameters["cid"].Value = id;

            Command.Parameters.Add("sid", SqlDbType.Int);
            Command.Parameters["sid"].Value = semesterId;

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ResultViewForTeacherModel> results = new List<ResultViewForTeacherModel>();

            while (Reader.Read())
            {
                ResultViewForTeacherModel result = new ResultViewForTeacherModel();

                result.Student_Name = Reader["student_name"].ToString();
                result.Student_Reg = Reader["student_reg_no"].ToString();
                result.Course_Code = Reader["course_code"].ToString();
                result.CT_1 = Convert.ToDouble(Reader["ct_1"]);
                result.CT_2 = Convert.ToDouble(Reader["ct_2"]);
                result.CT_3 = Convert.ToDouble(Reader["ct_3"]);
                result.Attendence = Convert.ToDouble(Reader["attendence"]);
                result.Part_A = Convert.ToDouble(Reader["part_a"]);
                result.Part_B = Convert.ToDouble(Reader["part_b"]);
                result.Result_Cgpa = Convert.ToDouble(Reader["result_credit"]);
                result.Latter_Grade = Reader["latter_grade"].ToString();

                results.Add(result);
            }
            Reader.Close();
            Connection.Close();

            return results;
        }
    }
}