using IMSLP.Application.Contracts.Dto;

namespace IMSLP.Application.Contracts
{
    public interface IUserService
    {
        #region account
        Task<RegisterUserResult> RegisteUser(RegisterUserViewModel register);
        //Task<LoginUserResult> LoginUser(LoginUserViewModel login);
        //Task<ActiveAccountResult> ActiveAccount(ActiveAccountViewModel activeAccount);
        #endregion
    }
}
