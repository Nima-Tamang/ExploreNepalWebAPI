using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class UpdateDestinationImagesDTO
    {
        [Required]
        public string DestinationCode { get; set; } // Destination code to identify the images

        [Required]
        public List<IFormFile> DestinationImageFiles { get; set; } // Collection of new image files
    }
}
