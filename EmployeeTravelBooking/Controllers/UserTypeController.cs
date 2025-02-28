using EmployeeTravelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypes _IUserTypes;
        private readonly EmployeeTravelBookingDBContext _context;
        public UserTypeController(EmployeeTravelBookingDBContext context, IUserTypes IUserTypes)
        {
            _context = context;
            _IUserTypes = IUserTypes;
        }

        [HttpGet]
        [Route("GetAllUserTypes")]
        public async Task<ActionResult<List<User>>> GetAllUserTypes()
        {
            try
            {
                var userTypes = await _IUserTypes.GetAllUserTypes();
                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        [Route("GetUserByID")]
        public async Task<ActionResult<User>> GetUserTypeByID(int ID)
        {
            try
            {
                var userType = await _IUserTypes.GetUserTypeByID(ID);
                if (userType == null)
                {
                    return NotFound();
                }
                return Ok(userType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("AddUserType")]
        public async Task<IActionResult> AddUserType(UserType entity)
        {
            try
            {
                var userType = await _context.UserTypes.SingleOrDefaultAsync(u => u.Name == entity.Name);
                if (userType == null)
                {
                    var ID = await _IUserTypes.AddUserType(entity);

                    if (ID >= 1)
                    {
                        return Ok(new { ID = ID, Message = "Inserted SuccessFully" });
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest(new { Message = "Already existing the UserType" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        [Route("UpdateUserType")]
        public async Task<IActionResult> UpdateUserType(UserType entity)
        {
            try
            {
                //var user = await _context.UserTypes.SingleOrDefaultAsync(u => u.Id == entity.Id);
                //if (user != null)
                //{
                    var result = await _IUserTypes.UpdateUserType(entity);
                    if (result == 1)
                    {
                        return Ok(new { Message = "Updated Successfully" });
                    }
                    else
                    {
                        return BadRequest();
                    }
                //}
                //else
                //{
                //    return BadRequest(new { Message = "UserType ID not existing" });
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete]
        [Route("DeleteUserType")]
        public async Task<IActionResult> DeleteUserType(int ID)
        {
            try
            {
                var result = await _IUserTypes.DeleteUserType(ID);
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
