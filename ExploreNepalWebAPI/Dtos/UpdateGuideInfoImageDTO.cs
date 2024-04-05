using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class UpdateGuideInfoImageDTO
    {
        [Required]
        public string GuideInfoCode { get; set; }

        [Required]
        public List<IFormFile> GuideInfoImageFiles { get; set; }
    }
}
