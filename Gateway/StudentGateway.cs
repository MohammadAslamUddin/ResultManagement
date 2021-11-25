using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace ResultManagement.Gateway
{
    public class StudentGateway : CommonGateway
    {
        private StudentInfo _student;
        private UpdatePassword _updatePassword;
        private UpdateImage _updateImage;

        private readonly string _email = HttpContext.Current.User.Identity.Name.ToString();
        public StudentInfo GetStudentDetails()
        {

            Query = "SELECT * FROM Student inner join Department on Student.student_department = Department.department_id WHERE student_email = @email";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = _email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            _student = new StudentInfo();
            while (Reader.Read())
            {
                _student.Student_Id = (int)Reader["student_id"];
                _student.Student_Name = Reader["student_name"].ToString();
                _student.Student_Email = Reader["student_email"].ToString();
                _student.Student_Contact = Reader["student_contact"].ToString();
                _student.Student_Birth_Date = (DateTime)Reader["student_date_of_birth"];
                _student.Student_Address = Reader["student_address"].ToString();
                _student.Student_Father_Name = Reader["student_fathers_name"].ToString();
                _student.Student_Father_Contact = Reader["student_fathers_contact"].ToString();
                _student.Student_Mother_Name = Reader["student_mothers_name"].ToString();
                _student.Student_Mother_Contact = Reader["student_mothers_contact"].ToString();
                _student.Student_Reg = Reader["student_reg_no"].ToString();
                _student.Department_Id = (int)Reader["student_department"];
                _student.Department_Name = Reader["department_title"].ToString();
                _student.Department_Code = Reader["department_code"].ToString();
                _student.ImagePath = Reader["student_image"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return _student;
        }

        public StudentInfo Find(int? id)
        {
            Query = "SELECT * FROM Student WHERE student_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            _student = new StudentInfo();
            while (Reader.Read())
            {
                _student.Student_Id = (int)Reader["student_id"];
                _student.Student_Name = Reader["student_name"].ToString();
                _student.Student_Email = Reader["student_email"].ToString();
                _student.Student_Contact = Reader["student_contact"].ToString();
                _student.Student_Birth_Date = (DateTime)Reader["student_date_of_birth"];
                _student.Student_Address = Reader["student_address"].ToString();
                _student.Student_Father_Name = Reader["student_fathers_name"].ToString();
                _student.Student_Father_Contact = Reader["student_fathers_contact"].ToString();
                _student.Student_Mother_Name = Reader["student_mothers_name"].ToString();
                _student.Student_Mother_Contact = Reader["student_mothers_contact"].ToString();
                _student.Student_Reg = Reader["student_reg_no"].ToString();
                _student.Department_Id = (int)Reader["student_department"];
                _student.ImagePath = Reader["student_image"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return _student;
        }

        public int Update(StudentInfo student)
        {
            Query =
                "UPDATE Student SET student_name = @sname, student_email=@semail, " +
                "student_contact=@scontact,student_date_of_birth=@date, student_address = @saddress, student_fathers_name = @sfname, " +
                "student_fathers_contact = @sfcontact, student_department = @dep, student_mothers_name = @smname, student_mothers_contact = @smcontact WHERE student_id = @id;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("@sname", SqlDbType.NVarChar);
            Command.Parameters["sname"].Value = _student.Student_Name;

            Command.Parameters.Add("@semail", SqlDbType.NVarChar);
            Command.Parameters["semail"].Value = _student.Student_Email;

            Command.Parameters.Add("@scontact", SqlDbType.NVarChar);
            Command.Parameters["scontact"].Value = _student.Student_Contact;

            Command.Parameters.Add("@date,", SqlDbType.NVarChar);
            Command.Parameters["date,"].Value = _student.Student_Birth_Date;

            Command.Parameters.Add("@saddress", SqlDbType.NVarChar);
            Command.Parameters["saddress"].Value = _student.Student_Address;

            Command.Parameters.Add("@sfname", SqlDbType.NVarChar);
            Command.Parameters["sfname"].Value = _student.Student_Father_Name;

            Command.Parameters.Add("@sfcontact", SqlDbType.NVarChar);
            Command.Parameters["sfcontact"].Value = _student.Student_Father_Contact;

            Command.Parameters.Add("@smname", SqlDbType.NVarChar);
            Command.Parameters["smname"].Value = _student.Student_Mother_Name;

            Command.Parameters.Add("@smcontact", SqlDbType.NVarChar);
            Command.Parameters["smcontact"].Value = _student.Student_Mother_Contact;

            Command.Parameters.Add("@id", SqlDbType.Int);
            Command.Parameters["smcontact"].Value = _student.Student_Id;

            Command.Parameters.Add("@dep", SqlDbType.Int);
            Command.Parameters["dep"].Value = _student.Department_Id;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        //public UpdatePassword FindDetails(int? id)
        //{
        //    Query = "SELECT * FROM Student WHERE student_id = @id";
        //    Command = new SqlCommand(Query, Connection);

        //    Command.Parameters.Clear();
        //    Command.Parameters.Add("id", SqlDbType.Int);
        //    Command.Parameters["id"].Value = id;

        //    Connection.Open();

        //    Reader = Command.ExecuteReader();

        //    _updatePassword = new UpdatePassword();
        //    while (Reader.Read())
        //    {
        //        _updatePassword.Id = (int)Reader["student_id"];
        //        _updatePassword.Student_Old_Password = Reader["student_password"].ToString();
        //    }
        //    Reader.Close();
        //    Connection.Close();

        //    return _updatePassword;
        //}


        //public UpdateImage FindImageDetails(int? id)
        //{
        //    Query = "SELECT * FROM Student WHERE student_id = @id";
        //    Command = new SqlCommand(Query, Connection);

        //    Command.Parameters.Clear();
        //    Command.Parameters.Add("id", SqlDbType.Int);
        //    Command.Parameters["id"].Value = id;

        //    Connection.Open();

        //    Reader = Command.ExecuteReader();

        //    _updateImage = new UpdateImage();
        //    while (Reader.Read())
        //    {
        //        _updateImage.Id = (int)Reader["student_id"];
        //        _updateImage.Student_Email = Reader["student_email"].ToString();
        //        _updateImage.ImagePath = Reader["student_image"].ToString();
        //    }
        //    Reader.Close();
        //    Connection.Close();

        //    return _updateImage;
        //}

        public bool Is_oldPasswordCorrect(UpdatePassword updatePassword)
        {
            Query = "SELECT student_password FROM Student INNER JOIN logIn ON Student.student_email = logIn.email WHERE STUDENT.student_id = @id and login.password = @pass ;";
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
            Query = "Update Student SET student_password = @pass where Student.student_email = @email";
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
            Query = "Update Student SET student_image = @image WHERE student_id = @id";
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

        public List<SemesterResult> SemesterCoursesBySemesterId(int? semesterNo)
        {
            int id = GetIdByEmail(_email);

            Query =
                "SELECT course_code,course_title,course_credit,ct_1,ct_2,ct_3,attendence,part_a,part_b,total_number,result_credit,latter_grade FROM AssignCourseToDepartment AS ASTD " +
                "INNER JOIN COURSE ON ASTD.course_id = Course.course_id " +
                "FULL JOIN Result ON Course.course_id = Result.course_id " +
                "WHERE ASTD.semester_id=@semes_id AND Result.student_id = @id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Command.Parameters.Add("semes_id", SqlDbType.Int);
            Command.Parameters["semes_id"].Value = semesterNo;

            Connection.Open();

            List<SemesterResult> courses = new List<SemesterResult>();

            Reader = Command.ExecuteReader();

            double credit_hour, multipling_credit;
            multipling_credit = 0;
            credit_hour = 0;

            while (Reader.Read())
            {
                SemesterResult course = new SemesterResult();
                course.Course_Code = Reader["course_code"].ToString();
                course.Course_Name = Reader["course_title"].ToString();
                course.CT_1 = Convert.ToDouble(Reader["ct_1"]);
                course.CT_2 = Convert.ToDouble(Reader["ct_2"]);
                course.CT_3 = Convert.ToDouble(Reader["ct_3"]);
                course.Part_A = Convert.ToDouble(Reader["part_a"]);
                course.Part_B = Convert.ToDouble(Reader["part_b"]);
                course.Grade_Point = Convert.ToDouble(Reader["result_credit"]);
                course.Latter_Grade = Reader["latter_grade"].ToString();
                course.Course_Credit = Convert.ToDouble(Reader["course_credit"]);
                course.Attendance = Convert.ToDouble(Reader["attendence"]);

                credit_hour += Convert.ToDouble(Reader["course_credit"]);

                multipling_credit += (double)course.Course_Credit * course.Grade_Point;

                courses.Add(course);
            }
            Reader.Close();

            Connection.Close();

            return courses;
        }

        private int GetIdByEmail(string email)
        {
            Query = "SELECT student_id FROM Student WHERE student_email = @email;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                RowAffected = (int)Reader["student_id"];
            }
            Reader.Close();
            Connection.Close();

            return RowAffected;
        }

        public double GetCGPA(int? semesterNo)
        {
            int id = GetIdByEmail(_email);

            Query =
                "SELECT course_credit,result_credit FROM AssignCourseToDepartment AS ASTD " +
                "INNER JOIN COURSE ON ASTD.course_id = Course.course_id " +
                "FULL JOIN Result ON Course.course_id = Result.course_id " +
                "WHERE ASTD.semester_id=@semes_id AND Result.student_id = @id";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Command.Parameters.Add("semes_id", SqlDbType.Int);
            Command.Parameters["semes_id"].Value = semesterNo;

            Connection.Open();

            List<SemesterResult> courses = new List<SemesterResult>();

            Reader = Command.ExecuteReader();

            double credit_hour, multipling_credit;
            multipling_credit = 0;
            credit_hour = 0;

            while (Reader.Read())
            {
                SemesterResult course = new SemesterResult();
                course.Grade_Point = Convert.ToDouble(Reader["result_credit"]);
                course.Course_Credit = Convert.ToDouble(Reader["course_credit"]);

                credit_hour += Convert.ToDouble(Reader["course_credit"]);

                multipling_credit += (double)course.Course_Credit * course.Grade_Point;

                courses.Add(course);
            }

            double cgpa = Math.Round((double)multipling_credit / credit_hour, 2);
            Reader.Close();

            Connection.Close();

            return cgpa;
        }

        public List<TeacherInfo> ShowAllTeacher()
        {
            Query = "SELECT * FROM Teacher";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TeacherInfo> teachers = new List<TeacherInfo>();

            while (Reader.Read())
            {
                TeacherInfo teacher = new TeacherInfo();

                teacher.Teacher_Id = (int)Reader["teacher_id"];
                teacher.Teacher_Name = Reader["teacher_name"].ToString();
                teacher.Teacher_Email = Reader["teacher_email"].ToString();
                teacher.Teacher_Contact = Reader["teacher_contact"].ToString();
                teacher.Teacher_Address = Reader["teacher_address"].ToString();
                teacher.Teacher_Father_Name = Reader["teacher_fathers_name"].ToString();
                teacher.Teacher_Mother_Name = Reader["teacher_mothers_name"].ToString();
                teacher.Designation = Reader["teacher_designation"].ToString();
                teacher.Teacher_RemainingCredit = (float)Convert.ToDouble(Reader["remaining_course_credit"]);
                teacher.Teacher_TotalCredt = (float)Convert.ToDouble(Reader["teacher_course_credit"]);
                teacher.Teacher_Birth_Date = (DateTime)Reader["teacher_date_of_birth"];
                teacher.ImagePath = Reader["teacher_image"].ToString();

                teachers.Add(teacher);
            }
            Reader.Close();
            Connection.Close();

            return teachers;
        }

        public TeacherInfo TeachersDetails(int? id)
        {
            Query = "SELECT * FROM Teacher inner join Department on Teacher.teacher_department = Department.department_id WHERE teacher_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            TeacherInfo teacher = new TeacherInfo();

            while (Reader.Read())
            {
                teacher.Teacher_Id = (int)Reader["teacher_id"];
                teacher.Teacher_Name = Reader["teacher_name"].ToString();
                teacher.Teacher_Email = Reader["teacher_email"].ToString();
                teacher.Teacher_Contact = Reader["teacher_contact"].ToString();
                teacher.Teacher_Birth_Date = (DateTime)Reader["teacher_date_of_birth"];
                teacher.Teacher_Address = Reader["teacher_address"].ToString();
                teacher.Teacher_Father_Name = Reader["teacher_fathers_name"].ToString();
                teacher.Teacher_Mother_Name = Reader["teacher_mothers_name"].ToString();
                teacher.Department_Id = (int)Reader["teacher_department"];
                teacher.Department_Name = Reader["department_title"].ToString();
                teacher.Department_Code = Reader["department_code"].ToString();
                teacher.ImagePath = Reader["teacher_image"].ToString();
                teacher.Designation = Reader["teacher_designation"].ToString();
                teacher.Teacher_RemainingCredit = (float)Convert.ToDouble(Reader["remaining_course_credit"]);
                teacher.Teacher_TotalCredt = (float)Convert.ToDouble(Reader["teacher_course_credit"]);
            }
            Reader.Close();
            Connection.Close();

            return teacher;
        }

        public List<Thesis> GetThesisInfo(int? id)
        {
            Query = "SELECT thesis_title, thesis_description FROM Thesis WHERE teacher_id = @id;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Thesis> theses = new List<Thesis>();

            while (Reader.Read())
            {
                Thesis thesis = new Thesis();

                thesis.Thesis_Title = Reader["thesis_title"].ToString();
                thesis.Thesis_Description = Reader["thesis_description"].ToString();

                theses.Add(thesis);
            }
            Reader.Close();
            Connection.Close();

            return theses;
        }
    }
}