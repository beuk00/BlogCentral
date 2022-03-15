using System.ComponentModel.DataAnnotations;

namespace BlogCentralApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please provide your username!")]
        [Display(Name = "User name")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Please provide your password!")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
