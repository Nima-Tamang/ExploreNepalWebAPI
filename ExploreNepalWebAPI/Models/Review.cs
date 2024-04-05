using IdentityFour.Models;
using ImagesTesting.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Review
{
    [Key]
    public int ReviewId { get; set; }

   


    [Required]
    [ForeignKey("Destination")]
    public string DestinationCode { get; set; }  // Adjusted data type to string

    [Required]
    [ForeignKey("GuideInfo")]
    public string GuideInfoId { get; set; }

    [Range(1, 5)] // Assuming rating is on a scale of 1 to 5
    public int Rating { get; set; }

    [Required]
    public string Detail { get; set; }

    [StringLength(50)] // Adjust max length as needed
    public string Season { get; set; }

    // Navigation properties for related entities
    public virtual Destination Destination { get; set; }
    public virtual GuideInfo GuideInfo { get; set; }

    // Assuming ReviewImage is another entity
    public ICollection<ReviewImage> ReviewImages { get; set; }




    // Foreign key property
    public int UserInfoId { get; set; }

    // Navigation property for the related UserInfo
    [ForeignKey("UserInfoId")]
    public virtual UserInfo UserInfo { get; set; }

}
