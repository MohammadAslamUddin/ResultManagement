using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultManagement.Models
{
    public class UpdatePassword
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Email { get; set; }



        [Display(Name = "New Password")]
        [Required(ErrorMessage = "Password Required")]
        [PasswordPropertyText]
        public string New_Password { get; set; }



        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password Required")]
        [PasswordPropertyText]
        [NotMapped]
        [Compare(otherProperty: "New_Password")]
        public string Confirm_Password { get; set; }



        [Display(Name = "Old Password")]
        [Required(ErrorMessage = "Password Required")]
        [PasswordPropertyText]
        public string Old_Password { get; set; }
    }
}