using EmployeeTravelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeTravelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUsers _IUsers;
        private readonly EmployeeTravelBookingDBContext _context;
        public AuthController(EmployeeTravelBookingDBContext context,JwtService jwtService, IUsers IUsers)
        {
            _context = context;
            _jwtService = jwtService;
            _IUsers = IUsers;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginModel entity)
        {
            try
            {
                var user = await _IUsers.CheckUserExists(entity);
                if (user != null)
                {
                    var userType = await _context.UserTypes.SingleOrDefaultAsync(u => u.Id == user.UserTypeId);
                    var token = _jwtService.GenerateToken(user.FirstName.ToString(), userType.Name.ToString());

                    var loginTracking = new LoginTracking() { UserId = user.UserId, ActualToken = token, CreateAt = DateTime.Now };
                    if (loginTracking != null)
                    {
                        _context.LoginTrackings.Add(loginTracking);
                        await _context.SaveChangesAsync();
                    }
                    return Ok(new { Token = token });
                }
                else
                {
                    return Unauthorized(new { StatusCode = 401, Message = "Unauthorized Access" });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
