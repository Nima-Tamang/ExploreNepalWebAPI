
using Azure;
using ExploreNepalWebAPI.Models.Dto;
using ExploreNepalWebAPI.Utility;
using IdentityFour.Data;
using IdentityFour.Dtos;
using IdentityFour.Interfaces;
using IdentityFour.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RedMango_API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDBContext _db;
        private ApiResponse _response;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private string secretKey;
        public AccountController(ApplicationDBContext db, IConfiguration configuration,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
            _response = new ApiResponse();
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        //{
        //    AppUser userFromDb = _db.AppUsers
        //            .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

        //    bool isValid = await _userManager.CheckPasswordAsync(userFromDb, model.Password);

        //    if (isValid == false)
        //    {
        //        _response.Result = new LoginResponseDTO();
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages.Add("Username or password is incorrect");
        //        return BadRequest(_response);
        //    }

        //    //we have to generate JWT Token
        //    var roles = await _userManager.GetRolesAsync(userFromDb);
        //    JwtSecurityTokenHandler tokenHandler = new();
        //    byte[] key = Encoding.ASCII.GetBytes(secretKey);

        //    SecurityTokenDescriptor tokenDescriptor = new()
        //    {
        //        //Subject = new ClaimsIdentity(new Claim[]
        //        //{
        //        //    new Claim("fullName", userFromDb.Name),
        //        //    new Claim("id", userFromDb.Id.ToString()),
        //        //    new Claim(ClaimTypes.Email, userFromDb.UserName.ToString()),
        //        //    new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
        //        //}),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };

        //    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        //    LoginResponseDTO loginResponse = new()
        //    {
        //        Email = userFromDb.Email,
        //        Token = tokenHandler.WriteToken(token)
        //    };

        //    if (loginResponse.Email == null || string.IsNullOrEmpty(loginResponse.Token))
        //    {
        //        _response.StatusCode = HttpStatusCode.BadRequest;
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages.Add("Username or password is incorrect");
        //        return BadRequest(_response);
        //    }

        //    _response.StatusCode = HttpStatusCode.OK;
        //    _response.IsSuccess = true;
        //    _response.Result = loginResponse;
        //    return Ok(_response);

        //}


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            AppUser userFromDb = _db.AppUsers
                .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(userFromDb, model.Password);

            if (isValid == false)
            {
                _response.Result = new LoginResponseDTO();
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }

            // Generate JWT Token
            var roles = await _userManager.GetRolesAsync(userFromDb);
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
    {
        new Claim("fullName", userFromDb.Name),
        new Claim("id", userFromDb.Id.ToString()),
        new Claim(ClaimTypes.Email, userFromDb.UserName.ToString()),
        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
    };

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponse = new LoginResponseDTO
            {
                Email = userFromDb.Email,
                Token = Convert.ToBase64String(Encoding.UTF8.GetBytes(tokenHandler.WriteToken(token)))
            };

            if (loginResponse.Email == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username or password is incorrect");
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {
            AppUser userFromDb = _db.AppUsers
                .FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());

            if (userFromDb != null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("Username already exists");
                return BadRequest(_response);
            }

            AppUser newUser = new()
            {
                UserName = model.UserName,
                Email = model.UserName,
                NormalizedEmail = model.UserName.ToUpper(),
                Name = model.Name
            };

            try
            {
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    //if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
                    //{
                    //    //create roles in database
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_Customer));
                    //}
                    //if (model.Role.ToLower() == SD.Role_Admin)
                    //{
                    //    await _userManager.AddToRoleAsync(newUser, SD.Role_Admin);
                    //}
                    //else
                    //{
                    await _userManager.AddToRoleAsync(newUser, "User");


                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception)
            {

            }
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.ErrorMessages.Add("Error while registering");
            return BadRequest(_response);


        }
    }
}



