using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class UpdateReviewImageDTO
    {
        [Required]
        public int ReviewImageId { get; set; } // Identifies the review image to update

        [Required]
        public ICollection<IFormFile> ReviewImagefile { get; set; }
    }
}
