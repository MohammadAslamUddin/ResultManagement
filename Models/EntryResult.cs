namespace ResultManagement.Models
{
    public class EntryResult
    {
        public int EntryResult_Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Reg { get; set; }
        public string Student_Email { get; set; }
        public string Student_Contact { get; set; }
        public string Student_Department { get; set; }
        public string Student_Semester { get; set; }
        public string Course_Code { get; set; }
        public int Course_Id { get; set; }
        public string Course_Title { get; set; }
        public string Course_Credit { get; set; }
        public double ClassTest1 { get; set; }
        public double ClassTest2 { get; set; }
        public double ClassTest3 { get; set; }
        public double Attendence { get; set; }
        public double PartA { get; set; }
        public double PartB { get; set; }
        public double Grade_Point { get; set; }
        public string Letter_Grade { get; set; }
        public double TotalNumber { get; set; }
    }


    public class PracticalPartResult
    {
        public int EntryResult_Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Reg { get; set; }
        public string Student_Email { get; set; }
        public string Student_Contact { get; set; }
        public string Student_Department { get; set; }
        public string Student_Semester { get; set; }
        public string Course_Code { get; set; }
        public int Course_Id { get; set; }
        public string Course_Title { get; set; }
        public string Course_Credit { get; set; }
        public double Viva { get; set; }
        public double Quiz { get; set; }
        public double Attendence { get; set; }
        public double Lab_Report { get; set; }
        public double Class_Performance { get; set; }
        public double Grade_Point { get; set; }
        public string Letter_Grade { get; set; }
        public double TotalNumber { get; set; }
    }
}