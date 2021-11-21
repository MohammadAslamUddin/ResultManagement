using ResultManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

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



        public int SaveStudent(StudentInfo student)
        {
            int rowAffect = InsertDataIntoRoleAndLoginPage(student);

            if (rowAffect > 0)
            {
                student.Student_Reg = GetRegistrationNumber(student);
                student.Student_Semester = 1;

                Query = "INSERT INTO Student VALUES(@sname,@semail,@scont,@sdob,@sadd, @sfname,@sfcont,@smname,@smcont,@sreg,@sdep,@spass,@simg,@semes);";

                Command = new SqlCommand(Query, Connection);

                Command.Parameters.Clear();
                Command.Parameters.Add("sname", SqlDbType.VarChar);
                Command.Parameters["sname"].Value = student.Student_Name;

                Command.Parameters.Add("semail", SqlDbType.VarChar);
                Command.Parameters["semail"].Value = student.Student_Email;

                Command.Parameters.Add("scont", SqlDbType.VarChar);
                Command.Parameters["scont"].Value = student.Student_Contact;

                Command.Parameters.Add("sdob", SqlDbType.Date);
                Command.Parameters["sdob"].Value = student.Student_Birth_Date;

                Command.Parameters.Add("sadd", SqlDbType.VarChar);
                Command.Parameters["sadd"].Value = student.Student_Address;

                Command.Parameters.Add("sfname", SqlDbType.VarChar);
                Command.Parameters["sfname"].Value = student.Student_Father_Name;

                Command.Parameters.Add("sfcont", SqlDbType.VarChar);
                Command.Parameters["sfcont"].Value = student.Student_Father_Contact;

                Command.Parameters.Add("smname", SqlDbType.VarChar);
                Command.Parameters["smname"].Value = student.Student_Mother_Name;

                Command.Parameters.Add("smcont", SqlDbType.VarChar);
                Command.Parameters["smcont"].Value = student.Student_Mother_Contact;

                Command.Parameters.Add("sreg", SqlDbType.VarChar);
                Command.Parameters["sreg"].Value = student.Student_Reg;

                Command.Parameters.Add("sdep", SqlDbType.Int);
                Command.Parameters["sdep"].Value = student.Department_Id;

                Command.Parameters.Add("semes", SqlDbType.Int);
                Command.Parameters["semes"].Value = student.Student_Semester;

                Command.Parameters.Add("spass", SqlDbType.NVarChar);
                Command.Parameters["spass"].Value = student.Student_Password;

                Command.Parameters.Add("simg", SqlDbType.NVarChar);
                Command.Parameters["simg"].Value = student.ImagePath;

                Connection.Open();

                RowAffected = Command.ExecuteNonQuery();

                Connection.Close();

                return RowAffected;
            }
            else
            {
                return rowAffect;
            }
        }

        private int InsertDataIntoRoleAndLoginPage(StudentInfo student)
        {
            int rowAffected = InsertLoginPageData(student);
            if (rowAffected > 0)
            {
                int userRole = GetUserRole(student);
                Query = "INSERT INTO Role VALUES(@role, 'Student')";
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.Clear();
                Command.Parameters.Add("role", SqlDbType.Int);
                Command.Parameters["role"].Value = userRole;

                Connection.Open();

                RowAffected = Command.ExecuteNonQuery();

                Connection.Close();
                return RowAffected;
            }
            else
            {
                return rowAffected;
            }

        }

        private int GetUserRole(StudentInfo student)
        {
            Query = "SELECT * FROM LOGIN WHERE email = @email";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Student_Email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int userRole = 0;
            if (Reader.Read())
            {
                userRole = (int)Reader["id"];
            }
            Connection.Close();
            return userRole;
        }

        private int InsertLoginPageData(StudentInfo student)
        {
            Query = "INSERT INTO LOGIN VALUES(@semail, @spass)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("semail", SqlDbType.VarChar);
            Command.Parameters["semail"].Value = student.Student_Email;

            Command.Parameters.Add("spass", SqlDbType.NVarChar);
            Command.Parameters["spass"].Value = student.Student_Password;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;

        }

        private string GetRegistrationNumber(StudentInfo student)
        {
            string short_form_of_Department = ShortFormOfDepartment(student.Department_Id);
            string month = GetMonthNumber();
            int year = GetYear();
            string serialNo = GetSerialNo(short_form_of_Department + "-" + month + "-" + year);

            string registrationNo = short_form_of_Department + "-" + month + "-" + year + "-" + serialNo;
            return registrationNo;
        }

        private string GetSerialNo(string regNo)
        {
            Query = "SELECT TOP 1 * FROM Student WHERE student_reg_no LIKE @regNo ORDER BY student_id DESC";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("regNo", SqlDbType.VarChar);
            Command.Parameters["regNo"].Value = regNo;

            Connection.Open();

            Reader = Command.ExecuteReader();

            string num = "";
            if (Reader.HasRows)
            {
                string reg = "";
                if (Reader.Read())
                {
                    reg = Reader["student_reg_no"].ToString();
                }
                string regis = Convert.ToString(Convert.ToInt32(reg.Substring(reg.Length - 2)) + 1);
                if (regis.Length == 1)
                {
                    num = "0" + regis;
                }
                else
                {
                    num = regis;
                }
            }
            else
            {
                num = "01";
            }
            Reader.Close();
            Connection.Close();

            return num;
        }

        private int GetYear()
        {
            int fYear;
            if (DateTime.Today.Month < 9)
            {
                fYear = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2));
            }
            else
            {
                fYear = Convert.ToInt32(DateTime.Today.Year.ToString().Substring(2, 2)) + 1;
            }
            return fYear;
        }

        private string GetMonthNumber()
        {
            string sMonth = DateTime.Now.ToString("MM");
            if (sMonth == "1" || sMonth == "2" || sMonth == "9" || sMonth == "10" || sMonth == "11" || sMonth == "12")
            {
                sMonth = "01";
            }
            else
            {
                sMonth = "06";
            }
            return sMonth;
        }

        private string ShortFormOfDepartment(int dep)
        {
            Query = "SELECT * FROM Department WHERE department_id = @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("id", SqlDbType.Int);
            Command.Parameters["id"].Value = dep;

            Connection.Open();

            Reader = Command.ExecuteReader();

            string sdep = "";
            while (Reader.Read())
            {
                sdep = Reader["department_code"].ToString();
            }
            Reader.Close();
            Connection.Close();

            return sdep;
        }

        public int DeleteFromRoleAndLogInSystem(StudentInfo student)
        {
            int deleteRole = DeleteFromRole(student);
            int deleteLogin = 0;
            if (deleteRole != 0)
            {
                deleteLogin = DeleteFromLogIn(student);
            }

            return deleteLogin;
        }

        private int DeleteFromLogIn(StudentInfo student)
        {
            Query = "DELETE FROM logIn WHERE email = @email;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Student_Email;

            Connection.Open();
            RowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return RowAffected;
        }

        private int DeleteFromRole(StudentInfo student)
        {
            Query = "SELECT * FROM Login WHERE email = @email;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Student_Email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int userRole = 0;
            if (Reader.Read())
            {
                userRole = (int)Reader["id"];
                if (userRole != 0)
                {
                    int role = DeleteRole(userRole);
                }
            }
            Reader.Close();
            Connection.Close();
            return userRole;
        }

        private int DeleteRole(int role)
        {
            Query = "DELETE FROM Role WHERE userRole = @val;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("val", SqlDbType.Int);
            Command.Parameters["val"].Value = role;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Reader.Close();
            Connection.Close();
            return RowAffected;
        }

        public int SaveTeacher(TeacherInfo teacher)
        {

            int rowAffect = InsertTecherDataIntoRoleAndLoginPage(teacher);
            if (rowAffect > 0)
            {
                teacher.Teacher_TotalCredt = 24;
                teacher.Teacher_RemainingCredit = 24;
                Query = "INSERT INTO Teacher VALUES(@name,@email,@contact,@dob,@add,@tfname,@tmname,@dep,@pass,@img,@tcourse,@rcourse,@desig);";
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.Clear();
                Command.Parameters.Add("name", SqlDbType.VarChar);
                Command.Parameters["name"].Value = teacher.Teacher_Name;

                Command.Parameters.Add("email", SqlDbType.VarChar);
                Command.Parameters["email"].Value = teacher.Teacher_Email;

                Command.Parameters.Add("contact", SqlDbType.VarChar);
                Command.Parameters["contact"].Value = teacher.Teacher_Contact;

                Command.Parameters.Add("dob", SqlDbType.VarChar);
                Command.Parameters["dob"].Value = teacher.Teacher_Birth_Date;

                Command.Parameters.Add("add", SqlDbType.VarChar);
                Command.Parameters["add"].Value = teacher.Teacher_Address;

                Command.Parameters.Add("tfname", SqlDbType.VarChar);
                Command.Parameters["tfname"].Value = teacher.Teacher_Father_Name;

                Command.Parameters.Add("tmname", SqlDbType.VarChar);
                Command.Parameters["tmname"].Value = teacher.Teacher_Mother_Name;

                Command.Parameters.Add("dep", SqlDbType.Int);
                Command.Parameters["dep"].Value = teacher.Department_Id;

                Command.Parameters.Add("tcourse", SqlDbType.Int);
                Command.Parameters["tcourse"].Value = teacher.Teacher_TotalCredt;

                Command.Parameters.Add("rcourse", SqlDbType.Int);
                Command.Parameters["rcourse"].Value = teacher.Teacher_RemainingCredit;

                Command.Parameters.Add("img", SqlDbType.VarChar);
                Command.Parameters["img"].Value = teacher.ImagePath;

                Command.Parameters.Add("desig", SqlDbType.VarChar);
                Command.Parameters["desig"].Value = teacher.Designation;

                Command.Parameters.Add("pass", SqlDbType.NVarChar);
                Command.Parameters["pass"].Value = teacher.Teachers_Password;


                Connection.Open();

                RowAffected = Command.ExecuteNonQuery();

                Connection.Close();
            }
            else
            {
                return rowAffect;
            }

            return RowAffected;
        }

        private int InsertTecherDataIntoRoleAndLoginPage(TeacherInfo teacher)
        {
            int rowAffected = InsertLoginPageDataTeacher(teacher);
            if (rowAffected > 0)
            {
                int userRole = GetUserRoleTeacher(teacher);
                Query = "INSERT INTO Role VALUES(@role, 'Teacher')";
                Command = new SqlCommand(Query, Connection);

                Command.Parameters.Clear();
                Command.Parameters.Add("role", SqlDbType.Int);
                Command.Parameters["role"].Value = userRole;

                Connection.Open();

                RowAffected = Command.ExecuteNonQuery();

                Connection.Close();
                return RowAffected;
            }
            else
            {
                return rowAffected;
            }
        }

        private int GetUserRoleTeacher(TeacherInfo teacher)
        {
            Query = "SELECT * FROM LOGIN WHERE email = @email";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = teacher.Teacher_Email;

            Connection.Open();

            Reader = Command.ExecuteReader();

            int userRole = 0;
            if (Reader.Read())
            {
                userRole = (int)Reader["id"];
            }
            Connection.Close();
            return userRole;
        }

        private int InsertLoginPageDataTeacher(TeacherInfo teacher)
        {
            Query = "INSERT INTO LOGIN VALUES(@semail, @spass)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("semail", SqlDbType.VarChar);
            Command.Parameters["semail"].Value = teacher.Teacher_Email;

            Command.Parameters.Add("spass", SqlDbType.NVarChar);
            Command.Parameters["spass"].Value = teacher.Teachers_Password;

            Connection.Open();

            RowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return RowAffected;
        }

        public bool IsStudentExist(StudentInfo student)
        {
            Query = "SELECT * FROM Student WHERE student_email = @email OR student_contact = @contact;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = student.Student_Email;

            Command.Parameters.Add("contact", SqlDbType.VarChar);
            Command.Parameters["contact"].Value = student.Student_Contact;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public bool IsTeacherExist(TeacherInfo teacher)
        {
            Query = "SELECT * FROM Teacher WHERE teacher_email = @email OR teacher_contact = @contact;";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.Add("email", SqlDbType.VarChar);
            Command.Parameters["email"].Value = teacher.Teacher_Email;

            Command.Parameters.Add("contact", SqlDbType.VarChar);
            Command.Parameters["contact"].Value = teacher.Teacher_Contact;

            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRows = Reader.HasRows;

            Reader.Close();
            Connection.Close();

            return hasRows;
        }

        public List<SelectListItem> GetAllTeachers()
        {
            Query = "SELECT * FROM Teacher inner join Department on Teacher.teacher_department = Department.department_id";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<TeacherInfo> teachers = new List<TeacherInfo>();
            List<SelectListItem> teacherss = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Select A Teacher", Value = ""}
            };

            while (Reader.Read())
            {
                _teacher = new TeacherInfo();
                SelectListItem teacherr = new SelectListItem();

                teacherr.Value = Reader["teacher_id"].ToString();
                teacherr.Text = Reader["teacher_name"].ToString();


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

                teachers.Add(_teacher);
                teacherss.Add(teacherr);
            }
            Reader.Close();
            Connection.Close();
            return teacherss;
        }

        public List<SelectListItem> GetAllCourses()
        {
            Query = "SELECT * FROM Course";
            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Course> courses = new List<Course>();

            List<SelectListItem> coursess = new List<SelectListItem>();
            while (Reader.Read())
            {
                Course course = new Course();
                SelectListItem coursee = new SelectListItem();

                coursee.Value = Reader["course_id"].ToString();
                coursee.Text = Reader["course_title"].ToString();


                course.CourseId = (int)Reader["course_id"];
                course.CourseCode = Reader["course_code"].ToString();
                course.CourseTitle = Reader["course_title"].ToString();
                course.CoursePoint = Convert.ToDouble(Reader["course_credit"]);

                courses.Add(course);
                coursess.Add(coursee);
            }
            Reader.Close();
            Connection.Close();

            return coursess;
        }
    }
}