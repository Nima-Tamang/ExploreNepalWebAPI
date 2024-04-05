using IdentityFour.Data;
using IdentityFour.Models;
using ImagesTesting.Models;
using ImagesTesting.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ImagesTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private ApiResponse _response;
        public UserInfoController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfoAll()
        {
            try
            {
                // Retrieve all user information from the database
                var users = await _context.UserInfos.ToListAsync();

                // Check if there are any users
                if (users == null || users.Count == 0)
                {
                    return NotFound(new ApiResponse
                    {
                        
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Return the list of users
                return Ok(users);
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



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfoById(int id)
        {
            try
            {
                // Retrieve user information by ID from the database
                var user = await _context.UserInfos.FindAsync(id);

                // Check if the user exists
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Return the user information
                return Ok(user);
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


        [HttpPost]
        public async Task<IActionResult> CreateUserInfo( CreateUserInfoDTO userInfoDTO)
        {
            try
            {
                // Check if the provided user information is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Map the DTO to the UserInfo entity
                var userInfo = new UserInfo
                {
                    FullName = userInfoDTO.FullName,
                    Email = userInfoDTO.Email,
                    PhoneNumber = userInfoDTO.PhoneNumber,
                    AdditionalText = userInfoDTO.AdditionalText,
                    Location= userInfoDTO.Location,
                };

                // Add the user information to the database
                _context.UserInfos.Add(userInfo);
                await _context.SaveChangesAsync();

                // Return a success response
                return CreatedAtAction(nameof(GetUserInfoById), new { id = userInfo.UserId }, new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = userInfo,
                    
                });
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInfo(int id, [FromForm] UpdateUserInfoDTO userInfoDTO)
        {
            try
            {
                // Check if the provided user information is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Check if the provided user ID matches any existing user
                var existingUser = await _context.UserInfos.FindAsync(id);
                if (existingUser == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Update user information
                existingUser.FullName = userInfoDTO.FullName;
                existingUser.Email = userInfoDTO.Email;
                existingUser.PhoneNumber = userInfoDTO.PhoneNumber;
                existingUser.AdditionalText = userInfoDTO.AdditionalText;
                existingUser.Location = userInfoDTO.Location;

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return a success response
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = existingUser,
                });
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo(int id)
        {
            try
            {
                // Find the user information by ID
                var user = await _context.UserInfos.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new ApiResponse
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        Result = null,
                    });
                }

                // Remove the user information
                _context.UserInfos.Remove(user);
                await _context.SaveChangesAsync();

                // Return a success response
                return Ok(new ApiResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = user,
                    
                });
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
