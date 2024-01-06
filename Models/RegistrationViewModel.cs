
using System.ComponentModel.DataAnnotations;

namespace FranksKaffeehaus.Models

{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }
}
