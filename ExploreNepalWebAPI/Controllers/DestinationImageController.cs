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
//    public class DestinationImageController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public DestinationImageController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/DestinationImage/All
//        [HttpGet("All")]
//        public async Task<IActionResult> GetAllDestinationImages()
//        {
//            try
//            {
//                // Retrieve all destination images
//                var destinationImages = await _context.DestinationImages.ToListAsync();

//                // Check if any images found
//                if (destinationImages.Count == 0)
//                {
//                    return NotFound("No destination images found.");
//                }

//                // Create a list to store image byte arrays
//                var imageBytesList = new List<byte[]>();

//                // Add image byte arrays to the list
//                foreach (var destinationImage in destinationImages)
//                {
//                    imageBytesList.Add(destinationImage.DestinationImageBytes);
//                }

//                return Ok(imageBytesList);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };

//                return StatusCode((int)response.StatusCode, response);
//            }
//        }

//        // GET: api/DestinationImage/{destinationCode}
//        [HttpGet("{destinationCode}")]
//        public async Task<IActionResult> GetDestinationImages(string destinationCode)
//        {
//            try
//            {
//                // Find the corresponding destination using the provided code
//                var destination = await _context.Destinations.FindAsync(destinationCode);
//                if (destination == null)
//                {
//                    return NotFound("Destination not found.");
//                }

//                // Retrieve destination images associated with the destination code
//                var destinationImages = await _context.DestinationImages
//                    .Where(di => di.DestinationCode == destinationCode)
//                    .ToListAsync();

//                // Check if any images found
//                if (destinationImages.Count == 0)
//                {
//                    return NotFound("No destination images found.");
//                }

//                // Create a list to store image byte arrays
//                var imageBytesList = new List<byte[]>();

//                // Add image byte arrays to the list
//                foreach (var destinationImage in destinationImages)
//                {
//                    imageBytesList.Add(destinationImage.DestinationImageBytes);
//                }

//                return Ok(imageBytesList);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };

//                return StatusCode((int)response.StatusCode, response);
//            }
//        }

//        // POST: api/DestinationImage/MultiUpload
//        [HttpPost("MultiUpload")]
//        public async Task<IActionResult> MultiUploadDestinationImages(CreateDestinationImageDto createDestinationImageDto)
//        {
//            try
//            {
//                // Check if DTO is valid
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Check if DestinationCode is provided
//                if (string.IsNullOrEmpty(createDestinationImageDto.DestinationCode))
//                {
//                    return BadRequest("Destination code is required.");
//                }

//                // Check if DestinationImageFiles collection is provided and not empty
//                if (createDestinationImageDto.DestinationImageFiles == null || !createDestinationImageDto.DestinationImageFiles.Any())
//                {
//                    return BadRequest("At least one destination image file is required.");
//                }

//                // Find the corresponding destination using the provided code
//                var destination = await _context.Destinations.FindAsync(createDestinationImageDto.DestinationCode);
//                if (destination == null)
//                {
//                    return NotFound("Destination not found.");
//                }

//                // Process each uploaded image
//                foreach (var file in createDestinationImageDto.DestinationImageFiles)
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

//                        // Create a new DestinationImage entity and associate it with the destination
//                        var destinationImage = new DestinationImage
//                        {
//                            DestinationCode = createDestinationImageDto.DestinationCode,
//                            DestinationImageBytes = ms.ToArray()
//                        };

//                        // Add the DestinationImage entity to the context
//                        _context.DestinationImages.Add(destinationImage);
//                    }
//                }

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.OK,
//                    IsSuccess = true,
//                    Result = "Success",
//                    ErrorMessages = new List<string>(),
//                };

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };

//                return StatusCode((int)response.StatusCode, response);
//            }
//        }

//        // PUT: api/DestinationImage/UpdateImages
//        [HttpPut("UpdateImages")]
//        public async Task<IActionResult> UpdateDestinationImages(UpdateDestinationImagesDTO updateDestinationImagesDto)
//        {
//            try
//            {
//                // Check if DTO is valid
//                if (!ModelState.IsValid)
//                {
//                    return BadRequest(ModelState);
//                }

