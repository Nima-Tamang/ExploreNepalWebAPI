


using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityFour.Models
{
    public class DestinationImage
    {
        [Key]
        public int Id { get; set; }

        [Column("destinationcode")]
        [StringLength(50)]
        [Unicode(false)]
        public string DestinationCode { get; set; }

        [Column("destinationimage")]
        public byte[] DestinationImageBytes { get; set; }  // Corrected property name

        // Navigation property for the parent Destination
        [ForeignKey("DestinationCode")]
        public Destination Destination { get; set; }
    }
}
