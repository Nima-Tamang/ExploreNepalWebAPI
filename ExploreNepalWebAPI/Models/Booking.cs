using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImagesTesting.Models
{
    public class Booking
    {
        [Key]
        public  int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string SelectedSeason { get; set; }

        [Required]
        public string SortBy { get; set; }

        [Required]
        public decimal Price { get; set; }


        //public static implicit operator string(Booking v)
        //{
        //    throw new NotImplementedException();
        //}
        // public PaymentDTO PaymentDetails { get; set; }


        // Foreign key property
        public int UserInfoId { get; set; }

        // Navigation property for the related UserInfo
        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }
    }
}
