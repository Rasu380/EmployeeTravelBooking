
using EmployeeTravelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Repositories
{
    public class UserRepository:IUsers
    {
        private readonly EmployeeTravelBookingDBContext _context;
        public UserRepository(EmployeeTravelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<User> CheckUserExists(LoginModel entity)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == entity.userName && u.Password == entity.password);
                return user;
            }
            catch (Exception ex) {
                throw;
            }
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<User> GetUserByID(int UserID)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == UserID);
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddUser(User entity)
        {
            using(var transaction = await _context.Database.BeginTransactionAsync()) 
            {
                try
                {
                    entity.CreatedAt = DateTime.Now;
                    _context.Users.Add(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity.UserId;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task<int> UpdateUser(User entity)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                    entity.UpdatedAt = DateTime.Now;
                    _context.Users.Update(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = 1;
                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
         }
        public async Task<int> DeleteUser(int UserID)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                    //var user = await _context.Users.FindAsync(UserID);
                    //if (user != null)
                    //{
                    //_context.Users.Remove(user);

                    var user = new User()
                    {
                        UserId = UserID,
                        Status = 0,
                        UpdatedAt = DateTime.Now
                    };
                    _context.Users.Attach(user);
                    _context.Entry(user).Property(u => u.Status).IsModified = true;
                    _context.Entry(user).Property(u => u.UpdatedAt).IsModified = true;

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    result = 1;
               // }
                return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
