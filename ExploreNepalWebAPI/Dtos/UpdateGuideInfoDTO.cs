using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class UpdateGuideInfoDTO
    {
        //[Required]
        //public string Code { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Experience is required")]
        public string Experience { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "At least one completed trek is required")]
        public List<string> CompletedTreks { get; set; }

        [Required(ErrorMessage = "At least one service offered is required")]
        public List<string> ServicesOffered { get; set; }

        [Required(ErrorMessage = "Why Choose is required")]
        public string WhyChoose { get; set; }

        [Required(ErrorMessage = "Booking Info is required")]
        public string BookingInfo { get; set; }
    }
}
