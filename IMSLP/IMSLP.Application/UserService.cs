using IMSLP.Application.Contracts;
using IMSLP.Application.Contracts.Dto;
using IMSLP.Domain.Entities;
using IMSLP.Domain.Repository;
using Shop.Application.Interfaces;

namespace IMSLP.Application
{
    public class UserService : IUserService
    {
        #region constractor
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;
        public UserService(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        #endregion

        #region account
        public async Task<RegisterUserResult> RegisteUser(RegisterUserViewModel register)
        {
            if (!await _userRepository.IsUserExistEmail(register.Email))
            {
                var user = new User
                {

                    UserName = register.UserName,
                    Email = register.Email,
                    RealName = register.RealName,
                    DescribeFirstContribution = register.DescribeFirstContribution,
                    MusicalBackground = register.MusicalBackground,
                    Languages = register.Languages,
                    Affiliation = register.Affiliation,
                    Password = _passwordHelper.EncodePasswordMd5(register.Password),
                    EmailActiveCode = new Random().Next(10000, 99999).ToString(),
                    IsDeleted = false,
                    IsAccountActive = false
                };
                await _userRepository.CreateUser(user);
                await _userRepository.SaveChange();
                return RegisterUserResult.Success;
            }

            return RegisterUserResult.MobileExists;
        }

        public async Task<LoginUserResult> LoginUser(LoginUserViewModel login)
        {
            var user = await _userRepository.GetUserByEmail(login.Email);
            if (user == null) return LoginUserResult.NotFound;
            if (!user.IsAccountActive) return LoginUserResult.NotActive;
            if (user.Password != _passwordHelper.EncodePasswordMd5(login.Password)) return LoginUserResult.NotFound;

            return LoginUserResult.Success;
        }


        //public async Task<ActiveAccountResult> ActiveAccount(ActiveAccountViewModel activeAccount)
        //{
        //    var user = await _userRepository.GetUserByPhoneNumber(activeAccount.PhoneNumber);

        //    if (user == null) return ActiveAccountResult.NotFound;

        //    if (user.MobileActiveCode == activeAccount.ActiveCode)
        //    {
        //        user.MobileActiveCode = new Random().Next(10000, 99999).ToString();
        //        user.IsMobileActive = true;
        //        _userRepository.UpdateUser(user);
        //        await _userRepository.SaveChange();

        //        return ActiveAccountResult.Success;
        //    }

        //    return ActiveAccountResult.Error;
        //}
        #endregion
    }
}
