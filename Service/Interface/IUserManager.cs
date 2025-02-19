using Domain.DTOs.Users;
using System.Security.Claims;

namespace Service.Interface
{
    public interface IUserManager
    {
        string GenerateToken(IEnumerable<Claim> claims, DateTime now);
        public UserInformationDTO GetInformationUser();
        Guid AuthorizedUserId { get; }
    }
}
