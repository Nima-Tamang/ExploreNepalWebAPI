//using IdentityFour.Data;
//using IdentityFour.Dtos;
//using IdentityFour.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IdentityFour.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReviewImageController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public ReviewImageController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // POST: api/reviewimage/MultiUpload
//        [HttpPost("MultiUpload")]
//        public async Task<IActionResult> UploadReviewImages(CreateReviewImageDTO createReviewImageDto)
//        {
//            try
//            {
//                // Validate DTO
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Check if ReviewId is provided
//                if (createReviewImageDto.ReviewId == 0)
//                {
//                    return BadRequest("Review Id is required.");
//                }

//                // Find the corresponding review using the provided ReviewId
//                var review = await _context.Reviews.FindAsync(createReviewImageDto.ReviewId);
//                if (review == null)
//                {
//                    return NotFound("Review not found.");
//                }

//                // Check if ReviewImagefile collection is provided and not empty
//                if (createReviewImageDto.ReviewImagefile == null || !createReviewImageDto.ReviewImagefile.Any())
//                {
//                    return BadRequest("At least one review image file is required.");
//                }

//                // Process each uploaded image
//                foreach (var file in createReviewImageDto.ReviewImagefile)
//                {
//                    // Check if file is valid
//                    if (file == null || file.Length == 0)
//                    {
//                        continue; // Skip if file is null or empty
//                    }

//                    using (var ms = new MemoryStream())
//                    {
//                        // Copy the image file to memory stream
//                        await file.CopyToAsync(ms);

//                        // Create a new ReviewImage entity and associate it with the review
//                        var reviewImage = new ReviewImage
//                        {
//                            ReviewId = createReviewImageDto.ReviewId,
//                            ReviewImagesBytes = ms.ToArray()
//                        };

//                        // Add the ReviewImage entity to the context
//                        _context.ReviewImages.Add(reviewImage);
//                    }
//                }

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new APIResponse
//                {
//                    ResponseCode = 200,
//                    Result = "Success",
//                    Message = "Review images uploaded successfully."
//                };

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new APIResponse
//                {
//                    ResponseCode = 500,
//                    Result = "Error",
//                    Message = ex.Message
//                };

//                return StatusCode(500, response);
//            }
//        }


//        // PUT: api/reviewimage/UpdateImages
//        [HttpPut("UpdateImages")]
//        public async Task<IActionResult> UpdateReviewImages(UpdateReviewImageDTO updateReviewImageDto)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Find the corresponding review using the provided ReviewImageId
//                var review = await _context.Reviews.FirstOrDefaultAsync(r => r.ReviewId == updateReviewImageDto.ReviewImageId);
//                if (review == null)
//                {
//                    return NotFound("Review not found.");
//                }

//                // Remove existing review images
//                var existingReviewImages = _context.ReviewImages.Where(ri => ri.ReviewId == updateReviewImageDto.ReviewImageId);
//                _context.ReviewImages.RemoveRange(existingReviewImages);

//                // Process each uploaded image
//                foreach (var file in updateReviewImageDto.ReviewImagefile)
//                {
//                    // Check if file is valid
//                    if (file == null || file.Length == 0)
//                    {
//                        continue; // Skip if file is null or empty
//                    }

//                    using (var ms = new MemoryStream())
//                    {
//                        // Copy the image file to memory stream
//                        await file.CopyToAsync(ms);

//                        // Create a new ReviewImage entity and associate it with the review
//                        var reviewImage = new ReviewImage
//                        {
//                            ReviewId = updateReviewImageDto.ReviewImageId,
//                            ReviewImagesBytes = ms.ToArray()
//                        };

//                        // Add the ReviewImage entity to the context
//                        _context.ReviewImages.Add(reviewImage);
//                    }
//                }

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new APIResponse
//                {
//                    ResponseCode = 200,
//                    Result = "Success",
//                    Message = "Review images updated successfully."
//                };

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new APIResponse
//                {
//                    ResponseCode = 500,
//                    Result = "Error",
//                    Message = ex.Message
//                };

//                return StatusCode(500, response);
//            }
//        }




//        // GET: api/reviewimage/{reviewId}
//        [HttpGet("{reviewId}")]
//        public async Task<IActionResult> GetReviewImageById(int reviewId)
//        {
//            try
//            {
//                var reviewImages = await _context.ReviewImages.Where(ri => ri.ReviewId == reviewId).ToListAsync();
//                return Ok(reviewImages);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = ex.Message });
//            }
//        }

//        // Define other action methods here if needed
//        // DELETE: api/reviewimage/Delete/{id}
//        [HttpDelete("Delete/{id}")]
//        public async Task<IActionResult> DeleteReviewImage(int id)
//        {
//            try
//            {
//                var reviewImage = await _context.ReviewImages.FindAsync(id);
//                if (reviewImage == null)
//                {
//                    return NotFound(new APIResponse { ResponseCode = 404, Result = "Error", Message = "Review image not found." });
//                }

//                _context.ReviewImages.Remove(reviewImage);
//                await _context.SaveChangesAsync();

//                return Ok(new APIResponse { ResponseCode = 200, Result = "Success", Message = "Review image deleted successfully." });
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = ex.Message });
//            }
//        }

//        // GET: api/reviewimage/GetAll
//        [HttpGet("GetAll")]
//        public async Task<IActionResult> GetAllReviewImages()
//        {
//            try
//            {
//                var reviewImages = await _context.ReviewImages.ToListAsync();
//                return Ok(reviewImages);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = ex.Message });
//            }
//        }

        

//    }
//}
