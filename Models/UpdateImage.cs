using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ResultManagement.Models
{
    public class UpdateImage
    {
        [Key]
        public int Id { get; set; }


        public string Student_Email { get; set; }


        [Display(Name = "Image Path")]
        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }
    }
}