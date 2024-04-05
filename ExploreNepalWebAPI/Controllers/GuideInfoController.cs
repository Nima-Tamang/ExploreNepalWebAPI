//using IdentityFour.Data;
//using IdentityFour.Dtos;
//using IdentityFour.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IdentityFour.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GuideInfoController : ControllerBase
//    {
//        private readonly ApplicationDBContext _context;

//        public GuideInfoController(ApplicationDBContext context)
//        {
//            _context = context;
//        }

//        //// GET: api/GuideInfo
//        //[HttpGet]
//        //public async Task<IActionResult> GetGuideInfos()
//        //{
//        //    try
//        //    {
//        //        var guideInfos = await _context.GuideInfos.ToListAsync();
//        //        return Ok(guideInfos);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var response = new APIResponse
//        //        {
//        //            ResponseCode = 500,
//        //            Result = "Error",
//        //            Message = ex.Message
//        //        };
//        //        return StatusCode(500, response);
//        //    }
//        //}

//        //// GET: api/GuideInfo/{id}
//        //[HttpGet("{id}")]
//        //public async Task<IActionResult> GetGuideInfo(int id)
//        //{
//        //    try
//        //    {
//        //        var guideInfo = await _context.GuideInfos.FindAsync(id);
//        //        if (guideInfo == null)
//        //        {
//        //            return NotFound("Guide info not found.");
//        //        }
//        //        return Ok(guideInfo);
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        var response = new APIResponse
//        //        {
//        //            ResponseCode = 500,
//        //            Result = "Error",
//        //            Message = ex.Message
//        //        };
//        //        return StatusCode(500, response);
//        //    }
//        //}


//        [HttpGet]
//        public async Task<IActionResult> GetGuideInfo()
//        {
//            try
//            {
//                var guideInfoWithImages = await _context.GuideInfos
//                    .Include(d => d.GuideInfoImages)
//                    .ToListAsync();

//                return Ok(guideInfoWithImages);
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


//        [HttpGet("{code}")]
//        public async Task<IActionResult> GetGuideInfoByCode(string code)
//        {
//            try
//            {
//                var guideInfo = await _context.GuideInfos
//                    .Include(d => d.GuideInfoImages)
//                    .FirstOrDefaultAsync(d => d.Code == code);

//                if (guideInfo == null)
//                {
//                    return NotFound("Guide Info not found.");
//                }

//                return Ok(guideInfo);
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


//        [HttpPost]
//        public async Task<IActionResult> CreateGuideInfo([FromForm] CreateGuideInfoDTO createGuideInfoDTO)
//        {
//            APIResponse response = new APIResponse();

//            try
//            {
//                // Map DTO to Entity
//                var guideInfo = new GuideInfo
//                {
//                    Code = createGuideInfoDTO.Code,
//                    Name = createGuideInfoDTO.Name,
//                    Gender = createGuideInfoDTO.Gender,
//                    Experience = createGuideInfoDTO.Experience,
//                    Email = createGuideInfoDTO.Email,
//                    Phone = createGuideInfoDTO.Phone,
//                    CompletedTreks = createGuideInfoDTO.CompletedTreks,
//                    ServicesOffered = createGuideInfoDTO.ServicesOffered,
//                    WhyChoose = createGuideInfoDTO.WhyChoose,
//                    BookingInfo = createGuideInfoDTO.BookingInfo
//                };

//                // Add to database
//                _context.GuideInfos.Add(guideInfo);
//                await _context.SaveChangesAsync();

//                response.ResponseCode = 201;
//                response.Result = "Success";
//                response.Message = "Guide info created successfully";
//                return CreatedAtRoute(nameof(GetGuideInfo), new { code = guideInfo.Code }, response);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                response.ResponseCode = 500;
//                response.Result = "Error";
//                response.Message = $"An error occurred: {ex.Message}";
//                return StatusCode(500, response);
//            }
//        }



//        [HttpPut("{code}")]
    
//        public async Task<IActionResult> UpdateGuideInfo(string code,[FromForm] UpdateGuideInfoDTO updateGuideInfoDTO)
//        {
//            APIResponse response = new APIResponse();

//            try
//            {
//                // Find the existing guide info by code
//                var guideInfo = await _context.GuideInfos.FindAsync(code);

//                if (guideInfo == null)
//                {
//                    response.ResponseCode = 404;
//                    response.Result = "Failed";
//                    response.Message = "Guide info not found";
//                    return NotFound(response);
//                }

//                // Update the properties of the guide info
//                guideInfo.Name = updateGuideInfoDTO.Name;
//                guideInfo.Gender = updateGuideInfoDTO.Gender;
//                guideInfo.Experience = updateGuideInfoDTO.Experience;
//                guideInfo.Email = updateGuideInfoDTO.Email;
//                guideInfo.Phone = updateGuideInfoDTO.Phone;
//                guideInfo.CompletedTreks = updateGuideInfoDTO.CompletedTreks;
//                guideInfo.ServicesOffered = updateGuideInfoDTO.ServicesOffered;
//                guideInfo.WhyChoose = updateGuideInfoDTO.WhyChoose;
//                guideInfo.BookingInfo = updateGuideInfoDTO.BookingInfo;

//                _context.GuideInfos.Update(guideInfo);
//                await _context.SaveChangesAsync();

//                response.ResponseCode = 200;
//                response.Result = "Success";
//                response.Message = "Guide info updated successfully";
//                return Ok(response);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                response.ResponseCode = 500;
//                response.Result = "Error";
//                response.Message = $"An error occurred: {ex.Message}";
//                return StatusCode(500, response);
//            }
//        }




//      [HttpDelete("{code}")]
//        public async Task<IActionResult> DeleteGuideInfo(string code)
//        {
//            try
//            {
//                var guideInfo = await _context.GuideInfos.FindAsync(code);

//                if (guideInfo == null)
//                {
//                    return NotFound(new APIResponse { ResponseCode = 404, Result = "Failed", Message = "Guide info not found" });
//                }

//                _context.GuideInfos.Remove(guideInfo);
//                await _context.SaveChangesAsync();

//                return Ok(new APIResponse { ResponseCode = 200, Result = "Success", Message = "Guide info deleted successfully" });
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                return StatusCode(500, new APIResponse { ResponseCode = 500, Result = "Error", Message = $"An error occurred: {ex.Message}" });
//            }
//        }

//    }
//}



      
    


