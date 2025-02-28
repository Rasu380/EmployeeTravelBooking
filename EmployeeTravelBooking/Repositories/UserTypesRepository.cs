using EmployeeTravelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTravelBooking.Repositories
{
    public class UserTypesRepository: IUserTypes
    {
        private readonly EmployeeTravelBookingDBContext _context;
        public UserTypesRepository(EmployeeTravelBookingDBContext context)
        {
            _context = context;
        }

        public async Task<UserType> CheckUserTypeExists(UserType entity)
        {
            try
            {
                var userType = await _context.UserTypes.SingleOrDefaultAsync(u => u.Name == entity.Name);
                return userType;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<List<UserType>> GetAllUserTypes()
        {
            try
            {
                return await _context.UserTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<UserType> GetUserTypeByID(int ID)
        {
            try
            {
                var userType = await _context.UserTypes.FirstOrDefaultAsync(u => u.Id == ID);
                return userType;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> AddUserType(UserType entity)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    _context.UserTypes.Add(entity);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return entity.Id;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task<int> UpdateUserType(UserType entity)
        {
           using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                    _context.UserTypes.Update(entity);
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
        public async Task<int> DeleteUserType(int ID)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    int result = 0;
                //var userType = await _context.UserTypes.FindAsync(ID);
                //if (userType != null)
                //{
                        var usertypes = new UserType()
                        {
                            Id=ID,
                            Active=0
                        };
                        _context.UserTypes.Attach(usertypes);
                        _context.Entry(usertypes).Property(u => u.Active).IsModified = true;
                        //_context.UserTypes.Remove(userType);
                        await _context.SaveChangesAsync();
                        await transaction.CommitAsync();
                        result = 1;
                //}
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
