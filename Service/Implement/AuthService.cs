namespace Service.Implement
{
    using Common.Constants;
    using Common.Enums;
    using Common.Http;
    using Domain.DTOs.User;
    using Domain.DTOs.Users;
    using Microsoft.AspNetCore.Http;
    using Microsoft.IdentityModel.Tokens;
    using Model.Entities.Users;
    using Service.Interface;
    using System.Security.Claims;

    public class AuthService : IAuthService
    {
        private IUserManager _userManager;

        public AuthService(
            IUserManager userManager,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
        }

        public ReturnMessage<UserLoginReturnDTO> CheckLogin(UserLoginDTO data)
        {
            if (data.Username.IsNullOrEmpty() || data.Password.IsNullOrEmpty())
            {
                return new ReturnMessage<UserLoginReturnDTO>(true, null, MessageConstants.InvalidAuthInfoMsg);
            }

            try
            {
                //var account = _userRepository.Queryable().Where(a => !a.IsDeleted && a.Type == AccountRole.RoleEnum.Admin && a.Username == data.Username && a.Password == MD5Helper.ToMD5Hash(data.Password)).FirstOrDefault();
                //if (account.IsNullOrEmpty())
                //{
                //    return new ReturnMessage<UserLoginReturnDTO>(true, null, MessageConstants.InvalidAuthInfoMsg);
                //}

                var account = new User()
                {
                    Username = data.Username,
                    Id = Guid.NewGuid(),
                    Type = AccountRole.RoleEnum.Admin
                };

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.UserData, account.Username),
                    new Claim(ClaimTypes.NameIdentifier,account.Id.ToString()),
                    new Claim(ClaimTypes.Role, AccountRole.RoleDictionary.GetValueOrDefault(account.Type))
                };

                // Generate JWT token
                var token = _userManager.GenerateToken(claims, DateTime.UtcNow);
                var result = new UserLoginReturnDTO();
                result.Access_Token = token;
                return new ReturnMessage<UserLoginReturnDTO>(false, result, MessageConstants.LoginSuccess);
            }
            catch (Exception ex)
            {
                return new ReturnMessage<UserLoginReturnDTO>(true, null, ex.Message);
            }
        }

        public ReturnMessage<UserDataReturnDTO> GetInformationUser()
        {
            try
            {
                //var data = _userRepository.Queryable().Where(it => it.Id == _userManager.AuthorizedUserId).FirstOrDefault();
                //if (data.IsNullOrEmpty())
                //{
                //    return new ReturnMessage<UserDataReturnDTO>(true, null, MessageConstants.Error);
                //}

                //var result = _mapper.Map<User, UserDataReturnDTO>(data);

                var data = _userManager.GetInformationUser();

                var result = new UserDataReturnDTO()
                {
                    FirstName = data.FirstName,
                };

                return new ReturnMessage<UserDataReturnDTO>(false, result, MessageConstants.LoginSuccess);
            }
            catch (Exception ex)
            {
                return new ReturnMessage<UserDataReturnDTO>(true, null, ex.Message);
            }
        }
    }
}
