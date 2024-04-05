//using IdentityFour.Data;
//using IdentityFour.Dtos;
//using IdentityFour.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace IdentityFour.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DestinationController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public DestinationController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/destination
//        [HttpGet]
//        public async Task<IActionResult> GetDestinations()
//        {
//            try
//            {
//                var destinations = await _context.Destinations.ToListAsync();
//                var response = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.OK,
//                    IsSuccess = true,
//                    Result = destinations
//                };
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                var response = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };
//                return StatusCode((int)response.StatusCode, response);
//            }
//        }

//        // GET: api/destination/{code}
//        [HttpGet("{code}")]
//        public async Task<IActionResult> GetDestinationByCode(string code)
//        {
//            try
//            {
//                var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == code);
//                if (destination == null)
//                {
//                    var notFoundResponse = new ApiResponse
//                    {
//                        StatusCode = HttpStatusCode.NotFound,
//                        IsSuccess = false,
//                        ErrorMessages = new List<string> { "Destination not found." }
//                    };
//                    return NotFound(notFoundResponse);
//                }

//                var successResponse = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.OK,
//                    IsSuccess = true,
//                    Result = destination
//                };
//                return Ok(successResponse);
//            }
//            catch (Exception ex)
//            {
//                var errorResponse = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };
//                return StatusCode((int)errorResponse.StatusCode, errorResponse);
//            }
//        }



//        This is for get product controller with images
//         GET: api/destination
//        [HttpGet]
//        public async Task<IActionResult> destination()
//        {
//            try
//            {
//                var destinationsWithImages = await _context.Destinations
//                    .Include(d => d.DestinationImages)
//                    .ToListAsync();

//                return Ok(destinationsWithImages);
//            }
//            catch (Exception ex)
//            {
//                var errorResponse = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.InternalServerError,
//                    IsSuccess = false,
//                    ErrorMessages = new List<string> { ex.Message }
//                };
//                return StatusCode((int)errorResponse.StatusCode, errorResponse);
//            }
//        }

//        GET: api/destination/{code
//    }
//    [HttpGet("{code}")]
//    public async Task<IActionResult> DestinationByCode(string code)
//    {
//        try
//        {
//            var destination = await _context.Destinations
//                .Include(d => d.DestinationImages)
//                .FirstOrDefaultAsync(d => d.Code == code);

//            if (destination == null)
//            {
//                return NotFound("Destination not found.");
//            }

//            return Ok(destination);
//        }
//        catch (Exception ex)
//        {
//            var errorResponse = new ApiResponse
//            {
//                StatusCode = HttpStatusCode.InternalServerError,
//                IsSuccess = false,
//                ErrorMessages = new List<string> { ex.Message }
//            };
//            return StatusCode((int)errorResponse.StatusCode, errorResponse);
//        }
//    }


//    POST: api/Destination
//   [HttpPost]
//        public async Task<IActionResult> CreateDestination([FromForm] CreateDestinationDTO createDestinationDto)
//    {
//        try
//        {
//            if (!ModelState.IsValid)
//            {
//                var validationErrorResponse = new ApiResponse
//                {
//                    StatusCode = HttpStatusCode.BadRequest,
//                    IsSuccess = false,
//                    ErrorMessages = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)).ToList()
//                };

//                return StatusCode((int)validationErrorResponse.StatusCode, validationErrorResponse);
//            }

//            var newDestination = new Destination
//            {
//                Code = createDestinationDto.Code,
//                DurationInDays = createDestinationDto.DurationInDays,
//                Difficulty = createDestinationDto.Difficulty,
//                FeePerPersonNepaliMin = createDestinationDto.FeePerPersonNepaliMin,
//                FeePerPersonNepaliMax = createDestinationDto.FeePerPersonNepaliMax,
//                FeePerPersonForeignMin = createDestinationDto.FeePerPersonForeignMin,
//                FeePerPersonForeignMax = createDestinationDto.FeePerPersonForeignMax,
//                MaxAltitude = createDestinationDto.MaxAltitude,
//                Overview = createDestinationDto.Overview
//            };

//            _context.Destinations.Add(newDestination);
//            await _context.SaveChangesAsync();

//            var successResponse = new ApiResponse
//            {
//                StatusCode = HttpStatusCode.Created,
//                IsSuccess = true,
//                Result = newDestination
//            };

//            return CreatedAtAction(nameof(DestinationByCode), new { code = newDestination.Code }, successResponse);
//        }
//        catch (Exception ex)
//        {
//            var errorResponse = new ApiResponse
//            {
//                StatusCode = HttpStatusCode.InternalServerError,
//                IsSuccess = false,
//                ErrorMessages = new List<string> { ex.Message }
//            };

