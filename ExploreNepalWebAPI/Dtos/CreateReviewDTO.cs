using System.ComponentModel.DataAnnotations;

public class CreateReviewDTO
{
    [Required]
    public string DestinationCode { get; set; }

    [Required]
    public string GuideInfoId { get; set; }

    [Required]
    [Range(1, 5)]
    public int Rating { get; set; }

    [Required]
    public string Detail { get; set; }

    [StringLength(50)]
    public string Season { get; set; }
}
