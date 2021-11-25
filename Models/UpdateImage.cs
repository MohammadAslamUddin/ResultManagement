using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ResultManagement.Models
{
    public class UpdateImage
    {
        [Key]
        public int Id { get; set; }



        [Required]
        [Display(Name = "Student Email")]
        public string Student_Email { get; set; }



        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }


        [Required]
        [Display(Name = "Image File")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}