//            return StatusCode((int)errorResponse.StatusCode, errorResponse);
//        }
//    }

//    private IActionResult StatusCode(int statusCode, ApiResponse response)
//    {
//        return StatusCode(statusCode, response);
//    }

//    private IActionResult CreatedAtAction(string actionName, object routeValues, ApiResponse response)
//    {
//        return CreatedAtAction(actionName, routeValues, response);
//    }

//    PUT: api/destination/{code
//}
//[HttpPut("{code}")]
//public async Task<IActionResult> UpdateDestination(string code, [FromForm] UpdateDestinationDTO updateDestinationDto)
//{
//    try
//    {
//        var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == code);
//        if (destination == null)
//        {
//            var notFoundResponse = new ApiResponse
//            {
//                StatusCode = HttpStatusCode.NotFound,
//                IsSuccess = false,
//                ErrorMessages = new List<string> { "Destination not found." }
//            };
//            return NotFound(notFoundResponse);
//        }

//        destination.DurationInDays = updateDestinationDto.DurationInDays;
//        destination.Difficulty = updateDestinationDto.Difficulty;
//        destination.FeePerPersonNepaliMin = updateDestinationDto.FeePerPersonNepaliMin;
//        destination.FeePerPersonNepaliMax = updateDestinationDto.FeePerPersonNepaliMax;
//        destination.FeePerPersonForeignMin = updateDestinationDto.FeePerPersonForeignMin;
//        destination.FeePerPersonForeignMax = updateDestinationDto.FeePerPersonForeignMax;
//        destination.MaxAltitude = updateDestinationDto.MaxAltitude;
//        destination.Overview = updateDestinationDto.Overview;

//        await _context.SaveChangesAsync();

//        var successResponse = new ApiResponse
//        {
//            StatusCode = HttpStatusCode.OK,
//            IsSuccess = true,
//            Result = "Success",
//            ErrorMessages = new List<string>()
//        };
//        return Ok(successResponse);
//    }
//    catch (Exception ex)
//    {
//        var errorResponse = new ApiResponse
//        {
//            StatusCode = HttpStatusCode.InternalServerError,
//            IsSuccess = false,
//            ErrorMessages = new List<string> { ex.Message }
//        };
//        return StatusCode((int)errorResponse.StatusCode, errorResponse);
//    }
//}

//DELETE: api / destination /{ code}
//[HttpDelete("{code}")]
//public async Task<IActionResult> DeleteDestination(string code)
//{
//    try
//    {
//        var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == code);
//        if (destination == null)
//        {
//            var apiResponse = new ApiResponse
//            {
//                StatusCode = HttpStatusCode.NotFound,
//                IsSuccess = false,
//                ErrorMessages = new List<string> { "Destination not found." }
//            };
//            return NotFound(apiResponse);
//        }

//        _context.Destinations.Remove(destination);
//        await _context.SaveChangesAsync();

//        var response = new ApiResponse
//        {
//            StatusCode = HttpStatusCode.OK,
//            IsSuccess = true,
//            Result = "Success",
//            Message = "Destination deleted successfully."
//        };
//        return Ok(response);
//    }
//    catch (Exception ex)
//    {
//        var response = new ApiResponse
//        {
//            StatusCode = HttpStatusCode.InternalServerError,
//            IsSuccess = false,
//            ErrorMessages = new List<string> { ex.Message }
//        };
//        return StatusCode((int)response.StatusCode, response);
//    }
//}
//    }
//}




