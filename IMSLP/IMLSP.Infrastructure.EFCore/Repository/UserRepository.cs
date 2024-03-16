using IMLSP.Infrastructure.EFCore.Context;
using IMSLP.Domain.Entities;
using IMSLP.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace IMLSP.Infrastructure.EFCore.Repository
{
    public class UserRepository: IUserRepository
    {
        #region constractor
        private readonly IMSLPDbContext _context;
        public UserRepository(IMSLPDbContext context)
        {
            _context = context;
        }

        #endregion

        #region account
        public async Task<bool> IsUserExistEmail(string email)
        {
            return await _context.Users.AsQueryable().AnyAsync(c => c.Email == email);
        }

        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.AsQueryable()
                .SingleOrDefaultAsync(c => c.Email == email);
        }
        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
