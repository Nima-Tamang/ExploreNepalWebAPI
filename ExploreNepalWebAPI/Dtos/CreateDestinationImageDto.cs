using Microsoft.AspNetCore.Http;

namespace IdentityFour.Dtos
{
    public class CreateDestinationImageDto
    {
        public string DestinationCode { get; set; } // Destination code to associate the images
        public ICollection<IFormFile> DestinationImageFiles { get; set; } // Collection of image files
    }
}
