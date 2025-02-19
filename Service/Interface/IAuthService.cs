namespace Service.Interface
{
    using Common.Http;
    using Domain.DTOs.User;
    using Domain.DTOs.Users;

    public interface IAuthService
    {
        ReturnMessage<UserLoginReturnDTO> CheckLogin(UserLoginDTO data);
        ReturnMessage<UserDataReturnDTO> GetInformationUser();
    }
}
