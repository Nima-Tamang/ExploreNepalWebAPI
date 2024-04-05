using System.ComponentModel.DataAnnotations;

namespace IdentityFour.Dtos
{
    public class UpdateDestinationDTO
    {
        //[Required]
        //public string Code { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [Required]
        public string Difficulty { get; set; }

        [Required]
        public decimal? FeePerPersonNepaliMin { get; set; }

        [Required]
        public decimal? FeePerPersonNepaliMax { get; set; }

        [Required]
        public decimal? FeePerPersonForeignMin { get; set; }

        [Required]
        public double FeePerPersonForeignMax { get; set; }

        [Required]
        public long? MaxAltitude { get; set; }

        [Required]
        public string Overview { get; set; }

        [Required]

        public string? Why { get; set; }

        [Required]

        public string? LocationName { get; set; }

        [Required]

        public string? Location { get; set; }
    }
}
