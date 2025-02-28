using EmployeeTravelBooking.Models;

namespace EmployeeTravelBooking
{
    public interface IUsers
    {
        Task<User> CheckUserExists(LoginModel entity);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserByID(int UserID);
        Task<int> AddUser(User entity);
        Task<int> UpdateUser(User entity);
        Task<int> DeleteUser(int UserID);
    }
}
