namespace ResultManagement.Models
{
    public class ResultViewForTeacherModel
    {
        public int Id { get; set; }
        public string Student_Name { get; set; }
        public string Student_Reg { get; set; }
        public string Course_Code { get; set; }
        public double CT_1 { get; set; }
        public double CT_2 { get; set; }
        public double CT_3 { get; set; }
        public double Attendence { get; set; }
        public double Part_A { get; set; }
        public double Part_B { get; set; }
        public double Result_Cgpa { get; set; }
        public string Latter_Grade { get; set; }
    }
}