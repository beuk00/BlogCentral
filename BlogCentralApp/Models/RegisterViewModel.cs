using System.ComponentModel.DataAnnotations;

namespace BlogCentralApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please provide your first name!")]
        [Display(Name = "First name*")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please provide your last name!")]
        [Display(Name = "Last name*")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please provide your public username!")]
        [Display( Name = "User name*")]
        public string UserName { get; set; }


        [Display(Name = "Street")]
        public string StreetName { get; set; }


        [Display(Name = "N°")]
        public int? HouseNumber { get; set; }


        [Display(Name = "City")]
        public string CityName { get; set; }


        [Display(Name = "ZIP")]
        public int? ZIP { get; set; }


        [Required(ErrorMessage = "Please enter an email address!")]
        [Display(Name = "Email address*")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Please enter a password!")]
        [Display(Name = "Password*")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please enter a password!")]
        [Display(Name = "Confirm Password*")]
        public string PasswordConfirmation { get; set; }
    }
}
