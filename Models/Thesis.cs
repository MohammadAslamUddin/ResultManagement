using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    public class Thesis
    {
        [Key]
        public int Thesis_Id { get; set; }



        [Required]
        [Display(Name = "Thesis Title")]
        public string Thesis_Title { get; set; }


        [Required]
        [Display(Name = "Thesis Description")]
        public string Thesis_Description { get; set; }


        [Required]
        [Display(Name = "Teacher's Id")]
        public int Teacher_Id { get; set; }
    }
}