using EmployeeTravelBooking.Models;

namespace EmployeeTravelBooking
{
    public interface ITravelRequest
    {
        Task<List<TravelRequest>> GetAllTravelRequests();
        Task<TravelRequest> GetTravelRequestByID(int RequestID);
        Task<int> AddTravelRequest(TravelRequestInput entity);
        Task<int> UpdateTravelRequest(TravelRequestInput entity);
        Task<int> DeleteTravelRequest(int requestID);
        Task<int> UpdateTravelRequestStatus(int requestID, int userID,int status);
    }
}
