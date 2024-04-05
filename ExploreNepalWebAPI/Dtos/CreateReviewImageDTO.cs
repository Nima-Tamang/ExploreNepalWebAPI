using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class CreateReviewImageDTO
    {
        [Required]
        public int ReviewId { get; set; }  // Assuming ReviewId is used to associate the review with the image

        [Required]
        public ICollection<IFormFile> ReviewImagefile { get; set; }
    }
}
