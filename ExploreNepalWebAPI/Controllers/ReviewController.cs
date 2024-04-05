//using IdentityFour.Models;
//using IdentityFour.Dtos;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using IdentityFour.Data;

//namespace IdentityFour.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ReviewsController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public ReviewsController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Reviews
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
//        {
//            try
//            {
//                var reviews = await _context.Reviews.ToListAsync();
//                return Ok(reviews);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while retrieving reviews: {ex.Message}");
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = "Internal server error" });
//            }
//        }

//        // GET: api/Reviews/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Review>> GetReview(int id)
//        {
//            try
//            {
//                var review = await _context.Reviews.FindAsync(id);
//                if (review == null)
//                {
//                    return NotFound();
//                }
//                return Ok(review);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while retrieving review {id}: {ex.Message}");
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = "Internal server error" });
//            }
//        }

//        // PUT: api/Reviews/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutReview(int id,[FromForm] UpdateReviewDTO updateReviewDTO)
//        {
//            try
//            {
//                var review = await _context.Reviews.FindAsync(id);
//                if (review == null)
//                {
//                    return NotFound();
//                }

//                review.Rating = updateReviewDTO.Rating;
//                review.Detail = updateReviewDTO.Detail;
//                review.Season = updateReviewDTO.Season;

//                await _context.SaveChangesAsync();

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while updating review {id}: {ex.Message}");
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = "Internal server error" });
//            }
//        }

//        // POST: api/Reviews
//        [HttpPost]
//        public async Task<ActionResult<Review>> PostReview([FromForm] CreateReviewDTO createReviewDTO)
//        {
//            try
//            {
//                var review = new Review
//                {
//                    DestinationCode = createReviewDTO.DestinationCode,
//                    GuideInfoId = createReviewDTO.GuideInfoId,
//                    Rating = createReviewDTO.Rating,
//                    Detail = createReviewDTO.Detail,
//                    Season = createReviewDTO.Season
//                };

//                _context.Reviews.Add(review);
//                await _context.SaveChangesAsync();

//                return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while creating review: {ex.Message}");
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = "Internal server error" });
//            }
//        }

//        // DELETE: api/Reviews/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteReview(int id)
//        {
//            try
//            {
//                var review = await _context.Reviews.FindAsync(id);
//                if (review == null)
//                {
//                    return NotFound();
//                }

//                _context.Reviews.Remove(review);
//                await _context.SaveChangesAsync();

//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"An error occurred while deleting review {id}: {ex.Message}");
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = "Internal server error" });
//            }
//        }
//    }
//}
