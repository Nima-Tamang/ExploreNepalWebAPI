using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class RegisterDto
    {
        //[Required]
        //public string? Username { get; set; }
        //[Required]
        //[EmailAddress]
        //public string? Email { get; set; }
        //[Required]
        //public string? Password { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(6)]
        public string? Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Location { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string? PhoneNumber { get; set; }




    }
}
