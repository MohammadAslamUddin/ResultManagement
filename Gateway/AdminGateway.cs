using ResultManagement.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ResultManagement.Gateway
{
    public class AdminGateway : CommonGateway
    {
        public List<StudentInfo> GetStudentInfoBySearching(string stri)
        {
            if (stri == "")
            {
                Query = "SELECT student_id,student_name, student_reg_no,student_email,student_contact, student_address, student_image FROM Student";
            }
            else
            {
                Query =
                    "SELECT student_id,student_name, student_reg_no,student_email,student_contact, student_address, student_image FROM Student WHERE student_name LIKE @name";
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
                student.Student_Name = Reader["student_name"].ToString();
                student.Student_Reg = Reader["student_reg_no"].ToString();
                student.Student_Email = Reader["student_email"].ToString();
                student.Student_Contact = Reader["student_contact"].ToString();
                student.Student_Address = Reader["student_address"].ToString();
                student.ImagePath = Reader["student_image"].ToString();

                students.Add(student);
            }
            Reader.Close();
            Connection.Close();

            return students;
        }
    }
}