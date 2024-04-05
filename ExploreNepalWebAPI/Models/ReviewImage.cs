using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IdentityFour.Models; // Make sure to include the correct namespace for Review class

public class ReviewImage
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Review")]
    public int ReviewId { get; set; }  // Adjusted data type to match the primary key of the related Review entity

    [Column("reviewimages")]
    public byte[] ReviewImagesBytes { get; set; }  // Corrected property name

    // Navigation property for the parent Review
    public Review Review { get; set; }
}