﻿using IdentityFour.Data;
using IdentityFour.Dtos;
using IdentityFour.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IdentityFour.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DestinationController(ApplicationDBContext context)
        {
            _context = context;
        }

        //// this is product controllr

        // // GET: api/destination
        // [HttpGet]
        // public IActionResult GetDestinations()
        // {
        //     try
        //     {
        //         var destinations = _context.Destinations.ToList();
        //         return Ok(destinations);
        //     }
        //     catch (Exception ex)
        //     {
        //         var response = new APIResponse
        //         {
        //             ResponseCode = 500,
        //             Result = "Error",
        //             Message = ex.Message
        //         };
        //         return StatusCode(500, response);
        //     }
        // }

        // // GET: api/destination/{code}
        // [HttpGet("{code}")]
        // public IActionResult GetDestination(string code)
        // {
        //     try
        //     {
        //         var destination = _context.Destinations.FirstOrDefault(d => d.Code == code);
        //         if (destination == null)
        //         {
        //             var response = new APIResponse
        //             {
        //                 ResponseCode = 404,
        //                 Result = "Error",
        //                 Message = "Destination not found."
        //             };
        //             return NotFound(response);
        //         }
        //         return Ok(destination);
        //     }
        //     catch (Exception ex)
        //     {
        //         var response = new APIResponse
        //         {
        //             ResponseCode = 500,
        //             Result = "Error",
        //             Message = ex.Message
        //         };
        //         return StatusCode(500, response);
        //     }
        // }



        //This is for get product controller with images
        // GET: api/destination
        [HttpGet]
        public async Task<IActionResult> destination()
        {
            try
            {
                var destinationsWithImages = await _context.Destinations
                    .Include(d => d.DestinationImages)
                    .ToListAsync();

                return Ok(destinationsWithImages);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
                return StatusCode((int)errorResponse.StatusCode, errorResponse);
            }
        }

        //    GET: api/destination/{code
        //}
        [HttpGet("{code}")]
        public async Task<IActionResult> getdestinationbycode(string code)
        {
            try
            {
                var destination = await _context.Destinations
                    .Include(d => d.DestinationImages)
                    .FirstOrDefaultAsync(d => d.Code == code);

                if (destination == null)
                {
                    return NotFound("Destination not found.");
                }

                return Ok(destination);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
                return StatusCode((int)errorResponse.StatusCode, errorResponse);
            }
        }

        // POST: api/destination
        [HttpPost]
        public async Task<IActionResult> createdestination([FromForm] CreateDestinationDTO createDestinationDto)
        {
            try
            {
                // Check if the provided data is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Map DTO to Destination model
                var newDestination = new Destination
                {
                    Code = createDestinationDto.Code,
                    DurationInDays = createDestinationDto.DurationInDays,
                    Difficulty = createDestinationDto.Difficulty,
                    FeePerPersonNepaliMin = createDestinationDto.FeePerPersonNepaliMin,
                    FeePerPersonNepaliMax = createDestinationDto.FeePerPersonNepaliMax,
                    FeePerPersonForeignMin = createDestinationDto.FeePerPersonForeignMin,
                    FeePerPersonForeignMax = createDestinationDto.FeePerPersonForeignMax,
                    MaxAltitude = createDestinationDto.MaxAltitude,
                    Overview = createDestinationDto.Overview,
                    Location = createDestinationDto.Location,
                    LocationName = createDestinationDto.LocationName,
                    Why = createDestinationDto.Why,
                };

                // Add the new destination to the database
                _context.Destinations.Add(newDestination);
                await _context.SaveChangesAsync();

                // Return success response

                var response = new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>()
                };
                return CreatedAtAction(nameof(getdestinationbycode), new { code = newDestination.Code }, response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
                return StatusCode((int)errorResponse.StatusCode, errorResponse);
            }
        }




        // PUT: api/destination/{code}
        [HttpPut("{code}")]
        public async Task<IActionResult> updatedestination(string code, [FromForm] UpdateDestinationDTO updateDestinationDto)
        {
            try
            {
                var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == code);
                if (destination == null)
                {

                    return NotFound();
                }

                destination.DurationInDays = updateDestinationDto.DurationInDays;
                destination.Difficulty = updateDestinationDto.Difficulty;
                destination.FeePerPersonNepaliMin = updateDestinationDto.FeePerPersonNepaliMin;
                destination.FeePerPersonNepaliMax = updateDestinationDto.FeePerPersonNepaliMax;
                destination.FeePerPersonForeignMin = updateDestinationDto.FeePerPersonForeignMin;
                destination.FeePerPersonForeignMax = updateDestinationDto.FeePerPersonForeignMax;
                destination.MaxAltitude = updateDestinationDto.MaxAltitude;
                destination.Overview = updateDestinationDto.Overview;
                destination.Location = updateDestinationDto.Location;
                destination.LocationName = updateDestinationDto.LocationName;
                destination.Why = updateDestinationDto.Why;

                await _context.SaveChangesAsync();

                var response = new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>()
                };
         
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
                return StatusCode((int)errorResponse.StatusCode, errorResponse);
            }
        }

        // DELETE: api/destination/{code}
        [HttpDelete("{code}")]
        public async Task<IActionResult> delete(string code)
        {
            try
            {
                var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Code == code);
                if (destination == null)
                {

                    return NotFound();
                }

                _context.Destinations.Remove(destination);
                await _context.SaveChangesAsync();


                var response = new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    IsSuccess = true,
                    Result = "Success",
                    ErrorMessages = new List<string>()
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    IsSuccess = false,
                    ErrorMessages = new List<string> { ex.Message }
                };
                return StatusCode((int)errorResponse.StatusCode, errorResponse);
            }
        }
    }
}