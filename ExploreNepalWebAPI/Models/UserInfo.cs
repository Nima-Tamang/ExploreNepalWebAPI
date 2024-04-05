using System.ComponentModel.DataAnnotations;

namespace ImagesTesting.Models
{
    public class UserInfo
    {

        [Key]
        public int UserId { get; set; }
        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        public string AdditionalText { get; set; }

        

        // Navigation property for the one-to-many relationship
        public virtual ICollection<Booking> Bookings { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }
    }
}