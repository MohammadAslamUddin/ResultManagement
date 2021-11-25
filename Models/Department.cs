using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        public int Department_Id { get; set; }



        [Display(Name = "Department Title")]
        [Required(ErrorMessage = "Department Title Required")]
        public string Department_Title { get; set; }



        [Display(Name = "Department Code")]
        [Required(ErrorMessage = "Department Code Required")]
        public string Department_Code { get; set; }
    }
}