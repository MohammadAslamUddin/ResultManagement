using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    public class LogInfo
    {
        [Key]
        public int Id { get; set; }



        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [Required]
        [Display(Name = "Password")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
