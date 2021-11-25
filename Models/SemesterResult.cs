using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{

    public class SemesterResult
    {
        [Key]
        public int Id { get; set; }



        [Required]
        [Display(Name = "Course Name")]
        public string Course_Name { get; set; }



        [Required]
        [Display(Name = "Course Code")]
        public string Course_Code { get; set; }




        [Required]
        [Display(Name = "Class Test 1")]
        public double CT_1 { get; set; }



        [Required]
        [Display(Name = "Class Test 2")]
        public double CT_2 { get; set; }


        [Required]
        [Display(Name = "Class Test 3")]
        public double CT_3 { get; set; }



        [Required]
        [Display(Name = "Attendance")]
        public double Attendance { get; set; }



        [Required]
        [Display(Name = "Part A")]
        public double Part_A { get; set; }



        [Required]
        [Display(Name = "Part B")]
        public double Part_B { get; set; }



        [Required]
        [Display(Name = "Grade Point")]
        public double Grade_Point { get; set; }



        [Required]
        [Display(Name = "Latter Grade")]
        public string Latter_Grade { get; set; }



        [Required]
        [Display(Name = "Total Grade")]
        public double Total_Grade { get; set; }



        [Required]
        [Display(Name = "CGPA")]
        public double CGPA { get; set; }



        [Required]
        [Display(Name = "Course Credit")]
        public double Course_Credit { get; set; }
    }
}