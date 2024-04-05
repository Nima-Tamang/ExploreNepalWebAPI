using IdentityFour.Data;
using IdentityFour.Models;
using ImagesTesting.Models;
using ImagesTesting.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ImagesTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public BookingController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<IActionResult> GetBookingAll()
        {
            try
            {
                var bookings = await _context.Bookings.ToListAsync();

                if (bookings == null || bookings.Count == 0)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                        ErrorMessages = new List<string> { "No bookings found." }
                    });
                }

                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    ErrorMessages = new List<string> { $"An error occurred: {ex.Message}" }
                });
            }
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(id);

                if (booking == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                        ErrorMessages = new List<string> { $"Booking with ID {id} not found." }
                    });
                }

                return Ok(booking);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    ErrorMessages = new List<string> { $"An error occurred: {ex.Message}" }
                });
            }
        }

        // POST: api/Booking/CreateBooking
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromForm] CreateBookingDTO bookingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Result = null,
                        ErrorMessages = new List<string> { "Invalid booking information." }
                    });
                }

                var booking = new Booking
                {
                    Name = bookingDTO.Name,
                    Age = bookingDTO.Age,
                    PhoneNumber = bookingDTO.PhoneNumber,
                    SelectedSeason = bookingDTO.SelectedSeason,
                    SortBy = bookingDTO.SortBy,
                    Price = bookingDTO.Price
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBookingById), new { id = booking.Id }, new ApiResponse
                {
                    StatusCode = HttpStatusCode.Created,
                    //Message = "Booking created successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    ErrorMessages = new List<string> { $"An error occurred: {ex.Message}" }
                });
            }
        }

        // PUT: api/Booking/UpdateBooking/5
        [HttpPut("UpdateBooking/{id}")]
        public async Task<IActionResult> UpdateBooking(int id, [FromForm] UpdateBookingDTO bookingDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        Result = null,
                        ErrorMessages = new List<string> { "Invalid booking information." }
                    });
                }

                var existingBooking = await _context.Bookings.FindAsync(id);
                if (existingBooking == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                        ErrorMessages = new List<string> { $"Booking with ID {id} not found." }
                    });
                }

                existingBooking.Name = bookingDTO.Name;
                existingBooking.Age = bookingDTO.Age;
                existingBooking.PhoneNumber = bookingDTO.PhoneNumber;
                existingBooking.SelectedSeason = bookingDTO.SelectedSeason;
                existingBooking.SortBy = bookingDTO.SortBy;
                existingBooking.Price = bookingDTO.Price;

                await _context.SaveChangesAsync();

                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                   // Message = "Booking information updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    ErrorMessages = new List<string> { $"An error occurred: {ex.Message}" }
                });
            }
        }

        // DELETE: api/Booking/DeleteBooking/5
        [HttpDelete("DeleteBooking/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var booking = await _context.Bookings.FindAsync(id);
                if (booking == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                        ErrorMessages = new List<string> { $"Booking with ID {id} not found." }
                    });
                }

                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();

                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = null,
                    //Message = "Booking information deleted successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    ErrorMessages = new List<string> { $"An error occurred: {ex.Message}" }
                });
            }
        }
    }
}