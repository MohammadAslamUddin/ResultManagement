using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ResultManagement.Models
{
    public class StudentInfo
    {
        [Key]
        public int Student_Id { get; set; }



        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name")]
        public string Student_Name { get; set; }



        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter an email")]
        public string Student_Email { get; set; }



        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please select a date")]
        public DateTime Student_Birth_Date { get; set; }



        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please enter a contact number")]
        public string Student_Contact { get; set; }



        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter home address")]
        public string Student_Address { get; set; }



        [Display(Name = "Father's Name")]
        [Required(ErrorMessage = "Please enter your father's name")]
        public string Student_Father_Name { get; set; }



        [Display(Name = "Father's Contact")]
        [Required(ErrorMessage = "Please enter your father's contact")]
        public string Student_Father_Contact { get; set; }



        [Display(Name = "Mother's Name")]
        [Required(ErrorMessage = "Please enter your mother's name")]
        public string Student_Mother_Name { get; set; }



        [Display(Name = "Mother's Contact")]
        [Required(ErrorMessage = "Please enter your mother's contact")]
        public string Student_Mother_Contact { get; set; }



        [Display(Name = "Student's Registration No")]
        public string Student_Reg { get; set; }



        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select a department")]
        public int Department_Id { get; set; }



        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Select a department")]
        public string Department_Name { get; set; }



        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please Select a department")]
        public string Department_Code { get; set; }



        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [PasswordPropertyText]
        public string Student_Password { get; set; }



        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [PasswordPropertyText]
        [NotMapped]
        [Compare(otherProperty: "Student_Password")]
        public string Student_Confirm_Password { get; set; }



        [Display(Name = "Student Semester")]
        [Required(ErrorMessage = "Student Semester Required")]
        public int Student_Semester { get; set; }



        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please Select a type")]
        public int Student_Type { get; set; }



        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }



        [Required]
        [Display(Name = "Image File")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}