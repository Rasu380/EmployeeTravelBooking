using EmployeeTravelBooking.Models;

namespace EmployeeTravelBooking
{
    public interface IUserTypes
    {
        Task<UserType> CheckUserTypeExists(UserType entity);
        Task<List<UserType>> GetAllUserTypes();
        Task<UserType> GetUserTypeByID(int ID);
        Task<int> AddUserType(UserType entity);
        Task<int> UpdateUserType(UserType entity);
        Task<int> DeleteUserType(int UserID);
    }
}
