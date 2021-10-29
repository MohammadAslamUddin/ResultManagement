using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ResultManagement.Models
{
    public class LogInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }

        [PasswordPropertyText]
        public string Password { get; set; }

        [Display(Name = "LogIn As")]
        public int type { get; set; }
    }
}