//                // Find the corresponding destination using the provided code
//                var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == updateDestinationImagesDto.DestinationCode);
//                if (destination == null)
//                {
//                    return NotFound("Destination not found.");
//                }

//                // Remove existing destination images
//                var existingImages = _context.DestinationImages.Where(di => di.DestinationCode == updateDestinationImagesDto.DestinationCode);
//                _context.DestinationImages.RemoveRange(existingImages);

//                // Process each uploaded image
//                foreach (var file in updateDestinationImagesDto.DestinationImageFiles)
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

//                        // Create a new DestinationImage entity and associate it with the destination
//                        var destinationImage = new DestinationImage
//                        {
//                            DestinationCode = updateDestinationImagesDto.DestinationCode,
//                            DestinationImageBytes = ms.ToArray()
//                        };

//                        // Add the DestinationImage entity to the context
//                        _context.DestinationImages.Add(destinationImage);
//                    }
//                }

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.OK,
//                    IsSuccess = true,
//                    Result = "Success",
//                    ErrorMessages = new List<string>(),
//                };

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };

//                return StatusCode((int)response.StatusCode, response);
//            }
//        }

//        // DELETE: api/DestinationImage/DeleteByDestinationCode/{destinationCode}
//        [HttpDelete("DeleteByDestinationCode/{destinationCode}")]
//        public async Task<IActionResult> DeleteByDestinationCode(string destinationCode)
//        {
//            try
//            {
//                // Find destination images associated with the provided destination code
//                var destinationImages = _context.DestinationImages
//                    .Where(di => di.DestinationCode == destinationCode)
//                    .ToList();

//                // Check if any images found
//                if (destinationImages.Count == 0)
//                {
//                    return NotFound("No destination images found for the provided destination code.");
//                }

//                // Remove destination images from the context
//                _context.DestinationImages.RemoveRange(destinationImages);

//                // Save changes to the database
//                await _context.SaveChangesAsync();

//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.OK,
//                    IsSuccess = true,
//                    Result = "Success",
//                    ErrorMessages = new List<string>(),
//                };

//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };

//                return StatusCode((int)response.StatusCode, response);
//            }
//        }
//    }
//}




