using EmployeeTravelBooking.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUsers _IUsers;
        private readonly EmployeeTravelBookingDBContext _context;
        public UserController(EmployeeTravelBookingDBContext context, IUsers IUsers)
        {
            _context = context;
            _IUsers = IUsers;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _IUsers.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex) {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("GetUserByID")]
        public async Task<ActionResult<User>> GetUserByID(int UserID)
        {
            try
            {
                var user = await _IUsers.GetUserByID(UserID);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        } 

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User entity)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == entity.Email);
                if (user == null)
                {
                    var userID = await _IUsers.AddUser(entity);

                    if (userID >= 1)
                    {
                        return Ok(new { UserID = userID, Message = "Inserted SuccessFully" });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Already existing the user" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(User entity)
        {
            try
            {
                //var user = await _context.Users.SingleOrDefaultAsync(u => u.UserId == entity.UserId);
                //if (user != null)
                //{
                    var result = await _IUsers.UpdateUser(entity);
                    if (result == 1)
                    {
                        return Ok(new { Message = "Updated SuccessFully" });
                    }
                    else
                    {
                        return BadRequest();
                    }
                //}
                //else
                //{
                //    return BadRequest(new { Message = "User Id not existing" });
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int UserID)
        {
            try
            {
                var result = await _IUsers.DeleteUser(UserID);
                if (result == 1)
                {
                    return Ok(new { Message = "Deleted SuccessFully" });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
