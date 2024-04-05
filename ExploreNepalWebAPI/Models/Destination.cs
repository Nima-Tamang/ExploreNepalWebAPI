using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityFour.Models
{
    public class Destination
    {
        [Key]
        [Column("code")]
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; } = null!;

        [Required]
        [Column("DurationInDays")]
        public int DurationInDays { get; set; }

        [Required]
        [Column("Difficulty")]
        public string Difficulty { get; set; }

        [Required]
        [Column("FeePerPersonNepalMin", TypeName = "decimal(18, 2)")]
        public decimal? FeePerPersonNepaliMin { get; set; }

        [Required]
        [Column("FeePerPersonNepaliMax", TypeName = "decimal(18, 2)")]
        public decimal? FeePerPersonNepaliMax { get; set; }

        [Required]
        [Column("FeePerPersonForeignMin", TypeName = "decimal(18, 2)")]
        public decimal? FeePerPersonForeignMin { get; set; }

        [Required]
        [Column("FeePerPersonForeignMax", TypeName = "decimal(18, 2)")]
        public double FeePerPersonForeignMax { get; set; }

        [Required]
        [Column("MaxAltitude")]
        public long? MaxAltitude { get; set; }

        [Required]
        [Column("Overview")]
        public string? Overview { get; set; }


        [Required]
        [Column("Why")]
        public string? Why { get; set; }

        [Required]
        [Column("LocationName")]
        public string? LocationName { get; set; }

        [Required]
        [Column("Location")]
        public string? Location { get; set; }



        // Navigation property for related DestinationImages

        public ICollection<DestinationImage> DestinationImages { get; set; }
    }
}
