
using System.ComponentModel.DataAnnotations;

namespace FranksKaffeehaus.Models

{
    public class RegistrationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Please a valid email address.")]
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Display(Name = "Lactose Intolerant?")]
        public bool LactoseIntolerant { get; set; }

        [Display(Name = "Time Zone")]
        public string TimeZone { get; set; }

        [Display(Name = "Phone Number (xxx-xxx-xxxx)")]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", ErrorMessage = "Please a valid phone number.")]
        public string PhoneNumber { get; set; }
    }
}
