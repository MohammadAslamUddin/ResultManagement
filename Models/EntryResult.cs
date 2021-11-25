using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    [System.Runtime.InteropServices.Guid("D79EECC4-73B4-42F3-950E-D5DB4CDC03EA")]
    public class EntryResult
    {
        [Key]
        [Display(Name = "Entry Result Id")]
        public int EntryResult_Id { get; set; }


        [Required]
        [Display(Name = "Student Name")]
        public string Student_Name { get; set; }



        [Required]
        [Display(Name = "Student Registration No")]
        public string Student_Reg { get; set; }


        [Required]
        [Display(Name = "Student's Email")]
        public string Student_Email { get; set; }


        [Required]
        [Display(Name = "Student's Contact")]
        public string Student_Contact { get; set; }


        [Required]
        [Display(Name = "Student's Department")]
        public string Student_Department { get; set; }


        [Required]
        [Display(Name = "Semester")]
        public string Student_Semester { get; set; }


        [Required]
        [Display(Name = "Course Code")]
        public string Course_Code { get; set; }


        [Required]
        [Display(Name = "Course Id")]
        public int Course_Id { get; set; }


        [Required]
        [Display(Name = "Course Title")]
        public string Course_Title { get; set; }


        [Required]
        [Display(Name = "Course Credit")]
        public string Course_Credit { get; set; }


        [Required]
        [Display(Name = "Class Test No 1")]
        public double ClassTest1 { get; set; }


        [Required]
        [Display(Name = "Class Test No 2")]
        public double ClassTest2 { get; set; }


        [Required]
        [Display(Name = "Class Test No 3")]
        public double ClassTest3 { get; set; }


        [Required]
        [Display(Name = "Attendance")]
        public double Attendance { get; set; }


        [Required]
        [Display(Name = "Part A")]
        public double PartA { get; set; }



        [Required]
        [Display(Name = "Part B")]
        public double PartB { get; set; }



        [Required]
        [Display(Name = "Grade Point")]
        public double Grade_Point { get; set; }



        [Required]
        [Display(Name = "Letter Grade")]
        public string Letter_Grade { get; set; }



        [Required]
        [Display(Name = "Total Number")]
        public double TotalNumber { get; set; }
    }


    public class PracticalPartResult
    {
        [Key]
        [Required]
        [Display(Name = "Practical Result Id")]
        public int PracticalResultId { get; set; }



        [Required]
        [Display(Name = "Student Name")]
        public string Student_Name { get; set; }



        [Required]
        [Display(Name = "Student Registration No")]
        public string Student_Reg { get; set; }



        [Required]
        [Display(Name = "Student's Email")]
        public string Student_Email { get; set; }



        [Required]
        [Display(Name = "Student's Contact")]
        public string Student_Contact { get; set; }



        [Required]
        [Display(Name = "Student's Department")]
        public string Student_Department { get; set; }



        [Required]
        [Display(Name = "Semester")]
        public string Student_Semester { get; set; }



        [Required]
        [Display(Name = "Course Code")]
        public string Course_Code { get; set; }



        [Required]
        [Display(Name = "Course Id")]
        public int Course_Id { get; set; }



        [Required]
        [Display(Name = "Course Title")]
        public string Course_Title { get; set; }



        [Required]
        [Display(Name = "Course Credit")]
        public string Course_Credit { get; set; }



        [Required]
        [Display(Name = "Viva Number")]
        public double Viva { get; set; }



        [Required]
        [Display(Name = "Quiz Number")]
        public double Quiz { get; set; }



        [Required]
        [Display(Name = "Attendance")]
        public double Attendance { get; set; }



        [Required]
        [Display(Name = "Lab Report Mark")]
        public double Lab_Report { get; set; }



        [Required]
        [Display(Name = "Class Performance")]
        public double ClassPerformance { get; set; }



        [Required]
        [Display(Name = "Grade Point")]
        public double Grade_Point { get; set; }



        [Required]
        [Display(Name = "Letter Grade")]
        public string Letter_Grade { get; set; }



        [Required]
        [Display(Name = "Total Number")]
        public double TotalNumber { get; set; }
    }
}