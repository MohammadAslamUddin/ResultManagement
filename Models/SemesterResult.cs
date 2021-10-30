using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{

    public class SemesterResult
    {
        public int Id { get; set; }



        [Display(Name = "Course Name")]
        public string Course_Name { get; set; }
        [Display(Name = "Course Code")]
        public string Course_Code { get; set; }
        public double Ct1 { get; set; }
        public double Ct2 { get; set; }
        public double Ct3 { get; set; }
        public double Part_A { get; set; }
        public double Part_B { get; set; }
        [Display(Name = "Grade Point")]
        public double Grade_Point { get; set; }
        [Display(Name = "Latter Grade")]
        public string Latter_Grade { get; set; }
        public double Attendence { get; set; }
        public double Total_Grade { get; set; }
        public double CGPA { get; set; }
        public double Course_Credit { get; set; }
    }

    /*public class Result
    {
        public int Result_Id { get; set; }
        
                public List<SemesterResult> CoursesOfSemester { get; set; }

                public double Final_CGPA { get; set; }
            }*/
}