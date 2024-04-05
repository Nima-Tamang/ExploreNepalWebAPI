using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ImagesTesting.Models;

namespace IdentityFour.Models
{
    public class GuideInfoImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("guideinfocode")]
        public string GuideInfoCode { get; set; }

        [Required]
        [Column("guideinfoimage")]
        public byte[] GuideInfoImageBytes { get; set; }

        // Navigation property for the parent GuideInfo
        [ForeignKey("GuideInfoCode")]
        public GuideInfo GuideInfo { get; set; }
    }
}
