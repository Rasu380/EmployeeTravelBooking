using EmployeeTravelBooking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TravelRequestController : ControllerBase
    {
        private readonly ITravelRequest _ITravelRequest;
        private readonly EmployeeTravelBookingDBContext _context;
        public TravelRequestController(EmployeeTravelBookingDBContext context, ITravelRequest ITravelRequest)
        {
            _context = context;
            _ITravelRequest = ITravelRequest;
        }

        [HttpGet]
        [Route("GetAllTravelRequests")]
        public async Task<ActionResult<List<TravelRequest>>> GetAllTravelRequests()
        {
            try
            {
                var requests = await _ITravelRequest.GetAllTravelRequests();
                return Ok(requests);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("GetTravelRequestByID")]
        public async Task<ActionResult<TravelRequest>> GetTravelRequestByID(int RequestID)
        {
            try
            {
                var user = await _ITravelRequest.GetTravelRequestByID(RequestID);
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
        [Route("AddTravelRequest")]
        public async Task<IActionResult> AddTravelRequest(TravelRequestInput entity)
        {
            try
            {                
                var requestID = await _ITravelRequest.AddTravelRequest(entity);

                if (requestID >= 1)
                {
                    return Ok(new { requestID = requestID, Message = "Travel Request Inserted Successfully" });
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
        [HttpPut]
        [Route("UpdateTravelRequest")]
        public async Task<IActionResult> UpdateTravelRequest(TravelRequestInput entity)
        {
            try
            {
                var result = await _ITravelRequest.UpdateTravelRequest(entity);

                if (result == 1)
                {
                    return Ok(new { Message = "Travel Request Updated Successfully" });
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

        [HttpDelete]
        [Route("DeleteTravelRequest")]
        public async Task<IActionResult> DeleteTravelRequest(int requestID)
        {
            try
            {
                var result = await _ITravelRequest.DeleteTravelRequest(requestID);
                if (result == 1)
                {
                    return Ok(new { Message = "Travel Request Deleted Successfully" });
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
        [HttpPost]
        [Route("UpdateTravelRequestStatus")]
        public async Task<IActionResult> UpdateTravelRequestStatus(int requestID, int userID, int status)
        {
            try
            {
                var result = await _ITravelRequest.UpdateTravelRequestStatus(requestID, userID, status);
                if (result == 1)
                {
                    if (status == 1)
                    {
                        return Ok(new { Message = "Travel Request Requested Successfully" });
                    }
                    else if (status == 2)
                    {
                        return Ok(new { Message = "Travel Request Approved Successfully" });
                    }
                    else if (status == 3)
                    {
                        return Ok(new { Message = "Travel Request Rejected" });
                    }
                    else if (status == 4)
                    {
                        return Ok(new { Message = "Travel Request Cancelled Successfully" });
                    }
                    else if (status == 5)
                    {
                        return Ok(new { Message = "Travel Request Completed Successfully" });
                    }
                    else
                    {
                        return StatusCode(500, "Internal Server Error");
                    }
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
