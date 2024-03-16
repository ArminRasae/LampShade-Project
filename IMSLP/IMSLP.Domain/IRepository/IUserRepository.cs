using IMSLP.Application.Contracts.Dto;
using IMSLP.Domain.Entities;

namespace IMSLP.Domain.Repository
{
    public interface IUserRepository
    {
        #region account
        Task<bool> IsUserExistEmail(string email);
        Task CreateUser(User user);
        Task<User> GetUserByEmail(string email);
        void UpdateUser(User user);
        Task SaveChange();
        #endregion
    }
}