using IdentityFour.Data;
using IdentityFour.Dtos;
using IdentityFour.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityFour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationImageController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private ApiResponse _response;

        public DestinationImageController(ApplicationDBContext context)
        {
            _context = context;
        }


        // GET: api/DestinationImage/All
        [HttpGet("All")]
        public async Task<IActionResult> GetAllDestinationImages()
        {
            try
            {
                // Retrieve all destination images
                var destinationImages = await _context.DestinationImages.ToListAsync();

                // Check if any images found
                if (destinationImages.Count == 0)
                {
                    return NotFound("No destination images found.");
                }

                // Create a list to store image byte arrays
                var imageBytesList = new List<byte[]>();

                // Add image byte arrays to the list
                foreach (var destinationImage in destinationImages)
                {
                    imageBytesList.Add(destinationImage.DestinationImageBytes);
                }

                return Ok(imageBytesList);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return StatusCode((int)response.StatusCode, response);
            }
        }


        // GET: api/DestinationImage/{destinationCode}
        [HttpGet("{destinationCode}")]
        public async Task<IActionResult> GetDestinationImages(string destinationCode)
        {
            try
            {
                // Find the corresponding destination using the provided code
                var destination = await _context.Destinations.FindAsync(destinationCode);
                if (destination == null)
                {
                    return NotFound("Destination not found.");
                }

                // Retrieve destination images associated with the destination code
                var destinationImages = await _context.DestinationImages
                    .Where(di => di.DestinationCode == destinationCode)
                    .ToListAsync();

                // Check if any images found
                if (destinationImages.Count == 0)
                {
                    return NotFound("No destination images found.");
                }

                // Create a list to store image byte arrays
                var imageBytesList = new List<byte[]>();

                // Add image byte arrays to the list
                foreach (var destinationImage in destinationImages)
                {
                    imageBytesList.Add(destinationImage.DestinationImageBytes);
                }

                return Ok(imageBytesList);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return StatusCode((int)response.StatusCode, response);
            }
        }


        // POST: api/DestinationImage/MultiUpload
        [HttpPost("MultiUpload")]
        public async Task<IActionResult> MultiUploadDestinationImages(CreateDestinationImageDto createDestinationImageDto)
        {
            try
            {
                // Check if DTO is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Check if DestinationCode is provided
                if (string.IsNullOrEmpty(createDestinationImageDto.DestinationCode))
                {
                    return BadRequest("Destination code is required.");
                }

                // Check if DestinationImageFiles collection is provided and not empty
                if (createDestinationImageDto.DestinationImageFiles == null || !createDestinationImageDto.DestinationImageFiles.Any())
                {
                    return BadRequest("At least one destination image file is required.");
                }

                // Find the corresponding destination using the provided code
                var destination = await _context.Destinations.FindAsync(createDestinationImageDto.DestinationCode);
                if (destination == null)
                {
                    return NotFound("Destination not found.");
                }

                // Process each uploaded image
                foreach (var file in createDestinationImageDto.DestinationImageFiles)
                {
                    // Check if file is valid
                    if (file == null || file.Length == 0)
                    {
                        continue; // Skip if file is null or empty
                    }

                    using (var ms = new MemoryStream())
                    {
                        // Copy the image file to memory stream
                        await file.CopyToAsync(ms);

                        // Create a new DestinationImage entity and associate it with the destination
                        var destinationImage = new DestinationImage
                        {
                            DestinationCode = createDestinationImageDto.DestinationCode,
                            DestinationImageBytes = ms.ToArray()
                        };

                        // Add the DestinationImage entity to the context
                        _context.DestinationImages.Add(destinationImage);
                    }
                }

                // Save changes to the database
                await _context.SaveChangesAsync();

                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>(),

                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return StatusCode((int)response.StatusCode, response);
            }
        }



        [HttpPut("UpdateImages")]
        public async Task<IActionResult> UpdateDestinationImages(UpdateDestinationImagesDTO updateDestinationImagesDto)
        {
            try
            {
                // Check if DTO is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Find the corresponding destination using the provided code
                var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == updateDestinationImagesDto.DestinationCode);
                if (destination == null)
                {
                    return NotFound("Destination not found.");
                }

                // Remove existing destination images
                var existingImages = _context.DestinationImages.Where(di => di.DestinationCode == updateDestinationImagesDto.DestinationCode);
                _context.DestinationImages.RemoveRange(existingImages);

                // Process each uploaded image
                foreach (var file in updateDestinationImagesDto.DestinationImageFiles)
                {
                    // Check if file is valid
                    if (file == null || file.Length == 0)
                    {
                        continue; // Skip if file is null or empty
                    }

                    using (var ms = new MemoryStream())
                    {
                        // Copy the image file to memory stream
                        await file.CopyToAsync(ms);

                        // Create a new DestinationImage entity and associate it with the destination
                        var destinationImage = new DestinationImage
                        {
                            DestinationCode = updateDestinationImagesDto.DestinationCode,
                            DestinationImageBytes = ms.ToArray()
                        };

                        // Add the DestinationImage entity to the context
                        _context.DestinationImages.Add(destinationImage);
                    }
                }

                // Save changes to the database
                await _context.SaveChangesAsync();


                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>(),

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return StatusCode((int)response.StatusCode, response);
            }
        }





        // DELETE: api/DestinationImage/DeleteByDestinationCode/{destinationCode}
        [HttpDelete("DeleteByDestinationCode/{destinationCode}")]
        public async Task<IActionResult> DeleteByDestinationCode(string destinationCode)
        {
            try
            {
                // Find destination images associated with the provided destination code
                var destinationImages = _context.DestinationImages
                    .Where(di => di.DestinationCode == destinationCode)
                    .ToList();

                // Check if any images found
                if (destinationImages.Count == 0)
                {
                    return NotFound("No destination images found for the provided destination code.");
                }

                // Remove destination images from the context
                _context.DestinationImages.RemoveRange(destinationImages);

                // Save changes to the database
                await _context.SaveChangesAsync();


                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>(),

                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ApiResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };

                return StatusCode((int)response.StatusCode, response);
            }
        }

    }
}