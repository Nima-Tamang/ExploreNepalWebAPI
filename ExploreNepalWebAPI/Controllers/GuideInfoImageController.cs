//using IdentityFour.Data;
//using IdentityFour.Dtos;
//using IdentityFour.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IdentityFour.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GuideInfoImageController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public GuideInfoImageController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/GuideInfoImage/All
//        [HttpGet("All")]
//        public async Task<IActionResult> GetAllGuideInfoImages()
//        {
//            try
//            {
//                var guideInfoImages = await _context.GuideInfoImages.ToListAsync();

//                if (guideInfoImages.Count == 0)
//                {
//                    return NotFound("No guide info images found.");
//                }

//                var imageBytesList = new List<byte[]>();

//                foreach (var guideInfoImage in guideInfoImages)
//                {
//                    imageBytesList.Add(guideInfoImage.GuideInfoImageBytes);
//                }

//                return Ok(imageBytesList);
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

//        // GET: api/GuideInfoImage/{guideInfoCode}
//        [HttpGet("{guideInfoCode}")]
//        public async Task<IActionResult> GetGuideInfoImages(string guideInfoCode)
//        {
//            try
//            {
//                var guideInfo = await _context.GuideInfos.FindAsync(guideInfoCode);
//                if (guideInfo == null)
//                {
//                    return NotFound("Guide info not found.");
//                }

//                var guideInfoImages = await _context.GuideInfoImages
//                    .Where(gi => gi.GuideInfoCode == guideInfoCode)
//                    .ToListAsync();

//                if (guideInfoImages.Count == 0)
//                {
//                    return NotFound("No guide info images found.");
//                }

//                var imageBytesList = new List<byte[]>();

//                foreach (var guideInfoImage in guideInfoImages)
//                {
//                    imageBytesList.Add(guideInfoImage.GuideInfoImageBytes);
//                }

//                return Ok(imageBytesList);
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

//        // POST: api/GuideInfoImage/MultiUpload
//        [HttpPost("MultiUpload")]
//        public async Task<IActionResult> MultiUploadGuideInfoImages([FromForm] CreateGuideInfoImageDTO createGuideInfoImageDto)
//        {
//            try
//            {
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                if (string.IsNullOrEmpty(createGuideInfoImageDto.GuideInfoCode))
//                {
//                    return BadRequest("Guide info code is required.");
//                }

//                if (createGuideInfoImageDto.GuideInfoImageFiles == null || !createGuideInfoImageDto.GuideInfoImageFiles.Any())
//                {
//                    return BadRequest("At least one guide info image file is required.");
//                }

//                var guideInfo = await _context.GuideInfos.FindAsync(createGuideInfoImageDto.GuideInfoCode);
//                if (guideInfo == null)
//                {
//                    return NotFound("Guide info not found.");
//                }

//                foreach (var file in createGuideInfoImageDto.GuideInfoImageFiles)
//                {
//                    if (file == null || file.Length == 0)
//                    {
//                        continue;
//                    }

//                    using (var ms = new MemoryStream())
//                    {
//                        await file.CopyToAsync(ms);

//                        var guideInfoImage = new GuideInfoImage
//                        {
//                            GuideInfoCode = createGuideInfoImageDto.GuideInfoCode,
//                            GuideInfoImageBytes = ms.ToArray()
//                        };

//                        _context.GuideInfoImages.Add(guideInfoImage);
//                    }
//                }

//                await _context.SaveChangesAsync();

//                var response = new APIResponse
//                {
//                    ResponseCode = 200,
//                    Result = "Success",
//                    Message = "Guide info images uploaded successfully."
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



//        [HttpPut("UpdateImages")]
//        public async Task<IActionResult> UpdateGuideInfoImages([FromForm]UpdateGuideInfoImageDTO updateGuideInfoImageDto)
//        {
//            try
//            {
//                // Check if DTO is valid
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Find the corresponding guide info using the provided code
//                var guideInfo = await _context.GuideInfos.FirstOrDefaultAsync(g => g.Code == updateGuideInfoImageDto.GuideInfoCode);
//                if (guideInfo == null)
//                {
//                    return NotFound("Guide info not found.");
//                }

//                // Remove existing guide info images
//                var existingImages = _context.GuideInfoImages.Where(gi => gi.GuideInfoCode == updateGuideInfoImageDto.GuideInfoCode);
//                _context.GuideInfoImages.RemoveRange(existingImages);

//                // Process each uploaded image
//                foreach (var file in updateGuideInfoImageDto.GuideInfoImageFiles)
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

//                        // Create a new GuideInfoImage entity and associate it with the guide info
//                        var guideInfoImage = new GuideInfoImage
//                        {
//                            GuideInfoCode = updateGuideInfoImageDto.GuideInfoCode,
//                            GuideInfoImageBytes = ms.ToArray()
//                        };

//                        // Add the GuideInfoImage entity to the context
//                        _context.GuideInfoImages.Add(guideInfoImage);
//                    }
//                }

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new APIResponse
//                {
//                    ResponseCode = 200,
//                    Result = "Success",
//                    Message = "Guide info images updated successfully."
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


//        // DELETE: api/GuideInfoImage/DeleteByGuideInfoCode/{guideInfoCode}
//        [HttpDelete("DeleteByGuideInfoCode/{guideInfoCode}")]
//        public async Task<IActionResult> DeleteByGuideInfoCode(string guideInfoCode)
//        {
//            try
//            {
//                var guideInfoImages = _context.GuideInfoImages
//                    .Where(gi => gi.GuideInfoCode == guideInfoCode)
//                    .ToList();

//                if (guideInfoImages.Count == 0)
//                {
//                    return NotFound("No guide info images found for the provided guide info code.");
//                }

//                _context.GuideInfoImages.RemoveRange(guideInfoImages);

//                await _context.SaveChangesAsync();

//                var response = new APIResponse
//                {
//                    ResponseCode = 200,
//                    Result = "Success",
//                    Message = "Guide info images deleted successfully."
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
//    }
//}
