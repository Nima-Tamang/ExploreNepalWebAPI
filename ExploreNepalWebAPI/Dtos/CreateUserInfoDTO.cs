
using System.ComponentModel.DataAnnotations;

namespace ImagesTesting.Models.Dtos
{
    public class CreateUserInfoDTO
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        
       

        [Required]
        public string Location { get; set; }

        public string AdditionalText { get; set; }
    }
}