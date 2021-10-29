using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ResultManagement.Models
{
    public class TeacherInfo
    {
        [Key]
        public int Teacher_Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter a name")]
        public string Teacher_Name { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter an email")]
        public string Teacher_Email { get; set; }


        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please select a date")]
        public DateTime Teacher_Birth_Date { get; set; }


        [Display(Name = "Contact No")]
        [Required(ErrorMessage = "Please enter a contact number")]
        public string Teacher_Contact { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter home address")]
        public string Teacher_Address { get; set; }


        [Display(Name = "Father's Name")]
        [Required(ErrorMessage = "Please enter Teacher's father's name")]
        public string Teacher_Father_Name { get; set; }


        [Display(Name = "Mother's Name")]
        [Required(ErrorMessage = "Please enter Teacher's mother's name")]
        public string Teacher_Mother_Name { get; set; }


        [Display(Name = "Department")]
        [Required(ErrorMessage = "Please Select a department")]
        public int Department_Id { get; set; }


        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Please Select a department")]
        public string Department_Name { get; set; }


        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Please Select a department")]
        public string Department_Code { get; set; }


        [Required(ErrorMessage = "Please Select a designation")]
        public string Designation { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [PasswordPropertyText]
        public string Teachers_Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [PasswordPropertyText]
        [NotMapped]
        [Compare(otherProperty: "Teachers_Password")]
        public string Teachers_Confirm_Password { get; set; }


        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }

    }
}