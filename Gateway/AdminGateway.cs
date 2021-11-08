using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ResultManagement.Gateway
{
    public class AdminGateway : CommonGateway
    {
        private StudentInfo _student;
        private TeacherInfo _teacher;
        public List<StudentInfo> GetStudentInfoBySearching(string stri)
        {
            if (stri == "")
            {
                Query = "SELECT student_id,student_name, student_reg_no,student_email,student_contact, student_address, student_semester, student_image FROM Student";
            }
            else
            {
                Query =
                    "SELECT student_id,student_name, student_reg_no,student_email,student_contact, student_address, student_semester, student_image FROM Student WHERE student_name LIKE @name";
            }

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = "%" + stri + "%";

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentInfo> students = new List<StudentInfo>();
            while (Reader.Read())
            {
                StudentInfo student = new StudentInfo();
                student.Student_Id = (int)Reader["student_id"];
                student.Student_Name = Reader["student_name"].ToString();
                student.Student_Reg = Reader["student_reg_no"].ToString();
                student.Student_Email = Reader["student_email"].ToString();
                student.Student_Contact = Reader["student_contact"].ToString();
                student.Student_Address = Reader["student_address"].ToString();
                student.Student_Semester = (int)Reader["student_semester"];
                student.ImagePath = Reader["student_image"].ToString();

                students.Add(student);
            }
            Reader.Close();
            Connection.Close();

            return students;
        }

        public StudentInfo StudentDetails(int? id)
        {
            Query = "SELECT * FROM Student inner join Department on Student.student_department = Department.department_id WHERE student_id = @id";
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
                _student.Student_Birth_Date = ((DateTime)Reader["student_date_of_birth"]).ToString("MM/dd/yyyy");
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
                _student.Student_Semester = (int)Reader["student_semester"];
            }
            Reader.Close();
            Connection.Close();

            return _student;
        }

        public List<TeacherInfo> ViewAllTeachers(string stri)
        {
            if (stri == "")
            {
                Query = "SELECT * FROM Teacher";
            }
            else
            {
                Query = "SELECT * FROM Teacher WHERE teacher_name LIKE @name";
            }
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("name", SqlDbType.VarChar);
            Command.Parameters["name"].Value = "%" + stri + "%";

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<TeacherInfo> teachers = new List<TeacherInfo>();

            while (Reader.Read())
            {
                _teacher = new TeacherInfo();

                _teacher.Teacher_Id = (int)Reader["teacher_id"];
                _teacher.Teacher_Name = Reader["teacher_name"].ToString();
                _teacher.Teacher_Email = Reader["teacher_email"].ToString();
                _teacher.Teacher_Contact = Reader["teacher_contact"].ToString();
                _teacher.Teacher_Address = Reader["teacher_address"].ToString();
                _teacher.Teacher_Father_Name = Reader["teacher_fathers_name"].ToString();
                _teacher.Teacher_Mother_Name = Reader["teacher_mothers_name"].ToString();
                _teacher.Designation = Reader["teacher_designation"].ToString();
                _teacher.Teacher_RemainingCredit = (float)Convert.ToDouble(Reader["remaining_course_credit"]);
                _teacher.Teacher_TotalCredt = (float)Convert.ToDouble(Reader["teacher_course_credit"]);
                _teacher.Teacher_Birth_Date = ((DateTime)Reader["teacher_date_of_birth"]).ToString("MM/dd/yyyy");
                _teacher.ImagePath = Reader["teacher_image"].ToString();

                teachers.Add(_teacher);
            }
            Reader.Close();
            Connection.Close();

            return teachers;
        }

        public TeacherInfo TeacherDetails(int? id)
        {
            Query = "SELECT * FROM Teacher inner join Department on Teacher.teacher_department = Department.department_id WHERE teacher_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = id;

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
                _teacher.Teacher_RemainingCredit = (float)Convert.ToDouble(Reader["remaining_course_credit"]);
                _teacher.Teacher_TotalCredt = (float)Convert.ToDouble(Reader["teacher_course_credit"]);
            }
            Reader.Close();
            Connection.Close();

            return _teacher;
        }

        public int UpdateStudentDetails(StudentInfo student)
        {
            Query = "UPDATE Student SET student_name = @sname, student_email=@semail, student_date_of_birth=@sdob, student_contact=@scontact, student_address=@sadd, student_fathers_name=@sfname, student_fathers_contact=@sfcontact, " +
                    "student_mothers_name=@smname, student_mothers_contact=@smcontact, student_semester=@semes " +
                    "WHERE student_id=@id; ";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("sname", SqlDbType.VarChar);
            Command.Parameters["sname"].Value = student.Student_Name;

            Command.Parameters.Add("semail", SqlDbType.VarChar);
            Command.Parameters["semail"].Value = student.Student_Email;

            Command.Parameters.Add("sdob", SqlDbType.Date);
            Command.Parameters["sdob"].Value = student.Student_Birth_Date;

            Command.Parameters.Add("scontact", SqlDbType.VarChar);
            Command.Parameters["scontact"].Value = student.Student_Contact;

            Command.Parameters.Add("sadd", SqlDbType.VarChar);
            Command.Parameters["sadd"].Value = student.Student_Address;

            Command.Parameters.Add("sfname", SqlDbType.VarChar);
            Command.Parameters["sfname"].Value = student.Student_Father_Name;

            Command.Parameters.Add("sfcontact", SqlDbType.VarChar);
            Command.Parameters["sfcontact"].Value = student.Student_Father_Contact;

            Command.Parameters.Add("smname", SqlDbType.VarChar);
            Command.Parameters["smname"].Value = student.Student_Mother_Name;

            Command.Parameters.Add("smcontact", SqlDbType.VarChar);
            Command.Parameters["smcontact"].Value = student.Student_Mother_Contact;

            Command.Parameters.Add("semes", SqlDbType.Int);
            Command.Parameters["semes"].Value = student.Student_Semester;

            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = student.Student_Id;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT * FROM Department;";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Department> departments = new List<Department>();

            while (Reader.Read())
            {
                Department department = new Department();
                department.Department_Id = (int)Reader["department_id"];
                department.Department_Title = Reader["department_title"].ToString();
                department.Department_Code = Reader["department_code"].ToString();

                departments.Add(department);
            }
            Reader.Close();
            Connection.Close();

            return departments;
        }

        public int UpdateTeacherDetails(TeacherInfo teacher)
        {
            Query = "UPDATE Teacher SET teacher_name=@tname, teacher_email=@temail, teacher_date_of_birth=@tdob, teacher_contact=@tcontact, teacher_address=@tadd, teacher_fathers_name=@tfname, teacher_mothers_name=@tmname, teacher_designation=@tdes " +
                    "WHERE teacher_id = @id;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("tname", SqlDbType.VarChar);
            Command.Parameters["tname"].Value = teacher.Teacher_Name;

            Command.Parameters.Add("temail", SqlDbType.VarChar);
            Command.Parameters["temail"].Value = teacher.Teacher_Email;

            Command.Parameters.Add("tdob", SqlDbType.Date);
            Command.Parameters["tdob"].Value = teacher.Teacher_Birth_Date;

            Command.Parameters.Add("tcontact", SqlDbType.VarChar);
            Command.Parameters["tcontact"].Value = teacher.Teacher_Contact;

            Command.Parameters.Add("tadd", SqlDbType.VarChar);
            Command.Parameters["tadd"].Value = teacher.Teacher_Address;

            Command.Parameters.Add("tfname", SqlDbType.VarChar);
            Command.Parameters["tfname"].Value = teacher.Teacher_Father_Name;

            Command.Parameters.Add("tmname", SqlDbType.VarChar);
            Command.Parameters["tmname"].Value = teacher.Teacher_Mother_Name;

            Command.Parameters.Add("tdes", SqlDbType.VarChar);
            Command.Parameters["tdes"].Value = teacher.Designation;

            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = teacher.Teacher_Id;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }
    }
}